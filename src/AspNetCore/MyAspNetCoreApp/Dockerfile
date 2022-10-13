FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# This sets the container's variable "TELERIK_USERNAME" using the value of the host's variable "%TELERIK_USERNAME%"
ARG TELERIK_USERNAME=%TELERIK_USERNAME%
# This sets the container's variable "TELERIK_PASSWORD" using the value of the host's variable "%TELERIK_PASSWORD%"
ARG TELERIK_PASSWORD=%TELERIK_PASSWORD%
# Change work directory to the subfolder with this project
WORKDIR /src/MyAspNetCoreApp
COPY . .
RUN dotnet restore "MyAspNetCoreApp.csproj"
RUN dotnet build "MyAspNetCoreApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAspNetCoreApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetCoreApp.dll"]
