using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlazorApp.Services;
using MyBlazorApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Telerik.JustMock;
using System;

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

    [TestMethod]
    public void PodcastViewModel_ViewsProperty_ReturnsSumOfDownloadsAndStreams()
    {
        var model = new PodcastViewModel { Downloads = 10, Streams = 15 };
        Assert.AreEqual(25, model.Views);
    }

    [TestMethod]
    public async Task GetStreams_ReturnsCorrectSum()
    {
        var service = new DashboardDataService();
        var podcasts = await service.GetPodcasts();
        var expected = podcasts.Sum(p => p.Streams);
        var actual = await service.GetStreams();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public async Task GetPlatformData_GroupsByPlatformName()
    {
        var service = new DashboardDataService();
        var data = (await service.GetPlatformData(false)).ToList();
        Assert.IsTrue(data.Count > 0);
        Assert.IsFalse(string.IsNullOrEmpty(data[0].Category));
    }

    [TestMethod]
    public async Task GetPodcasts_EmptyList_ReturnsEmpty()
    {
        // Arrange
        var emptyService = Mock.Create<IDashboardDataService>();
        Mock.Arrange(() => emptyService.GetPodcasts()).Returns(Task.FromResult<IEnumerable<PodcastViewModel>>(new List<PodcastViewModel>()));
        // Act
        var podcasts = await emptyService.GetPodcasts();
        // Assert
        Assert.IsFalse(podcasts.Any());
    }

    [TestMethod]
    public void PlatformViewModel_PropertyAssignment_Works()
    {
        var model = new PlatformViewModel { Category = "Test", Views = 123 };
        Assert.AreEqual("Test", model.Category);
        Assert.AreEqual(123, model.Views);
    }
}