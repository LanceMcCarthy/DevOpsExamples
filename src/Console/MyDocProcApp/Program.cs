using System;
using System.IO;
using System.Text;
using System.Timers;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;

//      Unicode character               Oct     Dec     Hex     HTML
// ⣾	braille pattern dots-2345678	024376	10494	0x28FE	&#10494;
// ⣽	braille pattern dots-1345678	024375	10493	0x28FD	&#10493;
// ⣻	braille pattern dots-1245678	024373	10491	0x28FB	&#10491;
// ⢿	braille pattern dots-1234568	024277	10431	0x28BF	&#10431;
// ⡿	braille pattern dots-1234567	024177	10367	0x287F	&#10367;
// ⣟	braille pattern dots-1234578	024337	10463	0x28DF	&#10463;
// ⣯	braille pattern dots-1234678	024357	10479	0x28EF	&#10479;
// ⣷	braille pattern dots-1235678	024367	10487	0x28F7	&#10487;

//var timerChars = new [] { "⣾", "⣽", "⣻", "⢿", "⡿", "⣟", "⣯", "⣷"}; // style 1
var timerChars = new [] { "⢹", "⢺", "⢼", "⣸", "⣇", "⡧", "⡗", "⡏"};  // style 2
int lastCharIndex = 0;

// Change the encoding to UTF8 for Unicode support
Console.OutputEncoding = Encoding.UTF8;
Console.CancelKeyPress += ConsoleCancelKeyPress;

Timer timer = new Timer(250);
timer.Elapsed += Timer_Elapsed;

Console.WriteLine("Hello, would you like to create a workbook? [Y/y][N/n]:");

var result = Console.ReadLine();

if (result?.ToLower() == "y")
{
    var workbook = new Workbook();
    var worksheet = workbook.Worksheets.Add();

    timer.Start();

    for (int i = 0; i < 500; i++)
    {
        for (int j = 0; j < 500; j++)
        {
            var selection = worksheet.Cells[i, j]; //B2 cell 
            selection.SetValue($"Cell {i}:{j}");
        }
    }

    var fileName = "SampleFile.xlsx";

    IWorkbookFormatProvider formatProvider = new XlsxFormatProvider();

    await using Stream output = new FileStream(fileName, FileMode.Create);
    
    formatProvider.Export(workbook, output);

    timer.Stop();

    UpdateStatus("Done!", ConsoleColor.Green,true);
    UpdateStatus("", ConsoleColor.White);
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


void Timer_Elapsed(object sender, ElapsedEventArgs e)
{
    var nextCharacter = timerChars[lastCharIndex];

    UpdateStatus($"{nextCharacter} Creating document...", ConsoleColor.Yellow,true);

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
        int currentLineCursor = Console.CursorTop;
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
