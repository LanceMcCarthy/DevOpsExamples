using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ButtonControl.GettingStartedCategory.GettingStartedExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonGettingStartedXaml : RadContentView
    {
        public ButtonGettingStartedXaml()
        {
            InitializeComponent();
        }
        
        // >> button-getting-started-click-event
        private void button_Clicked(object sender, System.EventArgs e)
        {
            //implement your logic here.
        }
        // << button-getting-started-click-event
    }
}