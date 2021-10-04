using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.LoadOnDemandCategory.LoadOnDemandCommandExample
{
    // >> listview-loadondemand-loadondemandcommand-viewmodel
    public class ViewModel : NotifyPropertyChangedBase
    {
        private bool isLoadingMoreItems;
        private int lodCounter = 0;

        public ViewModel()
        {
            this.Source = new ObservableCollection<string>();
            for (int i = 0; i < 14; i++)
            {
                this.Source.Add(string.Format("Item {0}", i));
            }
            this.LoadItemsCommand = new Command(this.LoadItemsCommandExecute);
        }

        public ObservableCollection<string> Source { get; }
        public ICommand LoadItemsCommand { get; set; }

        public bool IsLoadingMoreItems
        {
            get { return this.isLoadingMoreItems; }
            set { this.UpdateValue(ref this.isLoadingMoreItems, value); }
        }

        private async void LoadItemsCommandExecute(object obj)
        {
            // If you need to get new data asynchronously, you must manually update the loading status.
            this.IsLoadingMoreItems = true;

            IEnumerable<string> newItems = await this.GetNewItems();
            foreach (string newItem in newItems)
            {
                this.Source.Add(newItem);
            }

            this.IsLoadingMoreItems = false;
        }

        private async Task<IEnumerable<string>> GetNewItems()
        {
            this.lodCounter++;
            await Task.Delay(4000);  // Mimic getting data from server asynchronously.
            return Enum.GetNames(typeof(DayOfWeek)).Select(day => string.Format("LOD: {0} - {1}", this.lodCounter, day));
        }
    }
    // << listview-loadondemand-loadondemandcommand-viewmodel
}
