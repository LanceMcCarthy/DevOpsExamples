using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;
using Telerik.Maui.MaskedEntry;

namespace SDKBrowserMaui.Examples.MaskedEntryControl.FeaturesCategory.AllowNullValuesExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllowNullValues : RadContentView
    {
        public AllowNullValues()
        {
            InitializeComponent();
        }

        private void TextMaskValueToNull_Clicked(object sender, System.EventArgs e)
        {
            this.textMaskedEntry.Value = null;
        }

        private void AllowNullValuesValueToNull_Clicked(object sender, System.EventArgs e)
        {
            this.allowNullValuesTextMaskedEntry.Value = null;
        }
    }
}