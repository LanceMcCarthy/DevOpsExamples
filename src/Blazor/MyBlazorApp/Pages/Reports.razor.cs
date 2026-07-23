using Telerik.ReportViewer.BlazorNative;

namespace MyBlazorApp.Pages;

public partial class Reports
{
    public ReportSourceOptions ReportSource { get; set; } = new("Barcodes.trdp");
    public ScaleMode ScaleMode { get; set; } = ScaleMode.Specific;
    public ViewMode ViewMode { get; set; } = ViewMode.Interactive;
    public bool ParametersAreaVisible { get; set; }
    public bool DocumentMapVisible { get; set; }
    public double Scale { get; set; } = 1.0;
}
