using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using Telerik.Documents.Common.Model;
using Telerik.Documents.Media;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;

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

    public ActionResult Generate_PodcastsExcel()
    {
        var workbook = new Workbook();
        var worksheet = workbook.Worksheets.Add();
        worksheet.Name = "Podcasts";

        string[] headers = ["Podcast Episode", "Downloads", "Streams", "Views", "Date", "Reach", "Device", "Platform"];

        for (var column = 0; column < headers.Length; column++)
        {
            worksheet.Cells[0, column].SetValue(headers[column]);
        }

        var headerRow = worksheet.Cells[0, 0, 0, headers.Length - 1];
        headerRow.SetFill(PatternFill.CreateSolidFill(Color.FromRgb(0, 51, 102)));
        headerRow.SetForeColor(new ThemableColor(Color.FromRgb(255, 255, 255)));

        var podcasts = GetPodcasts();

        for (var row = 0; row < podcasts.Count; row++)
        {
            var podcast = podcasts[row];
            var worksheetRow = row + 1;

            worksheet.Cells[worksheetRow, 0].SetValue(podcast.Name ?? string.Empty);
            worksheet.Cells[worksheetRow, 1].SetValue(podcast.Downloads);
            worksheet.Cells[worksheetRow, 2].SetValue(podcast.Streams);
            worksheet.Cells[worksheetRow, 3].SetValue(podcast.Views);
            worksheet.Cells[worksheetRow, 4].SetValue(podcast.Date.ToShortDateString());
            worksheet.Cells[worksheetRow, 5].SetValue(podcast.Reach);
            worksheet.Cells[worksheetRow, 6].SetValue(podcast.Device ?? string.Empty);
            worksheet.Cells[worksheetRow, 7].SetValue(podcast.PlatformName ?? string.Empty);
        }

        worksheet.Columns[0].SetWidth(new ColumnWidth(290, true));
        worksheet.Columns[1].SetWidth(new ColumnWidth(85, true));
        worksheet.Columns[4].SetWidth(new ColumnWidth(90, true));
        worksheet.Columns[7].SetWidth(new ColumnWidth(120, true));

        var formatProvider = new XlsxFormatProvider();

        using var stream = new MemoryStream();
        formatProvider.Export(workbook, stream, TimeSpan.FromMinutes(2));

        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "podcasts.xlsx");
    }


    // HELPER METHODS

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