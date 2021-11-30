# remove Android and iOS projects from solution. Docs https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln
dotnet sln "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms.sln" remove "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/Android/XamForms.Android.csproj" "$APPCENTER_SOURCE_DIRECTORY/src/Xamarin/XamForms/iOS/XamForms.iOS.csproj"
