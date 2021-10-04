using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.CellSwipeCategory.InteractiveContentExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractiveContent : RadContentView
    {
        public InteractiveContent()
        {
            InitializeComponent();
        }
        void RemoveBook(object sender, EventArgs e)
        {
            var item = (sender as BindableObject).BindingContext as Book;
            (this.listView.BindingContext as ViewModel).Source.Remove(item);
        }
    }
}