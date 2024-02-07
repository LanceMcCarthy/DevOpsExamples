FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Dependencies for Telerik Reporting on Linux with Skia
RUN apt-get update
RUN apt-get install libfreetype6 libfontconfig1 -y


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
# Use a docker secret to add the 'Telerik' package source to the system's default nuget.config (usually at ~/.nuget/NuGet/NuGet.Config)
RUN --mount=type=secret,id=telerik_key \
  dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "TelerikNuGetServer" -u "api-key" -p $(cat /run/secrets/telerik_key) --store-password-in-clear-text
RUN dotnet restore "./MyAspNetCoreApp.csproj"
RUN dotnet build "./MyAspNetCoreApp.csproj" -c Release -o /app/build --no-restore


FROM build AS publish
RUN dotnet publish "./MyAspNetCoreApp.csproj" --no-restore -c Release -o /app/publish /p:UseAppHost=false --self-contained false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetCoreApp.dll"]
