# DevOps - Pipeline and Workflow Examples

This repository contains a rich set of CI-CD demos where I show you how to:

- Connect to private nuget feeds; Azure, GitHub packages, and custom (eg Telerik).
- Build .NET apps and publish to a container registry; Docker, Azure, GitHub, etc.

Although I use Telerik's NuGet server because I have a license, these demos are good for any private feed type; just use your source URL and credentials instead!

## Table of Contents
- [CI Systems](https://github.com/LanceMcCarthy/DevOpsExamples#ci-systems)
- [Build Badges](https://github.com/LanceMcCarthy/DevOpsExamples#badges)
- [Videos](https://github.com/LanceMcCarthy/DevOpsExamples#videos)
  - [Authenticating in Azure DevOps](https://github.com/LanceMcCarthy/DevOpsExamples#azure-devops-with-telerik-nuget-server)
- [Tips and Troubleshooting](https://github.com/LanceMcCarthy/DevOpsExamples#tips-and-troubleshooting)
  - [Walkthrough: Use GitHub Secrets](https://github.com/LanceMcCarthy/DevOpsExamples#github-actions-using-secrets-to-set-environment-variables)
  - [Example: Update package source dynamically](https://github.com/LanceMcCarthy/DevOpsExamples#powershell-update-package-source-dynamically)
  - [Example Using Telerik NuGet Keys](https://github.com/LanceMcCarthy/DevOpsExamples#using-telerik-nuget-keys)
  - [Dockerfile: Using Secrets](https://github.com/LanceMcCarthy/DevOpsExamples#dockerfile-using-secrets)
- Related Blog Posts
  - [Blog: DevOps and Telerik NuGet Packages](https://www.telerik.com/blogs/azure-devops-and-telerik-nuget-packages)
  - [Blog: Announcing Telerik NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys)

## CI Systems

| System        | CI/CD file(s) |
|---------------|------------------|
| GitHub Actions | [.github/workflows](/.github/workflows) |
| GitLab CI/CD  | [.gitlab-ci.yml](https://gitlab.com/LanceMcCarthy/DevOpsExamples/-/blob/main/.gitlab-ci.yml) ↗|
| Azure DevOps - Classic | click a build badge |
| Azure DevOps - YAML | [azure-pipelines.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/azure-pipelines.yml) |

## Badges

| Project | Azure DevOps | GitHub Actions | GitLab CI |
|---------|--------------|----------------|-----------|
| ASP.NET AJAX | [![Build CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AJAX%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=78) | [![Build AJAX Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml) |  |
| ASP.NET Core | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AspNetCore)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=80) | [![Build ASP.NET Core Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml) | n/a | 
| ASP.NET Blazor | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Blazor%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47)| [![Build Blazor Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WPF (net48) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | ![Build WPF](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WPF%20Application/badge.svg?branch=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WinForms (net48) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WinForms?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=79&branchName=main) | ![Build WinForms](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20WinForms%20Application/badge.svg?branch=main) |  |
| Console | [![Build - YAML](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | ![Build Console](https://github.com/LanceMcCarthy/DevOpsExamples/workflows/Build%20Console%20App/badge.svg?branch=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| UWP | [![Build - YAML](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build - CLASSIC](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-uwp.yml) |  |
| WinUI 3 |  | [![Build WinUI3 Project](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml) |  |
| .NET MAUI | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) |  |
| Xamarin.Forms | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Xamarin.Forms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=68) | [![Build Xamarin.Forms Applications](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-xamarin.yml) |  |
| Kendo Angular | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

### Bonus Notes

- Docker and DockerHub integration:
    - The `workflows/main_build-aspnetcore.yml` uses a Dockerfile to build and publish a Linux image to DockerHub => [lancemccarthy/myaspnetcoreapp](https://hub.docker.com/r/lancemccarthy/myaspnetcoreapp).
        - Ex. `docker run -d  -p 8080:8080 lancemccarthy/myaspnetcoreapp:latest`
        - Ex. `docker run -d  -p 8080:8080 lancemccarthy/myblazorapp:latest`
    - For a real-world example, visit [Akeyless Web Target's docker-publish.yml](https://github.com/LanceMcCarthy/akeyless-web-target/blob/main/.github/workflows/docker-publish.yml), which builds and publishes the [lancemccarthy/secretsmocker](https://hub.docker.com/r/lancemccarthy/secretsmocker) container image to Docker Hub.
        - Ex. `docker run -d  -p 8080:80 lancemccarthy/secretsmocker:latest`
- Azure DevOps: All statuses are for classic pipelines, except the `Console` project, which uses Azure DevOps YAML pipelines.

## Videos

### Azure DevOps with Telerik NuGet Server

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

### Dockerfile: Using Secrets
When using a Dockerfile to build a .NET project that uses the Telerik NuGet server, you'll need a safe and secure way to handle your crednetials. This can be done my mounting a Docker secret, which is a 1-liner in theDockerfile. Let's walkthrough through the highlights.

In your GitHub Actions workflow, you can set a secret in the same step that you build/publish the container. In the following YAML, notice we're using a GitHub Actions Secret to set a Docker secret: `telerik_key=${{ secrets.TELERIK_NUGET_KEY }}`

```yaml
    - uses: docker/build-push-action@v3
      with:
        secrets: |
          telerik_key=${{ secrets.TELERIK_NUGET_KEY }}
     ...
```

Now, insdie the Dockerfie itself, we can mount that secret:

```shell
# Here we use a docker secret to update the 'Telerik_Feed' package source, then restore then build
RUN --mount=type=secret,id=telerik_key \
  echo $(cat /run/secrets/telerik_key)
```

Now that the secret's value is available (`/run/secrets/telerik_key` in this case), it can be used in subsequent dotnet commands. For example here, I update the Telerik package source's credentials.

```shell
dotnet nuget update source "Telerik_Feed" -s "https://nuget.telerik.com/v3/index.json" -u "api-key" -p $(cat /run/secrets/telerik_key) --configfile "./NuGet.Config" --store-password-in-clear-text \
```

For a complete demo, [see the complete Dockerfile](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile) and [the complete workflow](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/.github/workflows/main_build-aspnetcore.yml).
