using CommonHelpers.Services;
using Spectre.Console;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Telerik.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Documents.Spreadsheet.Model;

Console.OutputEncoding = Encoding.UTF8;
Console.CancelKeyPress += ConsoleCancelKeyPress;

RenderHeader();
RenderMenu();

var selectedAction = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[white]Select an action (or press Ctrl+C to cancel):[/]")
        .PageSize(10)
        .AddChoices(new[]
        {
            "1. Excel workbook",
            "2. UPC barcode",
            "3. QR code"
        }));

switch (selectedAction[0])
{
    case '1':
        await GenerateWorkbookAsync();
        break;
    case '2':
        GenerateUpcBarcode();
        break;
    case '3':
        GenerateQrCode();
        break;
}

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[grey]Press any key to exit...[/]");
Console.ReadKey(true);

return;

static void RenderHeader()
{
    AnsiConsole.Write(new FigletText("MyDocProcApp").Centered().Color(Color.Cyan1));

    var introPanel = new Panel("[white]Generate documents and barcodes quickly with a guided flow.[/]")
        .Border(BoxBorder.Rounded)
        .BorderStyle(new Style(Color.Blue))
        .Header("[bold yellow]Welcome[/]")
        .Expand();

    AnsiConsole.Write(introPanel);
    AnsiConsole.WriteLine();
}

static void RenderMenu()
{
    var table = new Table().Border(TableBorder.Rounded).Expand();
    table.AddColumn("[bold]#[/]");
    table.AddColumn("[bold]Output[/]");
    table.AddColumn("[bold]Description[/]");

    table.AddRow("[cyan]1[/]", "Excel workbook", "Creates [green]SampleFile.xlsx[/] with generated cell content");
    table.AddRow("[cyan]2[/]", "UPC barcode", "Creates a [green].png[/] from UPC-A input");
    table.AddRow("[cyan]3[/]", "QR code", "Creates a [green].png[/] from text or URL input");

    AnsiConsole.Write(table);
    AnsiConsole.WriteLine();
}

static async Task GenerateWorkbookAsync()
{
    const string fileName = "SampleFile.xlsx";

    try
    {
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .SpinnerStyle(Style.Parse("yellow"))
            .StartAsync("[yellow]Generating workbook...[/]", async _ =>
            {
                var workbook = new Workbook();
                var worksheet = workbook.Worksheets.Add();

                for (var i = 0; i < 500; i++)
                {
                    for (var j = 0; j < 500; j++)
                    {
                        var selection = worksheet.Cells[i, j];
                        selection.SetValue($"Cell {i}:{j}");
                    }
                }

                var formatProvider = new XlsxFormatProvider();
                await using Stream output = new FileStream(fileName, FileMode.Create);
                formatProvider.Export(workbook, output, TimeSpan.FromMinutes(2));
            });

        AnsiConsole.MarkupLine($"[green]Done![/] [white]{Markup.Escape(fileName)}[/] saved to current directory.");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Error:[/] {Markup.Escape(ex.Message)}");
    }
}

static void GenerateUpcBarcode()
{
    var upcValue = AnsiConsole.Prompt(
        new TextPrompt<string>("[white]Enter a UPC-A value (default: 123456789005):[/]")
            .AllowEmpty());

    upcValue = string.IsNullOrWhiteSpace(upcValue) ? "123456789005" : upcValue;
    var fileName = $"./UPC_{DateTime.UtcNow.ToFileTimeUtc()}.png";

    try
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .SpinnerStyle(Style.Parse("yellow"))
            .Start("[yellow]Generating UPC barcode...[/]", _ =>
            {
                var bytes = new BarcodeGeneratorService().GenerateBarcode(BarcodeType.UpcA, upcValue);
                File.WriteAllBytes(fileName, bytes);
            });

        AnsiConsole.MarkupLine($"[green]Done![/] [white]{Markup.Escape(fileName)}[/] saved to current directory.");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Error:[/] {Markup.Escape(ex.Message)}");
    }
}

static void GenerateQrCode()
{
    var qrValue = AnsiConsole.Prompt(
        new TextPrompt<string>("[white]Enter a QR code value (default: https://dvlup.com):[/]")
            .AllowEmpty());

    qrValue = string.IsNullOrWhiteSpace(qrValue) ? "https://dvlup.com" : qrValue;
    var fileName = $"./QR_{DateTime.UtcNow.ToFileTimeUtc()}.png";

    try
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .SpinnerStyle(Style.Parse("yellow"))
            .Start("[yellow]Generating QR code...[/]", _ =>
            {
                var bytes = new BarcodeGeneratorService().GenerateBarcode(BarcodeType.QrCode, qrValue);
                File.WriteAllBytes(fileName, bytes);
            });

        AnsiConsole.MarkupLine($"[green]Done![/] [white]{Markup.Escape(fileName)}[/] saved to current directory.");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Error:[/] {Markup.Escape(ex.Message)}");
    }
}

static void ConsoleCancelKeyPress(object? sender, ConsoleCancelEventArgs e)
{
    e.Cancel = true;
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("[red]Cancelled.[/]");
    AnsiConsole.MarkupLine("[grey]Thank you for stopping by![/]");
    Environment.Exit(0);
}
