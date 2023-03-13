# Written by Lance McCarthy for use specifically in Azure DevOps Pipelines
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Dependencies for Telerik Reporting on Linux
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/MyBlazorApp
COPY . .
RUN --mount=type=secret,id=TELERIK_SECRET_KEY,dst=/run/secrets/TELERIK_SECRET_KEY \
  dotnet nuget update source "Telerik_Feed" -s "https://nuget.telerik.com/v3/index.json" -u "api-key" -p "$(cat /run/secrets/TELERIK_SECRET_KEY)" --configfile "./NuGet.Config" --store-password-in-clear-text \
  && dotnet restore "MyBlazorApp.csproj" --configfile "./NuGet.Config" \
  && dotnet build "MyBlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBlazorApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
