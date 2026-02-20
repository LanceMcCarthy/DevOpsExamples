using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using System.Diagnostics;

namespace MyAspNetCoreApp.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ReportViewer()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogError($"An error occurred while processing the request. {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}