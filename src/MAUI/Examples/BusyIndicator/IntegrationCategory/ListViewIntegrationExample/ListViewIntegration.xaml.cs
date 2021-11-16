using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.BusyIndicatorControl.IntegrationCategory.ListViewIntegrationExample
{
    public partial class ListViewIntegration : RadContentView
    {
        public ListViewIntegration()
        {
            InitializeComponent();

            // >> busyindicator-withlistview-setvm
            this.BindingContext = new ViewModel();
            // << busyindicator-withlistview-setvm
        }
    }
}
