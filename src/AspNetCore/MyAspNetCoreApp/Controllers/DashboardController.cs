using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Controllers;

public class DashboardController : Controller
{
    private readonly List<string> firstNames = ["Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige"];
    private readonly List<string> lastNames = ["Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White"];
    private readonly List<string> platforms = ["Apple Podcasts", "Spotify", "Other", "Overcast", "Anchor", "Stitcher"];
    private readonly List<string> devices = ["iOS", "Android", "Other", "Web"];

    private static readonly Random Random = new();

    private static readonly List<PodcastViewModel> Podcasts = [];

    public ActionResult Podcasts_Read([DataSourceRequest] DataSourceRequest request)
    {
        var result = GetPodcasts().ToDataSourceResult(request);
        ViewData["test"] = result.AggregateResults;
        return Json(result);
    }

    public ActionResult Downloads_Read([DataSourceRequest] DataSourceRequest request)
    {
        return Json(GetPodcasts());
    }

    public ActionResult Devices_Read([DataSourceRequest] DataSourceRequest request)
    {
        var deviceViews = GetPodcasts()
            .GroupBy(x => x.Device)
            .Select(x => new
            {
                Device = x.Key,
                Views = x.Sum(v => v.Views)
            });

        return Json(deviceViews);
    }

    public ActionResult Platforms_Read([DataSourceRequest] DataSourceRequest request)
    {
        var platformViews = GetPodcasts()
            .GroupBy(x => x.PlatformName)
            .Select(x => new
            {
                PlatformName = x.Key,
                Views = x.Sum(v => v.Views)
            });

        return Json(platformViews);
    }
    private List<PodcastViewModel> GetPodcasts()
    {
        if (Podcasts.Count == 0)
        {
            Podcasts.AddRange(Enumerable.Range(1, 50).Select(x => new PodcastViewModel()
            {
                Name = $"Episode #{Random.Next(0, 200)} with guest {firstNames[Random.Next(0, firstNames.Count)]} {lastNames[Random.Next(0, lastNames.Count)]}",
                Streams = Random.Next(0, 18000),
                Downloads = Random.Next(0, 15000),
                PlatformName = platforms[Random.Next(0, platforms.Count)],
                Device = devices[Random.Next(0, devices.Count)],
                Date = DateTime.Now.AddDays(-x),
                Reach = x * Random.Next(0, 1000)
            }));
        }

        return Podcasts;
    }
}