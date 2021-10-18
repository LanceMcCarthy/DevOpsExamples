using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.HeaderAndFooterCategory.HeaderAndFooterExample
{
    // >> listview-features-header-and-footer-viewmodel
    public class HeaderAndFooterViewModel
    {
        public HeaderAndFooterViewModel()
        {
            this.Items = GetItems(20);
        }

        public ObservableCollection<string> Items { get; set; }

        private static ObservableCollection<string> GetItems(int count)
        {
            var items = new ObservableCollection<string>();
            for (int i = 0; i < count; i++)
            {
                items.Add(string.Format("item {0}", i));
            }

            return items;
        }
    }
    // << listview-features-header-and-footer-viewmodel
}
