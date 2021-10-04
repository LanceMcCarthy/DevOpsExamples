using System;
using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ListViewControl.ScrollingCategory.ScrollingExample
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Items = new ObservableCollection<string>();

            for (int i = 0; i < 100; i++)
            {
                this.Items.Add("Item " + i);
            }
        }
        public ObservableCollection<string> Items { get; set; }
    }
}
