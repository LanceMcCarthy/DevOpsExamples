using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using System.Diagnostics;

namespace MyAspNetCoreApp.Controllers;

public class HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ReportViewer()
    {
        var reportsPath = Path.Combine(environment.ContentRootPath, "Reports");

        var reports = Directory.GetFiles(reportsPath, "*.trdp")
            .Select(Path.GetFileName)
            .OrderBy(n => n)
            .ToList();

        ViewBag.Reports = reports;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogError($"An error occurred while processing the request. {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
        
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}