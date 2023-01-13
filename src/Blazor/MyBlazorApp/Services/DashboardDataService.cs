using MyBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazorApp.Services;

public class DashboardDataService : IDashboardDataService
{
    private static List<PodcastViewModel> podcasts = new();
    
    public DashboardDataService()
    {
        Random random = new();
        List<string> firstNames = new() { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
        List<string> lastNames = new() { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White" };
        List<string> platforms = new() { "Apple Podcasts", "Spotify", "Other", "Overcast", "Anchor", "Stitcher" };
        List<string> devices = new() { "iOS", "Android", "Other", "Web" };

        podcasts = Enumerable.Range(1, 50).Select(x => new PodcastViewModel()
        {
            Name =
                $"Episode #{random.Next(0, 200)} with guest {firstNames[random.Next(0, firstNames.Count)]} {lastNames[random.Next(0, lastNames.Count)]}",
            Streams = random.Next(0, 18000),
            Downloads = random.Next(0, 15000),
            PlatformName = platforms[random.Next(0, platforms.Count)],
            Device = devices[random.Next(0, devices.Count)],
            Date = DateTime.Now.AddDays(-x),
            Reach = x * random.Next(0, 1000),
        }).ToList();
    }

    public async Task<IEnumerable<PodcastViewModel>> GetPodcasts()
    {
        return await Task.FromResult(podcasts);
    }

    public async Task<int> GetStreams()
    {
        return await Task.FromResult(podcasts.Sum(f => f.Streams));
    }

    public async Task<int> GetDownloads()
    {
        return await Task.FromResult(podcasts.Sum(f => f.Downloads));
    }

    public async Task<int> GetReach()
    {
        return await Task.FromResult(podcasts.Sum(f => f.Reach));
    }

    public async Task<double> GetRevenue()
    {
        return await Task.FromResult(podcasts.Sum(f => f.Views) / (double)100);
    }

    public async Task<IEnumerable<PlatformViewModel>> GetPlatformData(bool byDevice)
    {
        return await Task.FromResult(podcasts
            .GroupBy(x => byDevice ? x.Device : x.PlatformName)
            .Select(x => new PlatformViewModel
            {
                Category = x.Key,
                Views = x.Sum(v => v.Views)
            }));
    }
}