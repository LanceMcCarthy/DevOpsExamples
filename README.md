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
| Azure DevOps (YAML) | [azure-pipelines.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/azure-pipelines.yml) |
| Azure DevOps (classic) | click build badge |
| GitLab CI/CD  | [.gitlab-ci.yml](https://gitlab.com/LanceMcCarthy/DevOpsExamples/-/blob/main/.gitlab-ci.yml) ↗|

## Badges

| Project | GitHub Actions | Azure DevOps | GitLab CI |
|---------|--------------|----------------|-----------|
| .NET MAUI | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) |  |
| ASP.NET Core | [![Build ASP.NET Core Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AspNetCore)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=80) |  | 
| ASP.NET Blazor | [![Build Blazor Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Blazor%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WPF (`net48`) | [![WPF (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WinForms (`net48`) | [![WinForms (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WinForms?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=79&branchName=main) |  |
| Console | [![Console (.NET)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml) | [![Build - YAML](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/LanceMcCarthy.DevOpsExamples?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| WinUI 3 | [![Build WinUI3 Project](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml) | | |
| Kendo Angular | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20Kendo%20Angular)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| ASP.NET AJAX (`net48`) | [![Build AJAX Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml) | [![Build CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20AJAX%20App)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=78) |  |


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


### Powershell: Adding or Updating Package Source Dynamically

#### Option 1 - Update existing package source

You could also dynamically update the credentials of a Package Source defined in your nuget.config file This is a good option when you do not want to use a `packageSourceCredentials` section that uses environment variables.

```powershell
# Updates a source named 'Telerik' in the nuget.config
dotnet nuget update source "Telerik" -s "https://nuget.telerik.com/v3/index.json" --configfile "src/nuget.config" -u '${{secrets.MyTelerikEmail}}' -p '${{secrets.MyTelerikPassword}}' --store-password-in-clear-text
```
That command will look through the nuget.config for a package source with the key `Telerik` and then add/update the credentials for that source.

#### Option 2 - Add a new package source

The other approach is a bit simpler because you dont need a custom nuget.config file. Just use the dotnet nuget add source command

```powershell
dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "AddedTelerikServer" -u ${{secrets.MyTelerikEmail}} -p ${{secrets.MyTelerikPassword}} --store-password-in-clear-text
```

> The `--store-password-in-clear-text` switch is important. It does *not* mean the password is visible, rather it means that you're using the password text and not a custom encrypted variant. For more information, please visit https://docs.microsoft.com/en-us/nuget/reference/nuget-config-file#packagesourcecredentials

### Using Telerik NuGet Keys

You can use the same approach in the previous section. Everything is exactly the same, except you use `api-key` for the username and the NuGet key for the password.

Please visit the [Announcing NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys) blog post for more details how ot create the key and how to use it.

```powershell
dotnet nuget update source "Telerik" --source "https://nuget.telerik.com/v3/index.json" --configfile "src/nuget.config" --username 'api-key' --password '${{ secrets.MyNuGetKey }}' --store-password-in-clear-text
```

> IMPORTANT: Protect your key by storing it in a GitHub Secret, then use the secret's varible name in the command

### Dockerfile: Using Secrets

When using a Dockerfile to build a .NET project that uses the Telerik NuGet server, you'll need a safe and secure way to handle your NuGet crednetials and your Telerik License Key. This can be done my mounting a Docker secret.

In your GitHub Actions workflow, you can define and set docker secrets in the docker build step. Take a look at the following example, we using GitHub secrest to set two docker secrets `telerik-nuget-key=${{secrets.MY_NUGET_KEY}}` and `telerik-license-key=${{secrets.MY_TELERIK_LICENSE_KEY}}`.

```yaml
    - uses: docker/build-push-action@v3
      with:
        secrets: |
          telerik-nuget-key=${{secrets.MY_NUGET_KEY}}
          telerik-license-key=${{secrets.MY_TELERIK_LICENSE_KEY}}
```

Now, inside the Dockerfile's `build` stage, you can mount and use those secrets. See **Stage #2** in this example

```Dockerfile
### STAGE 1 ###
# Create our base image from the aspnet image, and prep any neccessary settings
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

### STAGE 2 ###
# Compile the project and create production-ready artifacts
# ⚠️important⚠️ only use these secrests in the build stage so you dont leak them in your final image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/MyApp
COPY . .

# Step 1 - Restore NuGet packages
# In this command, we do three things
#   1. Mount the telerik-nuget-key secret
#   2. Add the Telerik NuGet server to the package sources (usign the telerik-nuget-key for password)
RUN --mount=type=secret,id=telerik-nuget-key \
    dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "TelerikNuGetServer" -u "api-key" -p $(cat /run/secrets/telerik-nuget-key) --store-password-in-clear-text

# 2. Restore NuGet packages
RUN dotnet restore "MyApp.csproj"

# Step 3 - Build the project
# In this command, we do two things:
#   1. We set the environment var 'TELERIK_LICENSE' using the 'telerik-license-key' docker secret
#   2. Run the dotnet publish command, which compiles and  the project in release mode
RUN --mount=type=secret,id=telerik-license-key,env=TELERIK_LICENSE \
    dotnet publish "MyApp.csproj" -o /app/publish /p:UseAppHost=false --self-contained false


### STAGE 3 ###
# Build the final image from the base, but copy the pubilsh artifacts from the intermediate stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
```


**Important**: *Do not* set the variables or license file in the `base` or `final` stage, you'll leak your secrets in the final image. Please [visit the complete Dockerfile](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile) and [the workflow](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/.github/workflows/main_build-aspnetcore.yml).
