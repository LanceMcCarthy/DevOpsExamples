FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# Telerik NuGet Server Setup
# 1. Use ARG or ENV to set build-time variables (these %varibles% are already set on the dev machine or the cloud runner's environment)
ARG TELERIK_USERNAME=%TELERIK_USERNAME%
ARG TELERIK_PASSWORD=%TELERIK_PASSWORD%
# 2. Copy the nuget.config file into the work directory
COPY ["NuGet.Config", "."]
# Continue as usual
COPY ["MyAspNetCoreApp/MyAspNetCoreApp.csproj", "MyAspNetCoreApp/"]
RUN dotnet restore "MyAspNetCoreApp/MyAspNetCoreApp.csproj"
COPY . .
WORKDIR "/src/MyAspNetCoreApp"
RUN dotnet build "MyAspNetCoreApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAspNetCoreApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetCoreApp.dll"]