using System;
using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.PathControl.FeaturesCategory.MultiPathExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiPath : RadContentView
    {
        public MultiPath()
        {
            InitializeComponent(); 
            this.root.SizeChanged += Root_SizeChanged;
        }

        private void Root_SizeChanged(object sender, EventArgs e)
        {
            double size = Math.Min(this.root.Width, this.root.Height / 2);
            this.multiPath.WidthRequest = size;
            this.multiPath.HeightRequest = size;
            this.path2.WidthRequest = size;
            this.path2.HeightRequest = size;
        }

    }
}