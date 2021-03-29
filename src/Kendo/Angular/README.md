# UI for Angular  CI-CD License activation 

This demo shows how you can activate your Kendo license in a CI-CD pipeline. 

> REQUIREMENT Before you can use any of the options below, you must have installed `npm install --save @progress/kendo-licensing` to the application.  Please carefully follow the first steps here https://www.telerik.com/kendo-angular-ui/components/my-license/

## GitHub Actions

See our [GitHub Actions YAML Example](https://www.telerik.com/kendo-angular-ui/components/my-license/#toc-github-actions) in the documentation. You can also visit this repository's workflow here [main_build-angular.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/.github/workflows/main_build-angular.yml)

## Azure DevOps

### YAML Pipeline

See our YAML example in [Azure DevOps YAML Example](https://www.telerik.com/kendo-angular-ui/components/my-license/#toc-azure-pipelines) section.

### Classic Pipeline

We currently do not have a section in the documentation that shows an example of a classic pipeline. I will push an update to that as soon as possible, but in the meantime, here are the instructions

1. Add a new pipeline secret variable named `kendo_license_value` to the pipeline that contains the contents of your **kendo-ui-license.txt** file.

    ![add var](https://user-images.githubusercontent.com/3520532/112886857-79596180-90a0-11eb-9dd1-03e54ba06928.png)

2. Add a new Bash step, right after your `npm install` step

    i) Select **Inline** option for the script
    ii) Enter the `npx kendo-ui-license activate` command

    ```
    # If you need to, change to the folder containing the package.json
    cd src/your-project
    
    # If you have not already installed this package, install it now
    npm install --save @progress/kendo-licensing
    
    # Activate the license
    npx kendo-ui-license activate
    ```
    
    Here's a screenshot of what it should look like at this point:
    
    ![ng bash step](https://user-images.githubusercontent.com/3520532/112886559-1798f780-90a0-11eb-8ea6-e903811ae34c.png)
    
    > **WARNING** Please run `npm install --save @progress/kendo-licensing` on your project. If it has not already been added to your packages.json, then you can add it above.

3. Expand the **Environment Variables** section and add a new variable named `KENDO-UI-LICENSE` and set the value to the name name you used for the pipeline secret variable `$(kendo_license_value)`

    ![step env vars](https://user-images.githubusercontent.com/3520532/112887141-cb9a8280-90a0-11eb-9b67-546ca51195e2.png)











