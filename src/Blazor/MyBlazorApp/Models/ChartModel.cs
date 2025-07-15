using System;

namespace MyBlazorApp.Models;

public class ChartModel
{
    public int Id { get; set; }
    public string Product { get; set; } = string.Empty;
    public DateTime TimePeriod { get; set; }
    public decimal Revenue { get; set; }
}