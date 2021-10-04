using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.ScrollingCategory.ScrollingExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgrammaticScrolling : RadContentView
    {
        public ProgrammaticScrolling()
        {
            this.InitializeComponent();
        }

        private void ScrollItemIntoViewClicked(object sender, EventArgs e)
        {
            var rnd = new Random();
            var items = this.listView.ItemsSource as ObservableCollection<string>;
            var item = items[rnd.Next(items.Count - 1)];
            this.label.Text = "Scrolled to: " + item;
            this.listView.ScrollItemIntoView(item);
        }
    }
}