using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.CellTypesCategory.TemplateCellSelectorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemplateCellSelector : RadContentView
    {
        public TemplateCellSelector()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var item = (sender as BindableObject).BindingContext as DataItem;
            if (item != null)
            {
                item.IsSpecial = true;
            }
        }
    }
}