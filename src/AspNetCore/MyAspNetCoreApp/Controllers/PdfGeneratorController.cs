using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using Telerik.Documents.Flow.FormatProviders.Html;
using Telerik.Documents.Flow.FormatProviders.Pdf;

namespace MyAspNetCoreApp.Controllers;

public class PdfGeneratorController(ILogger<PdfGeneratorController> logger) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new PdfGeneratorViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Generate(PdfGeneratorViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        try
        {
            return File(CreatePdf(model.HtmlBody), "application/pdf", "generated-document.pdf");
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "The PDF could not be generated.");
            ModelState.AddModelError(string.Empty, $"The PDF could not be generated: {exception.Message}");

            return View("Index", model);
        }
    }

    private static byte[] CreatePdf(string htmlBody)
    {
        HtmlFormatProvider htmlProvider = new();
        PdfFormatProvider pdfProvider = new();
        using MemoryStream pdfStream = new();

        var document = htmlProvider.Import(htmlBody, null);
        pdfProvider.Export(document, pdfStream, null);

        return pdfStream.ToArray();
    }
}
