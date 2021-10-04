using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.LoadOnDemandCategory.LoadOnDemandEventExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadOnDemandEvent : RadContentView
    {
        public LoadOnDemandEvent()
        {
            InitializeComponent();

            // >> listview-loadondemand-loadondemandeventauto-bind
            this.source = new ObservableCollection<string>();
            for (int i = 0; i < 14; i++)
            {
                source.Add(string.Format("Item {0}", i));
            }
            this.listView.ItemsSource = this.source;
            // << listview-loadondemand-loadondemandeventauto-bind
        }

        // >> listview-loadondemand-loadondemandeventauto-event
        private ObservableCollection<string> source;
        private int lodCounter = 0;

        private async void ListView_LoadOnDemand(object sender, EventArgs e)
        {
            // If you need to get new data asynchronously, you must manually update the loading status.
            this.listView.IsLoadOnDemandActive = true;

            IEnumerable<string> newItems = await this.GetNewItems();
            foreach (string newItem in newItems)
            {
                this.source.Add(newItem);
            }

            this.listView.IsLoadOnDemandActive = false;
        }

        private async Task<IEnumerable<string>> GetNewItems()
        {
            this.lodCounter++;
            await Task.Delay(4000);  // Mimic getting data from server asynchronously.
            return Enum.GetNames(typeof(DayOfWeek)).Select(day => string.Format("LOD: {0} - {1}", this.lodCounter, day));
        }
        // << listview-loadondemand-loadondemandeventauto-event
    }
}