using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.NumericInputControl.FeaturesCategory.BindingsExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bindings : RadContentView
    {
        public Bindings()
        {
            this.InitializeComponent();
            this.BindingContext = new ViewModel();
        }
    }
}