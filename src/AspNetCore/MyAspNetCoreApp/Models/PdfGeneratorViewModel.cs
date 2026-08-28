using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Models;

public class PdfGeneratorViewModel
{
    [Required(ErrorMessage = "Enter some content before generating the PDF.")]
    public string HtmlBody { get; set; } = "<h1>My PDF document</h1><p>Replace this text with your content.</p>";
}
