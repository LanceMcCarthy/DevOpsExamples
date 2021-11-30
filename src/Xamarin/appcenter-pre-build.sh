#!/usr/bin/env bash

# Option 1 - Use msbuild restore before dotnet restore is used
msbuild $APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms.sln /t:restore

# Option 2 - Remove the UWP project form the solution before the build
# dotnet sln $APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms.sln remove $APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/UWP/XamForms.UWP.csproj
