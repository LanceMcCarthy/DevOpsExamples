using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.PopupControl.ModalPopupCategory.ModalPopupExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPopup : RadContentView
    {
        public ModalPopup()
        {
            InitializeComponent(); 
        }
        // >> popup-features-modal-events
        private void ClosePopup(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }
        private void ShowPopup(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }
        // << popup-features-modal-events
    }
}