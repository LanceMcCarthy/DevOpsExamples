﻿using MyBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazorApp.Services
{
    public class DashboardDataService
    {
        private static List<PodcastViewModel> podcasts = new List<PodcastViewModel>();
        private readonly Random random = new Random();
        private readonly List<string> firstNames = new List<string> { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
        private readonly List<string> lastNames = new List<string> { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White" };
        private readonly List<string> platforms = new List<string> { "Apple Podcasts", "Spotify", "Other", "Overcast", "Anchor", "Stitcher" };
        private readonly List<string> devices = new List<string> { "iOS", "Android", "Other", "Web" };
        
        public DashboardDataService()
        {
            if (podcasts.Count == 0)
            {
                podcasts = Enumerable.Range(1, 50).Select(x => new PodcastViewModel()
                {
                    Name = string.Format("Episode #{0} with guest {1} {2}", random.Next(0, 200), firstNames[random.Next(0, firstNames.Count)], lastNames[random.Next(0, lastNames.Count)]),
                    Streams = random.Next(0, 18000),
                    Downloads = random.Next(0, 15000),
                    PlatformName = platforms[random.Next(0, platforms.Count)],
                    Device = devices[random.Next(0, devices.Count)],
                    Date = DateTime.Now.AddDays(-x),
                    Reach = x * random.Next(0, 1000),
                }).ToList();
            }
        }
        
        public async Task<IEnumerable<PodcastViewModel>> GetPodcasts()
        {
            return await Task.FromResult(podcasts);
        }

        public async Task<int> GetStreams()
        {
            var result = podcasts.Sum(f => f.Streams);
            return await Task.FromResult(result);
        }

        public async Task<int> GetDownloads()
        {
            var result = podcasts.Sum(f => f.Downloads);
            return await Task.FromResult(result);
        }

        public async Task<int> GetReach()
        {
            var result = podcasts.Sum(f => f.Reach);
            return await Task.FromResult(result);
        }

        public async Task<double> GetRevenue()
        {
            double result = podcasts.Sum(f => f.Views) / 100;
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PlatformViewModel>> GetPlatformData(bool byDevice)
        {
            var deviceViews = podcasts
                .GroupBy(x => byDevice == true ? x.Device : x.PlatformName)
                .Select(x => new PlatformViewModel
                {
                    Category = x.Key,
                    Views = x.Sum(v => v.Views)
                });

            return await Task.FromResult(deviceViews);
        }
    }
}
