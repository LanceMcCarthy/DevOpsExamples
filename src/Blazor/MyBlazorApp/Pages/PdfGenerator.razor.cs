using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;
using Telerik.Documents.Flow.FormatProviders.Html;
using Telerik.Documents.Flow.FormatProviders.Pdf;

namespace MyBlazorApp.Pages;

public partial class PdfGenerator
{
    private string HtmlBody { get; set; } = "<h1>My PDF document</h1><p>Replace this text with your content.</p>";
    private bool IsGenerating { get; set; }
    private string? ErrorMessage { get; set; }

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = null!;

    private async Task GeneratePdfAsync()
    {
        if (IsGenerating)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(HtmlBody))
        {
            ErrorMessage = "Enter some content before generating the PDF.";
            return;
        }

        IsGenerating = true;
        ErrorMessage = null;

        try
        {
            var htmlBody = HtmlBody;
            var pdfBytes = await Task.Run(() => CreatePdf(htmlBody));

            using MemoryStream pdfStream = new(pdfBytes);

            using DotNetStreamReference streamReference = new(pdfStream);

            await JsRuntime.InvokeVoidAsync(
                "fileDownload.downloadFromStream",
                "generated-document.pdf",
                streamReference);
        }
        catch (Exception exception)
        {
            ErrorMessage = $"The PDF could not be generated: {exception.Message}";
        }
        finally
        {
            IsGenerating = false;
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
