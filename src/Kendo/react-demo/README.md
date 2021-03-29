# UI for React | CI-CD License activation

These demos show how you can activate your Kendo license in a CI-CD pipeline.

> REQUIREMENT! - Before you can use any of the options below, you must have installed `npm install --save @progress/kendo-licensing` to the application.  Please carefully follow the first steps in the [UI for React My License documentation](https://www.telerik.com/kendo-react-ui/my-license/) instructions.

## Option 1 - GitHub Actions

 Follow the YAML in our [GitHub Actions YAML Example](https://www.telerik.com/kendo-react-ui/my-license/#toc-github-actions) documentation.. You can see the working example in this repository's workflow here [main_build-react.yml](https://github.com/LanceMcCarthy/DevOpsExamples/blob/main/.github/workflows/main_build-react.yml).

Important, make sure you've already added the secret to your repo.

![GH secrets](https://user-images.githubusercontent.com/3520532/112900733-dad5fc00-90b1-11eb-95a6-1df8fee00deb.png)

## Option 2 - Azure DevOps | YAML Pipeline

See our YAML example in [Azure DevOps YAML Example](https://www.telerik.com/kendo-react-ui/my-license/#toc-azure-pipelines) section.

Fig.1
![ado yaml secret](https://user-images.githubusercontent.com/3520532/112901958-7156ed00-90b3-11eb-9028-c9bbf942a35e.png)

> Fig 1. Do not forget to make sure you've added a pipeline variable containing the contents of your **kendo-ui-license.txt** file.

## Option 3 - Azure DevOps | Classic Pipeline

We currently do not have a section in the documentation that shows an example of a classic pipeline. I will push an update to that as soon as possible, but in the meantime, here are the instructions

1. Add a new pipeline secret variable named `kendo_license_value` to the pipeline that contains the contents of your **kendo-ui-license.txt** file.

    ![add var](https://user-images.githubusercontent.com/3520532/112886857-79596180-90a0-11eb-9dd1-03e54ba06928.png)

2. Add a new Bash step, right after your `npm install` step
3. Select **Inline** option for the script
4. Enter the `npx kendo-ui-license activate` command

    ```bash
    # If you need to, change to the folder containing the package.json
    cd src/your-project
    
    # Activate the license
    npx kendo-ui-license activate

    # If you get an error, that means you forgot to run `npm install --save @progress/kendo-licensing` on your project. Please go back and read https://www.telerik.com/kendo-react-ui/my-license/
    ```

    Here's a screenshot of what it should look like at this point:

    ![ng bash step](https://user-images.githubusercontent.com/3520532/112886559-1798f780-90a0-11eb-8ea6-e903811ae34c.png)

    > **WARNING** Please run `npm install --save @progress/kendo-licensing` on your project. If it has not already been added to your packages.json, then you can add it above.

5. Expand the **Environment Variables** section and add a new variable named `KENDO-UI-LICENSE` and set the value to the name name you used for the pipeline secret variable `$(kendo_license_value)`

    ![step env vars](https://user-images.githubusercontent.com/3520532/112887141-cb9a8280-90a0-11eb-9b67-546ca51195e2.png)
