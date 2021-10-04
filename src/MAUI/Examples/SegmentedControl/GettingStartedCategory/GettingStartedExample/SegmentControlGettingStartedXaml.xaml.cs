using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;
using System.Collections.Generic;

namespace SDKBrowserMaui.Examples.SegmentedControl.GettingStartedCategory.GettingStartedExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentControlGettingStartedXaml : RadContentView
    {
        public SegmentControlGettingStartedXaml()
        {
            InitializeComponent();
            this.segmentControlText.ItemsSource = new List<string> 
            {
                "Popular",
                "Library",
                "Playlists",
                "Friends"
            };
        }
    }
}