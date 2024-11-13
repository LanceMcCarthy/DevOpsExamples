FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Dependencies for Telerik Reporting on Linux with Skia
RUN apt-get update
RUN apt-get install libfreetype6 libfontconfig1 -y


FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
# Use a docker secret to add the 'Telerik' package source to the system's default nuget.config (usually at ~/.nuget/NuGet/NuGet.Config)
RUN --mount=type=secret,id=telerik_key \
  dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "TelerikNuGetServer" -u "api-key" -p $(cat /run/secrets/telerik_key) --store-password-in-clear-text
RUN dotnet restore "./MyAspNetCoreApp.csproj"
RUN dotnet publish "./MyAspNetCoreApp.csproj" -o /app/publish /p:UseAppHost=false --no-restore --self-contained false


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetCoreApp.dll"]
