# DevOps - Pipeline and Workflow Examples

This repository contains a rich set of CI-CD demos where I show you how to:

- Connect to private nuget feeds; Azure, GitHub packages, and custom (eg Telerik).
- Build .NET apps and publish to a container registry; Docker, Azure, GitHub, etc.

Although I use Telerik's NuGet server because I have a license, these demos are good for any private feed type; just use your source URL and credentials instead!

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
| **.NET MAUI** | [![MAUI main](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml/badge.svg?branch=main)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-maui.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20MAUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=72) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **ASP.NET Core** | [![Build ASP.NET Core Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-aspnetcore.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAspNetCoreApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) | 
| **ASP.NET Blazor** | [![Build Blazor Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-blazor.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildBlazorApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WPF** (`net48`) | [![WPF (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-wpf.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WPF%20and%20WinForms)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=46) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WinForms** (`net48`) | [![WinForms (.NET Framework)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winforms.yml) | [![Build - CLASSIC](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status/Build%20WinForms?branchName=main)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=79&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **Console** | [![Console (.NET)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-console.yml) | [![Build Status AKEYLESS](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildConsoleApp_Akeyless)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **WinUI 3** | [![Build WinUI3 Project](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-winui.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildWinUI)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **Kendo Angular** | [![Build Angular](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-angular.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAngularAppWithVariables)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |
| **ASP.NET AJAX** (`net48`) | [![Build AJAX Application](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_build-ajax.yml) | [![Build Status](https://dev.azure.com/lance/DevOps%20Examples/_apis/build/status%2FLanceMcCarthy.DevOpsExamples?branchName=main&jobName=BuildAjaxApp)](https://dev.azure.com/lance/DevOps%20Examples/_build/latest?definitionId=45&branchName=main) | [![Build status](https://gitlab.com/LanceMcCarthy/DevOpsExamples/badges/main/pipeline.svg)](https://gitlab.com/LanceMcCarthy/DevOpsExamples) |

> All Azure DevOps status badges are for classic pipelines, except the `Console` project, which uses Azure DevOps YAML pipelines.

## Docker Examples

This repo also contains examples on how to build and publish a Telerik powered .NET project as a container image. The image names below are published to the `lancemccarthy` Docker Hub user, but the approach also works for any container registry.

| Image | GitHub Action | Dockerfile |
|--------------|---------------|------------|
| `aspnetcore-reporting-from-centosbase` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile_CentOS "MyAspNetCoreApp/Dockerfile_CentOS") |
| `aspnetcore-reporting-from-msftbase` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-aspnetcore.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/AspNetCore/MyAspNetCoreApp/Dockerfile_MSRuntimeBase "MyAspNetCoreApp/Dockerfile_MSRuntimeBase") |
| `myblazorapp` | [![](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-blazor.yml/badge.svg)](https://github.com/LanceMcCarthy/DevOpsExamples/actions/workflows/main_docker-blazor.yml) | [link](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/src/Blazor/MyBlazorApp/Dockerfile "MyBlazorApp/Dockerfile") |

> [!NOTE] 
> When creating a container, forward port 8080 to the host. For example:
> 1. Run `docker run -d -p  9999:8080 lancemccarthy/myblazorapp:latest`
> 2. Visit site on http://localhost:9999

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

Depending on how you're building our code, there are several ways to introduce the Telerik License Key at the right time for the build. Let me show you two; variable and file.

- [Approach 1 - Using an Environment Variable](https://github.com/LanceMcCarthy/DevOpsExamples?tab=readme-ov-file#approach-1---using-a-variable)
- [Approach 2 - Using a License File](https://github.com/LanceMcCarthy/DevOpsExamples?tab=readme-ov-file#approach-2---using-a-file)
  - [In a YAML Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples?tab=readme-ov-file#yaml-pipeline)
  - [In a Classic Pipeline](https://github.com/LanceMcCarthy/DevOpsExamples?tab=readme-ov-file#classic-pipeline)

#### Approach 1 - Using a Variable

This is by far the easiest and safest way. You can use a secret (GitHub Action secret or AzDO Variable secret) and set the `TELERIK_LICENSE` environment variable before the project is compiled.

In a YAML workflow/pipeline, you can set the environment variable at the beginning of the job or on a step that needs it.

GH Actions
```yaml
  - run: dotnet publish MyApp.csproj -o /app/publish /p:UseAppHost=false --no-restore
    env:
      TELERIK_LICENSE: ${{secrets.TELERIK_LICENSE_KEY}}
```

Azure Pipelines YAML

```yaml
  - powershell: dotnet publish MyApp.csproj -o /app/publish /p:UseAppHost=false --no-restore
    displayName: 'Build and publish the project'
    env:
      TELERIK_LICENSE: $(MY_TELERIK_LICENSE_KEY) # AzDO pipeline secret variable
```

If you're using classic pipelines, you can use a pipeline variable:

![Image](https://github.com/user-attachments/assets/bcdcc8c3-8ec7-43af-8452-4bace4e8ee83)

> [!IMPORTANT]
> License key length - If you are using a Library **Variable Group**, there is a character limit for the variable values. The only way to have a long value in the Variable Group is to link it from Azure KeyVault. If you cannot use Azure KeyVault, then use a normal pipeline variable instead (seen above) or use the Secure File approach instead (see below).


#### Approach 2 - Using a File

You have two options for a file-base option. Set the TELERIK_LICENSE_PATH variable or add a file named **telerik-license.txt** to the project directory. The licensing runtime will do a recursive check from the project directory to root, and then finally %appdata%/telerik/.

On Azure DevOps, there is a powerful feature called Secure Files. It lets you upload a file and then use it in a pipeline. Go to your Library tab, then select Secure File

After you've uploaded the Secure File to your Azure DevOps project, you can use it in a pipeline, liek this:

> [!CAUTION]
> Never check in the **telerik-license.txt** file with your code and never distr4ibute it with your application/docker image.

##### YAML Pipeline

With a YAML pipeline, you can use the **DownloadSecureFile@1** task, then use `$(name.secureFilePath)` to reference it. For example:

```yaml
  - task: DownloadSecureFile@1
    name: DownloadTelerikLicenseFile # defining the 'name' is important
    displayName: 'Download Telerik License Key File'
    inputs:
      secureFile: 'telerik-license.txt'

  - task: MSBuild@1
    displayName: 'Build Project'
    inputs:
      solution: 'myapp.csproj'
      platform: Any CPU
      configuration: Release
      msbuildArguments: '/p:RestorePackages=false'
    env:
      # use the name.secureFilePath value to set the special TELERIK_LICENSE_PATH
      TELERIK_LICENSE_PATH: $(DownloadTelerikLicenseFile.secureFilePath) 
```

##### Classic Pipeline

With a classic pipeline, you can use the same `DownloadSecureFile` Task

![Image](https://github.com/user-attachments/assets/8c9f0aa4-0ef8-48a9-9805-b0686db1109c)

> [!IMPORTANT]
> See the screenshot above. You must set the output variable's name, this is the **reference name** which gets prepended to the `.secureFilePath` output variable.

With the secure file downloaded to the runner, you have two options again:

- A) Set the TELERIK_LICENSE_PATH variable with the path $(telerik.secureFilePath)
- or
- B) Copy the actual license file to a directory you want to use it in.

![Image](https://github.com/user-attachments/assets/0b1fd81f-5ee6-49e1-8ce3-031ed379c1d6)

> [!CAUTION]
> If you distribute the source code with your artifacts, make sure you delete the copied license.txt file immediately after the build step.

Ultimately, there are many routes to take, and you can choose th eone that best suits your CI-CD needs. What is most important is that you protect the key value/file as you'd protect any sensitive secret.
