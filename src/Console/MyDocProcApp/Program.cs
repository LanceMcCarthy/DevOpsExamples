using System;
using System.IO;
using System.Text;
using System.Timers;
using Telerik.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Documents.Spreadsheet.Model;
using CommonHelpers.Services;

// See characters list below
//var timerChars = new [] { "⣾", "⣽", "⣻", "⢿", "⡿", "⣟", "⣯", "⣷"}; // style 1
var timerChars = new[] { "⢹", "⢺", "⢼", "⣸", "⣇", "⡧", "⡗", "⡏" };  // style 2
var lastCharIndex = 0;

// Change the encoding to UTF8 for Unicode support
Console.OutputEncoding = Encoding.UTF8;
Console.CancelKeyPress += ConsoleCancelKeyPress;

var timer = new Timer(250);
timer.Elapsed += TimerElapsed;

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Hello,what would you like to create:");

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("  1. Excel workbook");
Console.WriteLine("  2. UPC Barcode");
Console.WriteLine("  3. QRCode");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Enter the number for the item you want to generate or Ctrl +C to cancel.");

var result = Console.ReadLine();

switch (result?.ToLower())
{
    case "1":
        {
            timer.Start();

            var workbook = new Workbook();
            var worksheet = workbook.Worksheets.Add();

            for (var i = 0; i < 500; i++)
            {
                for (var j = 0; j < 500; j++)
                {
                    var selection = worksheet.Cells[i, j]; //B2 cell 
                    selection.SetValue($"Cell {i}:{j}");
                }
            }

            const string fileName = "SampleFile.xlsx";

            var formatProvider = new XlsxFormatProvider();

            await using Stream output = new FileStream(fileName, FileMode.Create);

            formatProvider.Export(workbook, output, TimeSpan.FromMinutes(2));

            timer.Stop();

            UpdateStatus("Done!", ConsoleColor.Green, true);
            UpdateStatus("", ConsoleColor.White);
            break;
        }
    case "2":
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter a value for the UPC-A barcode with check digit (default example 123456789005):");
            Console.ForegroundColor = ConsoleColor.White;

            var upcValue = Console.ReadLine();

            if (string.IsNullOrEmpty(upcValue))
            {
                upcValue = "123456789005";
            }

            var fileName = $"./UPC_{DateTime.UtcNow.ToFileTimeUtc()}.png";

            try
            {
                timer.Start();
                var bc = new BarcodeGeneratorService().GenerateBarcode(BarcodeType.UpcA, upcValue);
                File.WriteAllBytes(fileName, bc);
                UpdateStatus($"Done! {fileName} has been saved to the current directory.", ConsoleColor.Green, true);
                UpdateStatus("", ConsoleColor.White);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                timer.Stop();
            }

            break;
        }
    case "3":
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter a value for the QR code (default https://dvlup.com):");
            Console.ForegroundColor = ConsoleColor.White;

            var qrValue = Console.ReadLine();

            if (string.IsNullOrEmpty(qrValue))
            {
                qrValue = "https://dvlup.com";
            }

            var fileName = $"./QR_{DateTime.UtcNow.ToFileTimeUtc()}.png";

            try
            {
                timer.Start();
                var bc = new BarcodeGeneratorService().GenerateBarcode(BarcodeType.QrCode, qrValue);
                File.WriteAllBytes(fileName, bc);
                UpdateStatus($"Done! {fileName} has been saved to the current directory.", ConsoleColor.Green, true);
                UpdateStatus("", ConsoleColor.White);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                timer.Stop();
            }
            break;
        }
}

#region methods and event handlers

//      Unicode character               Oct     Dec     Hex     HTML
// ⣾	braille pattern dots-2345678	024376	10494	0x28FE	&#10494;
// ⣽	braille pattern dots-1345678	024375	10493	0x28FD	&#10493;
// ⣻	braille pattern dots-1245678	024373	10491	0x28FB	&#10491;
// ⢿	braille pattern dots-1234568	024277	10431	0x28BF	&#10431;
// ⡿	braille pattern dots-1234567	024177	10367	0x287F	&#10367;
// ⣟	braille pattern dots-1234578	024337	10463	0x28DF	&#10463;
// ⣯	braille pattern dots-1234678	024357	10479	0x28EF	&#10479;
// ⣷	braille pattern dots-1235678	024367	10487	0x28F7	&#10487;

void TimerElapsed(object sender, ElapsedEventArgs e)
{
    var nextCharacter = timerChars[lastCharIndex];

    UpdateStatus($"{nextCharacter} Generating...", ConsoleColor.Yellow, true);

    lastCharIndex++;

    if (lastCharIndex > timerChars.Length - 1)
    {
        lastCharIndex = 0;
    }
}

static void UpdateStatus(string message, ConsoleColor textColor, bool replaceLastLine = false)
{
    if (replaceLastLine)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        ClearCurrentConsoleLine();
    }

    Console.ForegroundColor = textColor;
    Console.WriteLine(message, Console.OutputEncoding.CodePage);
}

static void ClearCurrentConsoleLine()
{
    try
    {
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    catch (Exception)
    {
        // ignored -- may fail in some consoles (e.g. VSCode on macOS)
    }
}

void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
{
    e.Cancel = true;

    UpdateStatus("Cancelled", ConsoleColor.Red);

    UpdateStatus("Thank you for stopping by!", ConsoleColor.White);

    Environment.Exit(0);
}

#endregion
