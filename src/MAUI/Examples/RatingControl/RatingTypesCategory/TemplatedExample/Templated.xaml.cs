using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.RatingControl.RatingTypesCategory.TemplatedExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Templated : RadContentView
    { 
        public Templated()
        {
            InitializeComponent();
        }

        private void RadTemplatedRating_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.label.Text = "Value is changed to: " + e.NewValue;
        }
    }
}