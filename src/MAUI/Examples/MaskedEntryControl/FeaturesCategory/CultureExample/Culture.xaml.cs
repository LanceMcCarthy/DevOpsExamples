using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;
using Telerik.Maui.MaskedEntry;

namespace SDKBrowserMaui.Examples.MaskedEntryControl.FeaturesCategory.CultureExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Culture : RadContentView
    {
        public Culture()
        {
            InitializeComponent();

            this.germanCultureMask.Culture = new System.Globalization.CultureInfo("de-DE");
            this.bulgarianCultureMask.Culture = new System.Globalization.CultureInfo("bg-BG");
        }
    }
}