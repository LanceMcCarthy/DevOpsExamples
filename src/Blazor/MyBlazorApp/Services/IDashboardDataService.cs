using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlazorApp.Models;

namespace MyBlazorApp.Services;

public interface IDashboardDataService
{
    Task<IEnumerable<PodcastViewModel>> GetPodcasts();
    Task<int> GetStreams();
    Task<int> GetDownloads();
    Task<int> GetReach();
    Task<double> GetRevenue();
    Task<IEnumerable<PlatformViewModel>> GetPlatformData(bool byDevice);
}