using Microsoft.JSInterop;
using MyBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace MyBlazorApp.Components;

public partial class DemoMain
{
    // "Main" is the name of the Razor component that holds this code
    private DotNetObjectReference<DemoMain> DotNetRef { get; set; }
    private TelerikChart ChartRef { get; set; }
    public IEnumerable<PodcastViewModel> Podcasts { get; set; }
    private List<ChartModel> Series1Data { get; set; } = new();
    private List<ChartModel> Series2Data { get; set; } = new();
    private List<ChartModel> Series3Data { get; set; } = new();
    private List<ThemeModel> ThemeData { get; set; } = new();
    private int ThemeSwatchValue { get; set; } = 1;
    private const string ThemeUrlTemplate = "https://unpkg.com/@progress/kendo-theme-{0}@11.0.2/dist/{0}-{1}.css";
    private bool LoaderVisible { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Ensure HTML is ready
            await Task.Delay(1);

            // Send the Razor component's reference to the client
            // to be able to call NotifyThemeChanged()
            await Js.InvokeVoidAsync("saveDotNetRef", DotNetRef);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        DotNetRef = DotNetObjectReference.Create(this);

        PopulateThemes();

        await GenerateData();


        await base.OnInitializedAsync();
    }

    private void PopulateThemes()
    {
        ThemeData.Add(new ThemeModel(1, "Default", "Main"));
        ThemeData.Add(new ThemeModel(2, "Default", "Main-Dark"));
        ThemeData.Add(new ThemeModel(3, "Default", "Ocean-Blue"));
        ThemeData.Add(new ThemeModel(4, "Bootstrap", "Main"));
        ThemeData.Add(new ThemeModel(5, "Bootstrap", "Main-Dark"));
        ThemeData.Add(new ThemeModel(6, "Material", "Main"));
        ThemeData.Add(new ThemeModel(7, "Material", "Main-Dark"));
        ThemeData.Add(new ThemeModel(8, "Fluent", "Main"));
    }

    private async Task GenerateData()
    {
        Podcasts = await DataService.GetPodcasts();

        var now = DateTime.Today;

        const int monthsBack = 6;

        for (var i = 1; i <= monthsBack; i++)
        {
            var dateTimeValue = now.AddMonths(-monthsBack + i);

            Series1Data.Add(new ChartModel
            {
                Id = i,
                Product = "Product 1",
                Revenue = Random.Shared.Next(1, 500),
                TimePeriod = dateTimeValue
            });

            Series2Data.Add(new ChartModel
            {
                Id = i,
                Product = "Product 2",
                Revenue = Random.Shared.Next(1, 500),
                TimePeriod = dateTimeValue
            });

            Series3Data.Add(new ChartModel
            {
                Id = i,
                Product = "Product 3",
                Revenue = Random.Shared.Next(1, 500),
                TimePeriod = dateTimeValue
            });
        }
    }

    void OnStateInit(GridStateEventArgs<PodcastViewModel> args)
    {
        args.GridState = new GridState<PodcastViewModel>
        {
            SortDescriptors = new List<SortDescriptor>
            {
                new SortDescriptor { Member = nameof(PodcastViewModel.Streams), SortDirection = ListSortDirection.Descending }
            }
        };
    }

    private async Task ThemeSwatchValueChanged(int newValue)
    {
        // Update DropDownList Value
        ThemeSwatchValue = newValue;

        LoaderVisible = true;

        // Generate new theme URL
        var newThemeModel = ThemeData.First(x => x.Id == ThemeSwatchValue);
        var newThemeSwatchUrl = string.Format(ThemeUrlTemplate, newThemeModel.Theme.ToLower(), newThemeModel.Swatch.ToLower());

        // Change current Telerik theme
        await Js.InvokeVoidAsync("changeTelerikTheme", newThemeSwatchUrl);

        // The algorithm continues in the NotifyThemeChanged method
    }

    [JSInvokable("NotifyThemeChanged")]
    public void NotifyThemeChanged()
    {
        // Refresh all Telerik components that use SVG or Canvas rendering (Charts, Gauges, BarCodes, QR Codes)
        ChartRef?.Refresh();

        LoaderVisible = false;

        // This method is not an EventCallback, so you need StateHasChanged() to hide the Loader or make other changes in the UI
        StateHasChanged();
    }

    public void Dispose()
    {
        DotNetRef?.Dispose();
    }
}