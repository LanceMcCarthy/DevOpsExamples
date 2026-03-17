---
name: configure-telerik-nuget
description: Helps setup, configure and manage Telerik NuGet feeds in your repo's nuget.config file.
---

Use these helper functions to manage Telerik NuGet source configuration.

Get a new api key at https://www.telerik.com/account/downloads/api-keys

## Function: configure

Adds the Telerik feed when missing, or updates credentials/source settings when the same source URL already exists.

```powershell
function Configure-TelerikNuGetSource {
	param(
		[Parameter(Mandatory = $true)]
		[string]$ApiKey,

		[string]$SourceName = "Telerik_NuGet_Server",
		[string]$SourceUrl = "https://nuget.telerik.com/v3/index.json"
	)

	$existingSourcesOutput = dotnet nuget list source | Out-String

	if ($existingSourcesOutput -match [regex]::Escape($SourceUrl)) {
		dotnet nuget update source "$SourceName" --source "$SourceUrl" --username "api-key" --password "$ApiKey" --store-password-in-clear-text
		Write-Host "A NuGet package source with URL '$SourceUrl' already exists. Updated source '$SourceName'."
		return
	}

	dotnet nuget source add --name "$SourceName" --source "$SourceUrl" --username "api-key" --password "$ApiKey" --store-password-in-clear-text

	Write-Host "Added Telerik NuGet source '$SourceName' at '$SourceUrl'."
}
```

Example usage:

```powershell
Configure-TelerikNuGetSource -ApiKey "<telerik-api-key>"
```