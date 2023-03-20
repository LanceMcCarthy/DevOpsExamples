# Written by Lance McCarthy for use in 
# Azure DevOps Classic Pipelines
# GitHub Actions
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
RUN --mount=type=secret,id=telerik_username \
  --mount=type=secret,id=telerik_password \
  dotnet nuget update source "Telerik_Feed" --source "https://nuget.telerik.com/v3/index.json" --username $(cat /run/secrets/telerik_username) --password $(cat /run/secrets/telerik_password) --configfile "./NuGet.Config" --store-password-in-clear-text
RUN dotnet restore "MyBlazorApp.csproj" --configfile "./NuGet.Config"
RUN dotnet build "MyBlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBlazorApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
