using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.PullToRefreshCategory.PullToRefreshExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PullToRefresh : RadContentView
    {
        public PullToRefresh()
        {
            InitializeComponent();
            // >> listview-gestures-pulltorefresh-source
            listView.ItemsSource = Enumerable.Range(0, this.count);
            // << listview-gestures-pulltorefresh-source
        }
        // >> listview-gestures-pulltorefresh-event
        private int count = 10;

        private async void RefreshRequested(object sender, PullToRefreshRequestedEventArgs e)
        {
            await Task.Delay(3000);
            listView.ItemsSource = Enumerable.Range(this.count, 10);
            this.count += 10;
            listView.EndRefresh();
        }
        // << listview-gestures-pulltorefresh-event
    }
}