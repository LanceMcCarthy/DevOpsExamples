using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.SortingCategory.BindablePropertySortDescriptorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindablePropertySorting : RadContentView
    {
        public BindablePropertySorting()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel();
        }
    }
}