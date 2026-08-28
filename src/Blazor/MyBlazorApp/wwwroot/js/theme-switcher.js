window.themeSwitcher = {
    dotNetReference: null,

    saveDotNetRef: function (dotNetRef) {
        window.themeSwitcher.dotNetReference = dotNetRef;
    },

    changeTheme: function (newUrl) {
        const oldLink = document.getElementById("telerik-theme");

        if (newUrl === oldLink.getAttribute("href")) {
            return;
        }

        const newLink = document.createElement("link");
        newLink.setAttribute("id", "telerik-theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("href", newUrl);

        newLink.onload = () => {
            oldLink.parentElement.removeChild(oldLink);
            window.themeSwitcher.dotNetReference.invokeMethodAsync("NotifyThemeChanged");
        };

        document.getElementsByTagName("head")[0].appendChild(newLink);
    }
};
