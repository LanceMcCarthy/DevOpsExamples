# DevOps - Pipeline and Workflow Examples

This repository contains a rich set of CI-CD demos where I show you how to:

- Connect to private nuget feeds; Azure, GitHub packages, and custom (eg Telerik).
- Build .NET apps and publish to a container registry; Docker, Azure, GitHub, etc.

Although I use Telerik's NuGet server in these demos, the approach works for any private feed; just substitute your source and credentials instead.

## Table of Contents
- [CI Systems](https://github.com/LanceMcCarthy/DevOpsExamples#ci-systems)
- [Build Badges](https://github.com/LanceMcCarthy/DevOpsExamples#badges)
- [Docker Examples](https://github.com/LanceMcCarthy/DevOpsExamples#docker-examples)
- [Video: Authenticating in Azure DevOps](https://github.com/LanceMcCarthy/DevOpsExamples#videos)
- [Tips and Troubleshooting](https://github.com/LanceMcCarthy/DevOpsExamples#tips-and-troubleshooting)
  - [Walkthrough: Use GitHub Secrets](https://github.com/LanceMcCarthy/DevOpsExamples#github-actions-using-secrets-to-set-environment-variables)
  - [Example: Update package source dynamically](https://github.com/LanceMcCarthy/DevOpsExamples#powershell-update-package-source-dynamically)
  - [Example: Using Telerik NuGet Keys](https://github.com/LanceMcCarthy/DevOpsExamples#using-telerik-nuget-keys)
  - [Dockerfile: Using Secrets](https://github.com/LanceMcCarthy/DevOpsExamples#dockerfile-using-secrets)
  - [Telerik License Approaches](https://github.com/LanceMcCarthy/DevOpsExamples#telerik-license-approaches)
    - [Deployment Key in GitHub Actions](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-github-actions)
    - [Deployment Key in GitLab CI](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-gitlab-ci)
    - [Deployment Key in Azure YAML Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-azure-yaml-pipeline)
    - [Deployment Key in Azure Classic Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-azure-classic-pipeline)
- Related Blog Posts
  - [Blog: DevOps and Telerik NuGet Packages](https://www.telerik.com/blogs/azure-devops-and-telerik-nuget-packages)
  - [Blog: Announcing Telerik NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys)

> [!IMPORTANT]
> Some commerical Telerik packages are now available on nuget.org! If you are using any of these packages, you can restore using only the default nuget.org => `Telerik.UI.for.Blazor` `Telerik.UI.for.Maui` `Telerik.Documents.*`

## CI Systems

| System        | CI/CD file(s) |
|---------------|------------------|
| GitHub Actions | [.github/workflows](/.github/workflows) |
| Azure DevOps (YAML) | [azure-pipelines.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/azure-pipelines.yml) |
| Azure DevOps (classic) | Click badge |
| GitLab CI/CD  | [.gitlab-ci.yml](https://gitlab.com/LanceMcCarthy/DevOpsExamples/-/blob/main/.gitlab-ci.yml) ↗|
| Tekton in Kuberbetes | [tekton-task-run.yaml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/tekton-task-run.yaml) |

## Badges

| Project | GitHub Actions | Azure Pipelines YAML | Azure DevOps Classic | GitLab CI |
|---------|----------------|----------------------|----------------------|-----------|
| **.NET MAUI** | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildMauiApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **ASP.NET Core** | [![Build ASP.NET Core Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAspNetCoreApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FBuild%20Kendo%20Angular?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **ASP.NET Blazor** | [![Build Blazor Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildBlazorApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FBuild%20Blazor%20App?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=47&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WPF** | [![WPF (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildWpfApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WinForms** | [![WinForms (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildWpfApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WinForms?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=79&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **Console** | [![Console (.NET)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml) | [![Build Status AKEYLESS](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildConsoleApp_Akeyless)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | - | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WinUI** | [![Build WinUI3 Project](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildWinUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | - | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **Kendo Angular** | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAngularAppWithVariables)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FBuild%20Kendo%20Angular?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=65&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **ASP.NET AJAX** | [![Build AJAX Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAjaxApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FBuild%20AJAX%20App?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=78&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

> [!TIP]
> There are extra AzDO Classic pipelines examples for Blazor.
> 
> Using Azure KeyVault secrets [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FBlazor%20-%20KeyVault%20Secrets%20NuGet%20Source?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=69&branchName=main)

## Docker Examples

These examples show how to build and publish container images. While they publish to Docker Hub, it works for any image registry.

| Image | GitHub Action | Dockerfile | Running Site |
|-------|---------------|------------|--------------|
| `mykendoapp` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-kendo.yml/badge.svg)]([https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-blazor.yml](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-kendo.yml)) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/Kendo/angular_demo/Dockerfile) | [live demo](https://kendo.dvlup.com/) |
| `myblazorapp` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-blazor.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/Blazor/MyBlazorApp/Dockerfile) | [live demo](https://blazor-reporting.dvlup.com/) |
| `aspnetcore-reporting-from-msftbase` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile_MSRuntimeBase) | [live demo](https://aspnetcore-reporting.dvlup.com/) |
| `aspnetcore-reporting-from-centosbase` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile_CentOS) | PoC only |


> [!IMPORTANT] 
> When creating a container, map port 8080 to the host. For example  `docker run -d -p 88:8080 lancemccarthy/myblazorapp:latest` and then open http://localhost:88

## Videos

### Azure DevOps with Telerik NuGet Server

The following **4 minute** video takes you though all the steps on adding a private NuGet feed as a Service Connection and consuming that service in three different pipeline setups.

[![YouTube tutorial](https://img.youtube.com/vi/rUWU2n6FwgA/0.jpg)](https://www.youtube.com/watch?v=rUWU2n6FwgA)

- [0:09](https://youtu.be/rUWU2n6FwgA?t=9) Add a Service connection to the Telerik server
- [1:14](https://youtu.be/rUWU2n6FwgA?t=74) Classic pipeline for .NET Core
- [1:47](https://youtu.be/rUWU2n6FwgA?t=107) Classic .NET Framework pipeline
- [2:25](https://youtu.be/rUWU2n6FwgA?t=145) YAML pipeline setup for .NET Core

> [!IMPORTANT]
> The recording has some outdated information, take the following updates into consideration when watching:
> - Use the v3 server address `https://nuget.telerik.com/v3/index.json` 
> - Use an API key credential if your telerik.com account is SSO (see [Announcing NuGet Keys](https://www.telerik.com/blogs/announcing-nuget-keys)).

## Tips and Troubleshooting

### GitHub Actions: Using Secrets to Set Environment Variables

If you have environment variable placeholders in your nuget.config file, you can easily set them using GitHub Secrets. For example, let's say in your packageSourceCredentials, you have the following the environment variable placeholders `%TELERIK_USERNAME%` and `%TELERIK_PASSWORD%`

```xaml
﻿<?xml version="1.0" encoding="utf-8"?>
<configuration>
...
  <packageSourceCredentials>
    <Telerik_v3_Feed>
      <add key="Username" value="%TELERIK_USERNAME%" />
      <add key="ClearTextPassword" value="%TELERIK_PASSWORD%" />
    </Telerik_v3_Feed>
  </packageSourceCredentials>
  ...
</configuration>
```

You can directly set those vars on the same step which you invoke the `dotnet restore/build/publish` command. For example, here I use an API key from my GitHub Actions Secrets for credentials

```yaml
    - name: Restore NuGet Packages
      run: dotnet restore src/MyProject.csproj --configfile src/nuget.config
      env:
        TELERIK_USERNAME: "api-key"
        TELERIK_PASSWORD: ${{secrets.TELERIK_API_KEY}}
```

> [!TIP]
> This is also very useful for Dependabot runs. You can set a Dependabot secret (in the repo settings) and it will be able to restore packages during checks that were triggered by Dependabot.

### Powershell: Adding or Updating Package Source Dynamically

#### Option 1 - Update existing package source

You could also dynamically update the credentials of a Package Source defined in your nuget.config file This is a good option when you do not want to use a `packageSourceCredentials` section that uses environment variables.

```powershell
# Setting credentials for the 'Telerik_v3_Feed' defined in the nuget.config file.
dotnet nuget update source "Telerik_v3_Feed" -s "https://nuget.telerik.com/v3/index.json" -u '${{secrets.MyTelerikEmail}}' -p '${{secrets.MyTelerikPassword}}' --configfile "src/nuget.config" --store-password-in-clear-text
```
That command will look through the nuget.config for a package source with the key `Telerik_v3_Feed` and then add/update the credentials for that source.

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
dotnet nuget update source "Telerik_v3_Feed" -s "https://nuget.telerik.com/v3/index.json" -u 'api-key' -p '${{secrets.MyNuGetKey}}' --configfile "src/nuget.config" --store-password-in-clear-text
```

> [!CAUTION]
> Protect your key by storing it in a GitHub Secret, then use the secret's ID in the command.

### Dockerfile: Using Secrets

When using a Dockerfile to build a .NET project that uses the Telerik NuGet server, you'll need a safe and secure way to handle your NuGet crednetials and your Telerik License Key. This can be done my mounting a Docker secret.

In your GitHub Actions workflow, you can define and set docker secrets in the docker build step. In the following example, notice how we are setting two docker secrets (`nuget-sec` and `license-sec`) using the values from GitHub secrets.

```yaml
    - uses: docker/build-push-action@v3
      with:
        secrets: |
          nuget-sec=${{secrets.MY_NUGET_KEY}}
          license-sec=${{secrets.MY_TELERIK_LICENSE_KEY}}
```

Now, inside the Dockerfile, you can mount and use those secrets. See Stage 2 in the following example:

```Dockerfile
### STAGE 1 ###
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

### STAGE 2 ###
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
# STEP 1. Mount the 'nuget-sec' secret, then:
# a. add the Telerik package source
# b. restore packages
RUN --mount=type=secret,id=nuget-sec,required \
    dotnet nuget add source 'https://nuget.telerik.com/v3/index.json' -n "Telerik_v3_Feed" -u "api-key" -p "$(cat /run/secrets/nuget-sec)" --store-password-in-clear-text \
    && \
    dotnet restore "MyBlazorApp.csproj"
# STEP 2. Mount the "license-sec" secret, then:
# a. create the license file
# b. build the project
# c. delete the file so you don't distribute it in your image (important!)
RUN --mount=type=secret,id=license-key,required \
    mkdir -p ~/.telerik  && echo "$(cat /run/secrets/license-sec)" > ~/.telerik/telerik-license.txt \
    && \
    dotnet publish "Researcher.Web/Researcher.Web.csproj" -o /app/publish /p:UseAppHost=false --no-restore --self-contained false \
    && \
    rm -rf ~/.telerik

### STAGE 3 ###
# Build final from base, but copy ONLY THE PUBLISH ARTIFACTS from stage 2
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyBlazorApp.dll"]
```

> [!CAUTION]
> Pay attention to whether or not you are including any secrets in your final image. You can run your container to explore the files (and env vars in Exec) to make sure.

### Telerik License Approaches

With introduction of [Deployment Keys](https://www.telerik.com/account/downloads/deployment-keys), you can now generate a small license key with only the products you need in it. 

This much smaller key value will meet even the smallest of CI system's variable size limits
You can now generate a very small JWT that contains only the products you need, drastically reducing the key size.

1. Go to https://www.telerik.com/account/downloads/deployment-keys
2. Click "Add Application" and select only the products that the project uses
    - <img width="350" alt="classic pipeline secrets" src="https://github.com/user-attachments/assets/fb22efda-2e3b-4a5d-aa22-1424e4a3835a" />
3. Once saved, click "COPY KEY" and paste it into a secret pipeline variable (e.g. `BLAZOR_REPORTING_DEPLOYMENT_KEY`)
4. Set the `TELERIK_LICENSE` environment variable at build time. Here are some examples:
    - [GitHub Actions](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-github-actions)
    - [GitLab CI](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-gitlab-ci)
    - [Azure YAML Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-azure-yaml-pipeline)
    - [Azure Classic Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples#deployment-key-in-azure-classic-pipeline)

> [!CAUTION]
> A **pipeline** variable is not the same thing as an **environment** variable. Most CI systems do not automatically make variables available in the environment unless they're explicitly set as an env variable.
> Please pay close attention to the difference between a pipeline/CI variable and an environment variable in each of the following examples.

#### Deployment Key in GitHub Actions

1. In the repo's Actions settings, create a new secret named `PRODUCTNAME_DEPLOYMENT_KEY` with the value in your clipboard
2. In the YAML, set the `TELERIK_LICENSE` environment variable to `${{secrets.PRODUCTNAME_DEPLOYMENT_KEY}}`.

```yaml
  - run: dotnet publish MyApp.csproj -o /app/publish
    env:
      TELERIK_LICENSE: ${{secrets.PRODUCTNAME_DEPLOYMENT_KEY}}
```

#### Deployment Key in GitLab CI

1. Go into the project's settings, then CI, and create a `PRODUCTNAME_DEPLOYMENT_KEY` secret.
2. In the YAML, set the set the `TELERIK_LICENSE` environment variable to `$PRODUCTNAME_DEPLOYMENT_KEY`.

```yaml
build-blazor-app:
  tags:
    - saas-windows-medium-amd64
  variables:
    TELERIK_LICENSE: $PRODUCTNAME_DEPLOYMENT_KEY
  script:
    - |
      dotnet publish MyApp.csproj -o /app/publish
      ...
```

#### Deployment Key in Azure YAML Pipeline

1. Open the Variables pane in the YAML editor, and create a new secret pipeline variable `PRODUCTNAME_DEPLOYMENT_KEY`
2. In the YAML, set the `TELERIK_LICENSE` environment variable to `$(PRODUCTNAME_DEPLOYMENT_KEY)`

```yaml
  - powershell: dotnet publish MyApp.csproj -o /app/publish
    env:
      TELERIK_LICENSE: $(PRODUCTNAME_DEPLOYMENT_KEY) # AzDO pipeline **secret** variable
```

#### Deployment Key in Azure Classic Pipeline

1. Similar to YAML pipeline, create the pipeline variable for the deployment key. For example, in this screenshot I have added a `TK_BLAZOR_DEPLOYMENT_KEY` secret variable

<img width="875" height="380" alt="image" src="https://github.com/user-attachments/assets/f877a3a3-30b4-401b-9de2-410c650206f9" />

2. Now that pipeline variable is available to be used to set the `TELERIK_LICENSE` environment variable. Depending on what kind of task you're using, choose the appropriate option

- Option A: If the pipeline task allows you to directly set environment variables, you can do this
    - <img width="800" alt="image" src="https://github.com/user-attachments/assets/62a4f975-0000-499c-8c6e-5f0ca15a19b6" />
- Option B: If the task doesn't have an Environment Variables input section, then you need export the env yourself in an earlier step.
    1. Add a new PowerShell task at **the top** of the pipeline, and select inline script, use th
    2. Use `Write-Host "##vso[task.setvariable variable=TELERIK_LICENSE;issecret=true]$(PRODUCTNAME_DEPLOYMENT_KEY)"`
       <img width="800" alt="image" src="https://github.com/user-attachments/assets/f3209e2f-5e8e-40d1-ac2b-0d40a991947e" />
    4. Now the `TELERIK_LICENSE` env var will be available to subsequent steps.

