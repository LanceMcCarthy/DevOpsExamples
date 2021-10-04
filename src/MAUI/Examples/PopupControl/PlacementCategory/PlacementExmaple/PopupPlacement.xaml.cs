using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.PopupControl.PlacementCategory.PlacementExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPlacement : RadContentView
    {
        public PopupPlacement()
        {
            InitializeComponent(); 
        }
        private void ShowPopup(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }
    }
}