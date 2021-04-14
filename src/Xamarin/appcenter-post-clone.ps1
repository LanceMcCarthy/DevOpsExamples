Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe

nuget.exe sources Add -NonInteractive -Name TelerikNugetFeed -Source https://nuget.telerik.com/nuget  -UserName $env:TELERIK_USERNAME -Password $env:TELERIK_PASSWORD -StorePasswordInClearText
