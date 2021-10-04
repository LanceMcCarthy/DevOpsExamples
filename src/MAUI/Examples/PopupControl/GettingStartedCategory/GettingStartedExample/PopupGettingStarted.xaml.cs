using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.PopupControl.GettingStartedCategory.GettingStartedExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupGettingStarted : RadContentView
    {
        public PopupGettingStarted()
        {
            InitializeComponent(); 
        }
        // >> popup-gettingstarted-events
        private void ClosePopup(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }
        private void ShowPopup(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }
        // << popup-gettingstarted-events
    }
}