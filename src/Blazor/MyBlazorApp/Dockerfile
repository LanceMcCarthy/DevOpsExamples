# Written by Lance McCarthy for use in Azure DevOps Classic Pipelines and GitHub Actions
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/MyBlazorApp
COPY . .
RUN --mount=type=secret,id=telerik_username \
  --mount=type=secret,id=telerik_password \
  dotnet nuget update source "Telerik_v3_Feed" --source "https://nuget.telerik.com/v3/index.json" --username $(cat /run/secrets/telerik_username) --password $(cat /run/secrets/telerik_password) --configfile "./NuGet.Config" --store-password-in-clear-text
RUN dotnet restore "MyBlazorApp.csproj" --configfile "./NuGet.Config"
RUN dotnet publish "MyBlazorApp.csproj" -o /app/publish /p:UseAppHost=false --self-contained false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
