# Project Overview

This project contains many different applications, whose purpose is to demonstrate how to build Telerik and Kendo applications on CI/CD platforms like GitHub Actions, Azure DevOps, and others. The repo has a variety of project types, from WPF to .NET MAUI that has an accompanying build example in the respective CI YAML file.

## Folder Structure

- `/src`: Contains the project folders, each project folder contains one example of a Telerik product being used in that platform. The folder names are describing which framework/platform that the demo is for. For example, the 'WPF' folder contains a WPF project that uses Telerik UI for WPF... and the 'Blazor' folder contains a project for ASP.NET Blazor that is using Telerik UI for Blazor. That same pattern is followed for all the subfolders of the 'src' folder

## Libraries and Frameworks

- .NET and C# for the WPF, WinForms, ASP.NET, Blazor, MAUI, WinUI and AJAX demos
- Angular and Node.js for the Angular project
- GitHub Actions flavor YAML for the workflows in '/.github/workflows'
- Azure DevOps flavored YAML for the 'azure-pipelines.yaml' file

## CI Examples

- `/.github/workflows`: Contains all the GitHub Actions examples
- `azure-pipelines.yaml`: Contains all the Azure DevOps examples
