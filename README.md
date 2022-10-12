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

Related Blog Posts

- [DevOps and Telerik NuGet Packages](https://www.telerik.com/blogs/azure-devops-and-telerik-nuget-packages)
- [Announcing Telerik NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys)

## Build Statuses

The following tables list the status badges for the various pipelines and workflows. To keep things organized, each CI system has its own table.

### Azure DevOps

| Project | Azure DevOps (classic) | GitHub Actions | GitLab CI |
|---------|--------------|----------------|-----------|
| ASP.NET AJAX | [![Build CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AJAX%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=78) | [![Build AJAX Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml) |  |
| ASP.NET Core | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AspNetCore)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=80) | [![Build ASP.NET Core Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml) | n/a | 
| ASP.NET Blazor | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Blazor%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47)| [![Build Blazor Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WPF (net48) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | ![Build WPF](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg?branch=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WinForms (net48) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WinForms?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=79&branchName=main) | ![Build WinForms](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WinForms%20Application/badge.svg?branch=main) |  |
| Console | [![Build - YAML](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | ![Build Console](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg?branch=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| UWP |  | [![Build - CLASSIC](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml) |  |
| .NET MAUI | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) |  |
| Xamarin.Forms | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Xamarin.Forms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=68) | [![Build Xamarin.Forms Applications](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml) |  |
| Kendo Angular | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

> The Console, AJAX, and Blazor projects are built using both Azure Classic and YAML pipelines.

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


### Powershell: Update Package Source Dynamically

You could also dynamically update the credentials of a Package Source defined in your nuget.config file This is a good option when you do not want to use a `packageSourceCredentials` section that uses environment variables.

```powershell
# Updates a source named 'Telerik' in the nuget.config
dotnet nuget update source "Telerik" --source "https://nuget.telerik.com/v3/index.json" --configfile "src/nuget.config" --username '${{ secrets.MyTelerikEmail }}' --password '${{ secrets.MyTelerikPassword }}' --store-password-in-clear-text
```
 That command will look through the nuget.config for a package source with the key `Telerik` and then add/update the credentials for that source.

> The `--store-password-in-clear-text` switch is important. It does *not* mean the password is visible, rather it means that you're using the password text and not a custom encrypted variant. For more information, please visit https://docs.microsoft.com/en-us/nuget/reference/nuget-config-file#packagesourcecredentials

### Using Telerik NuGet Keys

You can use the same approach in the previous section. Everything is exactly the same, except you use `api-key` for the username and the NuGet key for the password.

Please visit the [Announcing NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys) blog post for more details how ot create the key and how to use it.

```powershell
dotnet nuget update source "Telerik" --source "https://nuget.telerik.com/v3/index.json" --configfile "src/nuget.config" --username 'api-key' --password '${{ secrets.MyNuGetKey }}' --store-password-in-clear-text
```

> IMPORTANT: Protect your key by storing it in a GitHub Secret, then use the secret's varible name in the command


