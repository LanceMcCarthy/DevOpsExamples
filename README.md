# Azure DevOps and GitHub Actions - Examples for Telerik and Kendo

This repository contains a rich set of CI-CD demos that show you how to use Azure DevOps and GitHub Actions to build your Telerik and Kendo powered applications.

Highlights

- Restore packages from the private Telerik NuGet server feed
- Build and enable license for Kendo Angular and Kendo React applications

## Status

| Project | Azure DevOps (pipeline type) | GitHub Actions |
|--------------|--------------------------|----------------------|
| ASP NET Blazor (.NET 5) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyBlazorApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47) (`classic`) | ![Build Web](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Web%20Application/badge.svg?branch=main) |
| WPF (.NET Framework) | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyWpfApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) (`classic`) | ![Build WPF](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg?branch=main) |
| Console (.NET 5) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) (`YAML`) | ![Build Console](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg?branch=main) |
| Xamarin.Forms | n/a | ![Build Xamarin.Forms](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Xamarin.Forms%20Applications/badge.svg?branch=main) |
| Angular | [![Build Angular](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) (`classic`) | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) |
| React | [![Build Kendo React](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20React)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=66) (`classic`) | [![Build React](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-react.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-react.yml) |

## Video Tutorial | NuGet Server

The following 4 minute video takes you though all the steps on adding a private NuGet feed as a Service Connection and consuming that service in three different pipeline setups.

[![YouTube tutorial](https://img.youtube.com/vi/rUWU2n6FwgA/0.jpg)](https://www.youtube.com/watch?v=rUWU2n6FwgA)

- [0:09](https://youtu.be/rUWU2n6FwgA?t=9) Add a Service connection to the Telerik server
- [1:14](https://youtu.be/rUWU2n6FwgA?t=74) Classic pipeline for .NET Core
- [1:47](https://youtu.be/rUWU2n6FwgA?t=107) Classic .NET Framework pipeline
- [2:25](https://youtu.be/rUWU2n6FwgA?t=145) YAML pipeline setup for .NET Core

## Troubleshooting

A common problem to run into is to think that the environment variable is the same thing as the GitHub Secret (or Azure DevOps pipeline variable). In this demo, I intentionally named the secrets a different name than the environment variable name so that it is easier for you to tell the difference.

However, I know that not everyone has the tiime to watch the video and just copy/paste the YAML. This will cause you to hit a roadblock because you missed the part about setting up the GitHub secret (or Azure DevOps pipeline variable). Here are a couple screenshots you can solve the issue and bounce :) 

In your YAML, you probably have done this:

![image](https://user-images.githubusercontent.com/3520532/104634697-f57e0480-566e-11eb-8b84-06fcf3ffe753.png)

That mean you must also have the secrets in your **Settings** > **Secrets** list

![image](https://user-images.githubusercontent.com/3520532/104634438-9cae6c00-566e-11eb-9a78-79d955247867.png)


 
