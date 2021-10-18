using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.HeaderAndFooterCategory.HeaderAndFooterExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderAndFooter : RadContentView
    {
        public HeaderAndFooter()
        {
            InitializeComponent();
            this.BindingContext = new HeaderAndFooterViewModel();
        }
    }
}