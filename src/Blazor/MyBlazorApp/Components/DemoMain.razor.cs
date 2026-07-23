using Microsoft.AspNetCore.Components;
using MyBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace MyBlazorApp.Components;

public partial class DemoMain
{
    private TelerikChart ChartRef { get; set; }
    public IEnumerable<PodcastViewModel> Podcasts { get; set; }
    private List<ChartModel> Series1Data { get; set; } = new();
    private List<ChartModel> Series2Data { get; set; } = new();
    private List<ChartModel> Series3Data { get; set; } = new();
    private int RenderedThemeVersion { get; set; }

    [CascadingParameter(Name = "ThemeVersion")]
    private int ThemeVersion { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GenerateData();

        await base.OnInitializedAsync();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender && RenderedThemeVersion != ThemeVersion)
        {
            RenderedThemeVersion = ThemeVersion;
            ChartRef?.Refresh();
        }
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

}