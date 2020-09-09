# DevOpsExamples
A repository to show how to use a private NuGet feed in both Azure DevOps and GitHub Actions.

## Status

| Project | Azure Pipelines | GitHub Actions |
|--------------|--------------------------|----------------------|
| Blazor - ASP.NET Core | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyBlazorApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47) Classic pipeline | ![Build Web Application](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Web%20Application/badge.svg) |
| WPF -  .NET Framework | [![Build status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/MyWpfApp%20Build)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) Classic pipeline | ![Build WPF Application](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg) |
| Console - .NET Core | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=master)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=master) YAML pipeline | ![Build Console App](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg) |

## YouTube Tutorial

The following 4 minute video takes you though all the steps on adding a private NuGet feed as a Service Connection and consuming that service in three different pipeline setups. 

[![YouTube tutorial](https://img.youtube.com/vi/rUWU2n6FwgA/0.jpg)](https://www.youtube.com/watch?v=rUWU2n6FwgA)

* Adding a Service connection at [0:09](https://youtu.be/rUWU2n6FwgA?t=9) 
* Classic pipeline for .NET Core at [1:14](https://youtu.be/rUWU2n6FwgA?t=74) 
* Classic .NET Framework pipeline at [1:47](https://youtu.be/rUWU2n6FwgA?t=107)
* YAML pipeline setup for .NET Core at [2:25](https://youtu.be/rUWU2n6FwgA?t=145)
