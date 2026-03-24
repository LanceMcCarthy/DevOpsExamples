---
name: configure-telerik-nuget
version: 1.1.0
description: Helps setup, configure and manage Telerik NuGet feeds in your repo's nuget.config file.
required_binaries:
  - pwsh
  - dotnet
author: Lance McCarthy
homepage: https://github.com/DevOpsExamples/.github
source: https://github.com/DevOpsExamples/.github/tree/main/skills/configure-telerik-nuget
---

Use these helper functions to manage Telerik NuGet source configuration.

Get a new api key at https://www.telerik.com/account/downloads/api-keys

## Function: configure

Sets a global user environment variable for the Telerik API key and updates/creates `nuget.config` so credentials use the environment variable instead of a hardcoded secret.

```powershell
function Configure-TelerikNuGetSource {
	param(
		[Parameter(Mandatory = $true)]
		[string]$ApiKey,

		[string]$ApiKeyEnvVarName = "TELERIK_NUGET_API_KEY",
		[string]$SourceName = "Telerik_NuGet_Server",
		[string]$SourceUrl = "https://nuget.telerik.com/v3/index.json",
		[string]$NuGetConfigPath = "./nuget.config"
	)

	# Store API key as a user-level environment variable so it is available globally
	[Environment]::SetEnvironmentVariable($ApiKeyEnvVarName, $ApiKey, "User")
	$env:$ApiKeyEnvVarName = $ApiKey

	if (-not (Test-Path $NuGetConfigPath)) {
		@"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources />
  <packageSourceCredentials />
</configuration>
"@ | Set-Content -Path $NuGetConfigPath -Encoding UTF8
	}

	[xml]$nugetConfig = Get-Content -Path $NuGetConfigPath

	if (-not $nugetConfig.configuration.packageSources) {
		$packageSourcesNode = $nugetConfig.CreateElement("packageSources")
		$nugetConfig.configuration.AppendChild($packageSourcesNode) | Out-Null
	}

	if (-not $nugetConfig.configuration.packageSourceCredentials) {
		$credentialsNode = $nugetConfig.CreateElement("packageSourceCredentials")
		$nugetConfig.configuration.AppendChild($credentialsNode) | Out-Null
	}

	$existingSource = $nugetConfig.configuration.packageSources.add | Where-Object {
		$_.key -eq $SourceName
	}

	if ($existingSource) {
		$existingSource.value = $SourceUrl
	} else {
		$sourceNode = $nugetConfig.CreateElement("add")
		$sourceNode.SetAttribute("key", $SourceName)
		$sourceNode.SetAttribute("value", $SourceUrl)
		$nugetConfig.configuration.packageSources.AppendChild($sourceNode) | Out-Null
	}

	$existingCredentialNode = $nugetConfig.configuration.packageSourceCredentials.$SourceName

	if (-not $existingCredentialNode) {
		$existingCredentialNode = $nugetConfig.CreateElement($SourceName)
		$nugetConfig.configuration.packageSourceCredentials.AppendChild($existingCredentialNode) | Out-Null
	}

	$existingCredentialNode.RemoveAll()

	$usernameNode = $nugetConfig.CreateElement("add")
	$usernameNode.SetAttribute("key", "Username")
	$usernameNode.SetAttribute("value", "api-key")
	$existingCredentialNode.AppendChild($usernameNode) | Out-Null

	$passwordNode = $nugetConfig.CreateElement("add")
	$passwordNode.SetAttribute("key", "ClearTextPassword")
	$passwordNode.SetAttribute("value", "%$ApiKeyEnvVarName%")
	$existingCredentialNode.AppendChild($passwordNode) | Out-Null

	$nugetConfig.Save((Resolve-Path $NuGetConfigPath))

	Write-Host "Configured Telerik feed '$SourceName' in '$NuGetConfigPath'."
	Write-Host "Saved API key in user environment variable '$ApiKeyEnvVarName'."
	Write-Host "Restart your terminal/IDE so new processes can read the updated environment variable."
}
```

Example usage:

```powershell
Configure-TelerikNuGetSource -ApiKey "<telerik-api-key>"
```

## Changelog

### 1.1.0 - 2026-03-20

- Added skill package metadata: `required_binaries`, `author`, `homepage`, and `source`.
- Updated configure function to save API key as a user-level environment variable.
- Updated `nuget.config` credential handling to use environment variable expansion instead of hardcoded API key values.
- Added `version` field to frontmatter.