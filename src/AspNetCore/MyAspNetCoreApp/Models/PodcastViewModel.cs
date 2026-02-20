namespace MyAspNetCoreApp.Models;

public class PodcastViewModel
{
    public string? Name { get; set; }

    public int Downloads { get; set; }

    public int Streams { get; set; }

    public int Views => Downloads + Streams;

    public DateTime Date { get; set; }

    public int Reach { get; set; }

    public string? Device { get; set; }

    public string? PlatformName { get; set; }
}