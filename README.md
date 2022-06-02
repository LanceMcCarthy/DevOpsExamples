# DevOps - Pipeline and Workflow Examples

This repository contains a rich set of CI-CD demos that show you how to use Azure DevOps and GitHub Actions to build your Telerik and Kendo powered applications in the following systems.

| System        | CI/CD file(s) | Status | 
|---------------|------------------|--------|
| Azure DevOps  | [azure-pipelines.yml](/blob/main/azure-pipelines.yml) | [Azure badges](/#azure-devops) |
| GitHub Actions | [.github/workflows](/.github/workflows) | [Actions badges](/#github-actions) |
| GitLab CI/CD   | [.gitlab-ci.yml](https://gitlab.com/LanceMcCarthy/DevOpsExamples/-/blob/main/.gitlab-ci.yml) | [GitLab badges](/#gitlab-ci-cd) |
| AppCenter | n/a | [AppCenter badges](/#microsoft-appcenter) |

These examples show you how to:

- Authenticate and restore NuGet packages from the Telerik NuGet server.
- Activate your Kendo UI license in your CI workflow.

## Build Statuses

The following tables list the status badges for the various pipelines and workflows. To keep things organized, each CI system has its own table.

### Azure DevOps

| Project | Main Branch | Pipeline type |
|---------|--------|---------------|
| ASP.NET Blazor (.NET 6) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyBlazorApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47) | classic |
| WPF & WinForms (.NET Framework) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | classic |
| Console (.NET 6) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | yaml |
| MAUI (.NET 6) | [![Build MAUI](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) | classic |
| Xamarin.Forms | [![Build Xamarin.Forms](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Xamarin.Forms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=68) | classic |
| Angular (React/Vue) | [![Build Angular](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) | classic |

### GitHub Actions

| Project | Branch: main |
|---------|------------|
| ASP.NET Blazor (.NET 6) | ![Build Web](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Web%20Application/badge.svg?branch=main) |
| WPF (.NET Framework) | ![Build WPF](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg?branch=main) |
| WinForms (.NET Framework) | ![Build WinForms](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WinForms%20Application/badge.svg?branch=main) |
| Console (.NET 6) | ![Build Console](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg?branch=main) |
| UWP | [![Build UWP Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml) |
| MAUI (.NET 6) | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) |
| Xamarin.Forms | [![Build Xamarin.Forms Applications](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml) |
| Angular (React/Vue) | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) |

### GitLab CI-CD

| Project | Main Branch |
|---------|------------|
| ASP.NET Blazor (.NET 5) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WPF (.NET Framework) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| Console (.NET 5) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| Angular (React/Vue) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

### Microsoft AppCenter

| Project | Main Branch |
|---------|-------------|
| Xamarin.Forms iOS | [![iOS](https://build.appcenter.ms/v0.1/apps/fb6ee8ef-11ce-43d8-8e55-cba537388483/branches/main/badge)](https://appcenter.ms) |
| Xamarin.Forms Android | [![Android](https://build.appcenter.ms/v0.1/apps/51ebbd36-58fe-4ebc-accd-0af37cbf6758/branches/main/badge)](https://appcenter.ms) |

> In AppCenter build settings, you set the environment variables defined in the nuget.config, `TELERIK_USERNAME` and `TELERIK_PASSWORD`. If the build is for Kendo, then you set the `KENDO_UI_LICENSE` environment variable.

## Videos

### Azure DevOps with Private NuGet Server

The following **4 minute** video takes you though all the steps on adding a private NuGet feed as a Service Connection and consuming that service in three different pipeline setups.

[![YouTube tutorial](https://img.youtube.com/vi/rUWU2n6FwgA/0.jpg)](https://www.youtube.com/watch?v=rUWU2n6FwgA)

- [0:09](https://youtu.be/rUWU2n6FwgA?t=9) Add a Service connection to the Telerik server
- [1:14](https://youtu.be/rUWU2n6FwgA?t=74) Classic pipeline for .NET Core
- [1:47](https://youtu.be/rUWU2n6FwgA?t=107) Classic .NET Framework pipeline
- [2:25](https://youtu.be/rUWU2n6FwgA?t=145) YAML pipeline setup for .NET Core

## Tips and Troubleshooting

### GitHub Actions: Using Secrets to Set Environment Variables

A common problem to run into is to think that the environment variable is the same thing as the GitHub Secret (or Azure DevOps pipeline variable). In this demo, I intentionally named the secrets a different name than the environment variable name so that it is easier for you to tell the difference.

However, I know that not everyone has the time to watch the video and just copy/paste the YAML instead. This will cause you to hit a roadblock because you missed the part about setting up the GitHub secret, Azure DevOps pipeline variable or . Here is a 2 screenshot crash-course on how to get back on track.

In your YAML, you probably have done this:

![image](https://user-images.githubusercontent.com/3520532/104634697-f57e0480-566e-11eb-8b84-06fcf3ffe753.png)

That mean you must also have the secrets in your **Settings** > **Secrets** list

![image](https://user-images.githubusercontent.com/3520532/104634438-9cae6c00-566e-11eb-9a78-79d955247867.png)

### Powershell: Restore Packages

If your nuget.config has a `packageSourceCredentials` section that uses environment variables for the values, you can also use Powershell to set those env variables using the pipeline secrets variables, than manually invoke the package restore.

```ps
# 1. Set the Env Variables being used in the nuget.config credentials using pipeline secrets (e.g., $(MyTelerikEmail) is a secret)
$env:TELERIK_USERNAME = '$(MyTelerikEmail)'
$env:TELERIK_PASSWORD ='$(MyTelerikPassword)'

# 2. Set the project file path and nuget.config file path
$myBlazorProjectFilePath = 'src/Web/MyBlazorApp/MyBlazorApp.csproj'
$myNugetConfigFilePath = 'src/nuget.config'

# 3. Restore the Telerik and nuget.org packages using the nuget.config file
dotnet restore $myBlazorProjectFilePath --configfile $myNugetConfigFilePath --runtime win-x86

# 4. Clear those variables when done (not required, but good practice)
$env:TELERIK_USERNAME = ''
$env:TELERIK_PASSWORD =''
```

### Powershell: Update Package Source Dynamically

You could also dynamically update the credentials of a Package Source defined in your nuget.config file This is a good option when you do not want to use a `packageSourceCredentials` section that uses environment variables.

```powershell
# Updates a source named 'Telerik' in the nuget.config
dotnet nuget update source Telerik --source https://nuget.telerik.com/v3/index.json --configfile src/nuget.config --username '$(MyTelerikEmail)' --password '$(MyTelerikPassword)' --store-password-in-clear-text
```
 That command will look through the nuget.config for a package source with the key `Telerik` and then add/update the credentials for that source.

> The `--store-password-in-clear-text` switch is important. It does *not* mean the password is visible, rather it means that you're using the password text and not a custom encrypted variant. For more information, please visit https://docs.microsoft.com/en-us/nuget/reference/nuget-config-file#packagesourcecredentials


