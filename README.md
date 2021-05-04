# DevOps - Pipeline and Workflow Examples

This repository contains a rich set of CI-CD demos that show you how to use Azure DevOps and GitHub Actions to build your Telerik and Kendo powered applications in the following systems.

These examples show you how to:

- Authenticate and restore NuGet packages from the Telerik NuGet server.
- Activate your Kendo UI Angular/React/Vue license prior to npm build.

With examples for each of the following CI-CD systems:

- **Azure DevOps**
  - View the yaml pipeline config in [azure-pipelines.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/azure-pipelines.yml).
  - View the classic pipelines in [this repo's Azure DevOps portal](https://dev.azure.com/lance/DevOps%20Examples/_build).
  - Skip down to the [pipeline status table](https://github.com/LanceMcCarthy/DevOpsExamples#azure-devops).
- **GitHub Actions**
  - View the Workflow files in the [.github/workflows](https://github.com/LanceMcCarthy/DevOpsExamples/tree/main/.github/workflows) folder.
  - Skip down to the [Actions status table](https://github.com/LanceMcCarthy/DevOpsExamples#github-actions).
- **GitLab CI/CD**
  - View the pipeline config in [.gitlab-ci.yml](https://gitlab.com/LanceMcCarthy/DevOpsExamples/-/blob/main/.gitlab-ci.yml) (this will take you to GitLab).
  - Skip down to the [pipeline status table](https://github.com/LanceMcCarthy/DevOpsExamples#gitlab-ci-cd).
- **AppCenter**
  - Skip down to the [build status table](https://github.com/LanceMcCarthy/DevOpsExamples#microsoft-appcenter).

## Build Status

The following tables list the status badges for the various pipelines and workflows. To keep things organized, each CI system has its own table.

### Azure DevOps

| Project | Main Branch | Pipeline type |
|---------|--------|---------------|
| ASP.NET Blazor (.NET 5) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyBlazorApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47) | classic |
| WPF (.NET Framework) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyWpfApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | classic |
| Console (.NET 5) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | yaml |
| Xamarin.Forms | [![Build Xamarin.Forms](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Xamarin.Forms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=68) | classic |
| Angular | [![Build Angular](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) | classic |
| React | [![Build Kendo React](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20React)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=66) | classic |
| Vue | [![Build Kendo Vue](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Vue)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=67) | classic |

### GitHub Actions

| Project | Main Branch |
|---------|------------|
| ASP.NET Blazor (.NET 5) | ![Build Web](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Web%20Application/badge.svg?branch=main) |
| WPF (.NET Framework) | ![Build WPF](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg?branch=main) |
| Console (.NET 5) | ![Build Console](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg?branch=main) |
| Xamarin.Forms | ![Build Xamarin.Forms](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Xamarin.Forms%20Applications/badge.svg?branch=main) |
| Angular | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) |
| React | [![Build React](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-react.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-react.yml) |
| Vue | [![Build Vue Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-vue.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-vue.yml) |

### GitLab CI-CD

| Project | Main Branch |
|---------|------------|
| ASP.NET Blazor (.NET 5) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WPF (.NET Framework) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| Console (.NET 5) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| Angular | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| React | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| Vue | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

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

## Troubleshooting

A common problem to run into is to think that the environment variable is the same thing as the GitHub Secret (or Azure DevOps pipeline variable). In this demo, I intentionally named the secrets a different name than the environment variable name so that it is easier for you to tell the difference.

However, I know that not everyone has the tiime to watch the video and just copy/paste the YAML instead. This will cause you to hit a roadblock because you missed the part about setting up the GitHub secret, Azure DevOps pipeline variable or . Here is a 2 screenshot crash-course on how to get back on track.

In your YAML, you probably have done this:

![image](https://user-images.githubusercontent.com/3520532/104634697-f57e0480-566e-11eb-8b84-06fcf3ffe753.png)

That mean you must also have the secrets in your **Settings** > **Secrets** list

![image](https://user-images.githubusercontent.com/3520532/104634438-9cae6c00-566e-11eb-9a78-79d955247867.png)
