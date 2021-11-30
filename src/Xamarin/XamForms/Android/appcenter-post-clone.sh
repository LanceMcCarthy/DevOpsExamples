#!/usr/bin/env bash

echo "Post-Clone Steps"

dotnet sln "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms.sln" remove "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/UWP/XamForms.UWP.csproj"
