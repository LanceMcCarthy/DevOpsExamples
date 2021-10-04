using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.FilteringCategory.BindableFilterDescriptorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableFilterDescriptor : RadContentView
    {
        public BindableFilterDescriptor()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel();
        }
    }
}