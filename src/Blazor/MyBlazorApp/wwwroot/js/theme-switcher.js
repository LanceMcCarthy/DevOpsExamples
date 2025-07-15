var themeChangerDotNetRef;

function saveDotNetRef(dotNetRef) {
    themeChangerDotNetRef = dotNetRef;
}

function changeTelerikTheme(newUrl) {
    var oldLink = document.getElementById("telerik-theme");

    if (newUrl === oldLink.getAttribute("href")) {
        return;
    }

    var newLink = document.createElement("link");
    newLink.setAttribute("id", "telerik-theme");
    newLink.setAttribute("rel", "stylesheet");
    newLink.setAttribute("href", newUrl);

    newLink.onload = () => {
        oldLink.parentElement.removeChild(oldLink);
        themeChangerDotNetRef.invokeMethodAsync("NotifyThemeChanged");
    };

    document.getElementsByTagName("head")[0].appendChild(newLink);
}