# Written by Lance McCarthy as an example only. Use at your own risk, carefully review how you are handling your secrets and what is included in your final image.

### STAGE 1 ###
# Create our base image from the aspnet image, and prep any neccessary settings
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


### STAGE 2 ###
# Compile the project and create production-ready artifacts
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/MyBlazorApp
COPY . .
# 1. mount the nuget key secret and immediately use it to add the Telerik server as a package source
RUN --mount=type=secret,id=telerik-nuget-key \
    dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "TelerikNuGetServer" -u "api-key" -p $(cat /run/secrets/telerik_key) --store-password-in-clear-text

# 2. restore the project
RUN dotnet restore "MyBlazorApp.csproj"

# 3. mount the license key secret and set the "TELERIK_LICENSE" environment variable
RUN --mount=type=secret,id=telerik-license-key,env=TELERIK_LICENSE

# 4. build and publish the project
RUN dotnet publish "MyBlazorApp.csproj" -o /app/publish /p:UseAppHost=false --self-contained false


### STAGE 3 ###
# Build the final image from the base, but copy the pubilsh artifacts from the intermediate stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
