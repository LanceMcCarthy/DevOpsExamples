namespace MyAspNetCoreApp.Models
{
    public class PodcastViewModel
    {
        private int views;

        public string? Name { get; set; }

        public int Downloads { get; set; }

        public int Streams { get; set; }

        public int Views
        {
            get => Downloads + Streams;
            private set => views = value;
        }

        public DateTime Date { get; set; }

        public int Reach { get; set; }

        public string? Device { get; set; }

        public string? PlatformName { get; set; }
    }
}
