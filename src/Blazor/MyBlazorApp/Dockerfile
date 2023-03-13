FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Dependencies for Telerik Reporting on Linux
RUN apt update \
    && apt install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# Temporary argument for build phase. This is passed in via '--build-arg' argument when building the image.
ARG TELERIK_KEY=temp_telerik_key
# Change work directory to the subfolder with this project
WORKDIR /src/MyBlazorApp
# Copy over the code files
COPY . .
# Here we use a docker secret to update the 'Telerik_Feed' package source, then restore then build. You can set the secret from a variety of sources, including a file, environment variable, or Azure Key Vault
RUN dotnet nuget update source "Telerik_Feed" -s "https://nuget.telerik.com/v3/index.json" -u "api-key" -p $TELERIK_KEY --configfile "./NuGet.Config" --store-password-in-clear-text \
  && dotnet restore "MyBlazorApp.csproj" --configfile "./NuGet.Config" \
  && dotnet build "MyBlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBlazorApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
