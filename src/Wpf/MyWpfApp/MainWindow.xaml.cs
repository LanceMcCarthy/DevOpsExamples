using System.ComponentModel;
using System.Windows;
using Telerik.Windows.Controls.GridView.SpreadsheetStreamingExport;

namespace MyWpfApp;

public partial class MainWindow : Window
{
    private readonly GridViewSpreadStreamExport sse;

    public MainWindow()
    {
        InitializeComponent();

        sse = new GridViewSpreadStreamExport(MyGridView);
        sse.SheetName = "Sheet1";
        sse.ExportFormat = SpreadStreamExportFormat.Csv;

        // Show busy indicator
        sse.ShowLoadingIndicatorWhileAsyncExport = true;

        // subscript  to complete event (so you can reset the buttons)
        sse.AsyncExportCompleted += Sse_AsyncExportCompleted;
    }

    private void StartExportButton_OnClick(object sender, RoutedEventArgs e)
    {
        // Disable the start button Prevent double starts
        StartExportButton.IsEnabled = false;

        // Make the cancel button visible
        CancelExportButton.Visibility = Visibility.Visible;

        // start the export, runs on a background thread
        sse.RunExportAsync("./my-export.csv", new SpreadStreamExportRenderer());
    }

    private void CancelExportButton_OnClick(object sender, RoutedEventArgs e)
    {
        // Cancel the export
        sse.CancelExportAsync();

        // Revert the buttons state and text back to normal
        ResetButtons();
    }

    private void Sse_AsyncExportCompleted(object sender, AsyncCompletedEventArgs e)
    {
        ResetButtons();
    }

    private void ResetButtons()
    {
        // Go back to default text
        StartExportButton.Content = "Export CSV";

        // Allow export again
        StartExportButton.IsEnabled = true;

        // Make the cancel button hidden
        CancelExportButton.Visibility = Visibility.Collapsed;
    }
}
