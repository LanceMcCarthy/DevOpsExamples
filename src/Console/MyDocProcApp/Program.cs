using System;
using System.IO;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;

Console.WriteLine("Hello, would you like to create a workbook? [Y/y][N/n]:");

var result = Console.ReadLine();

if (result?.ToLower() == "y")
{
    Workbook workbook = new Workbook();
    Worksheet worksheet = workbook.Worksheets.Add();

    CellSelection selection = worksheet.Cells[1, 1]; //B2 cell 
    selection.SetValue("Hello RadSpreadProcessing");

    string fileName = "SampleFile.xlsx";

    IWorkbookFormatProvider formatProvider = new XlsxFormatProvider();

    using Stream output = new FileStream(fileName, FileMode.Create);

    formatProvider.Export(workbook, output);

    Console.WriteLine("Done!");
}
