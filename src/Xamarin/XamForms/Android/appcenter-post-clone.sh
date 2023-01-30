#!/usr/bin/env bash
dotnet sln "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms.sln" remove "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/UWP/XamForms.UWP.csproj"

wget -O dotnet-install.sh https://dot.net/v1/dotnet-install.sh

sudo chmod +x ./dotnet-install.sh

./dotnet-install.sh --version latest