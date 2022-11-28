FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Depenencies for Telerik Reporting on Linux
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# This sets the container's variable "TELERIK_USERNAME" using the value of the host's variable "%TELERIK_USERNAME%"
#ARG TELERIK_USERNAME=%TELERIK_USERNAME%
# This sets the container's variable "TELERIK_PASSWORD" using the value of the host's variable "%TELERIK_PASSWORD%"
#ARG TELERIK_PASSWORD=%TELERIK_PASSWORD%
# Change work directory to the subfolder with this project
WORKDIR /src/MyAspNetCoreApp
COPY . .
# You can also directly update the package source
RUN dotnet nuget update source "Telerik_Feed" --source "https://nuget.telerik.com/v3/index.json" --configfile "./NuGet.Config" --username "api-key" --password "%TELERIK_NUGET_KEY%" --store-password-in-clear-text
RUN dotnet restore "MyAspNetCoreApp.csproj" --configfile "./NuGet.Config"
RUN dotnet build "MyAspNetCoreApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAspNetCoreApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetCoreApp.dll"]
