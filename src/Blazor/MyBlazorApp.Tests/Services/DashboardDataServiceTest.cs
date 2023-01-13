using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlazorApp.Services;
using System.Linq;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace MyBlazorApp.Tests.Services;

[TestClass]
public class DashboardDataServiceTest
{
    [TestMethod]
    public async Task TestPodcasts()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());
        
        var podcasts = await service.GetPodcasts();

        Mock.Assert(podcasts.Any());
    }

    [TestMethod]
    public async Task TestDownloads()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());

        var downloads = await service.GetDownloads();

        Mock.Assert(downloads > 0);
    }

    [TestMethod]
    public async Task TestReach()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());

        var reach = await service.GetReach();

        Mock.Assert(reach > 0);
    }

    [TestMethod]
    public async Task TestPlatformData()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());

        var data = await service.GetPlatformData(false);

        Mock.Assert(data.Any());
    }

    [TestMethod]
    public async Task TestPlatformByDeviceData()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());

        var dataByDevice = await service.GetPlatformData(true);

        Mock.Assert(dataByDevice.Any());
    }

    [TestMethod]
    public async Task TestRevenue()
    {
        var service = Mock.Create<IDashboardDataService>(t => t.Implements<DashboardDataService>());

        var revenue = await service.GetRevenue();

        Mock.Assert(revenue > 0);
    }
}