# Use msbuild restore before dotnet restore is used
msbuild $APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/UWP/XamForms.UWP.csproj /t:restore
