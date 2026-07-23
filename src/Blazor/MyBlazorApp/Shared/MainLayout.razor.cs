using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazorApp.Shared;

public partial class MainLayout : IDisposable
{
    private const string ThemeUrlTemplate = "https://unpkg.com/@progress/kendo-theme-{0}@11.0.2/dist/{0}-{1}.css";
    private readonly List<ThemeModel> ThemeData =
    [
        new(1, "Default", "Main"),
        new(2, "Default", "Main-Dark"),
        new(3, "Default", "Ocean-Blue"),
        new(4, "Bootstrap", "Main"),
        new(5, "Bootstrap", "Main-Dark"),
        new(6, "Material", "Main"),
        new(7, "Material", "Main-Dark"),
        new(8, "Fluent", "Main")
    ];

    private DotNetObjectReference<MainLayout> DotNetRef { get; set; }
    private int ThemeSwatchValue { get; set; } = 1;
    private int ThemeVersion { get; set; }
    private bool LoaderVisible { get; set; }

    [Inject]
    private IJSRuntime Js { get; set; }

    protected override void OnInitialized()
    {
        DotNetRef = DotNetObjectReference.Create(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Js.InvokeVoidAsync("saveDotNetRef", DotNetRef);
        }
    }

    private async Task ThemeSwatchValueChanged(int newValue)
    {
        ThemeSwatchValue = newValue;
        LoaderVisible = true;

        var theme = ThemeData.First(x => x.Id == ThemeSwatchValue);
        var themeUrl = string.Format(
            ThemeUrlTemplate,
            theme.Theme.ToLowerInvariant(),
            theme.Swatch.ToLowerInvariant());

        await Js.InvokeVoidAsync("changeTelerikTheme", themeUrl);
    }

    [JSInvokable]
    public void NotifyThemeChanged()
    {
        ThemeVersion++;
        LoaderVisible = false;
        StateHasChanged();
    }

    public void Dispose()
    {
        DotNetRef?.Dispose();
    }
}
