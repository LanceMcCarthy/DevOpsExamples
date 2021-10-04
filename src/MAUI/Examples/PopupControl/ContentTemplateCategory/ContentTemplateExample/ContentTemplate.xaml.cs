using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Primitives.CheckBox;

namespace SDKBrowserMaui.Examples.PopupControl.ContentTemplateCategory.ContentTemplateExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentTemplate : RadContentView
    {
        public ContentTemplate()
        {
            InitializeComponent(); 
        }
        // >> popup-features-contenttemplate-events
        private void ClosePopup(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }
        private void Checkbox_IsCheckedChanged(object sender, IsCheckedChangedEventArgs e)
        {
            if (e.NewValue == true)
                popup.IsOpen = true;
        }
        // << popup-features-contenttemplate-events
    }
}