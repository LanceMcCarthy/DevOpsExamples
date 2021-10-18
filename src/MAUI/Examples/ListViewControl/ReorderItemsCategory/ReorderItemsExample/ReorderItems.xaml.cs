using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.ReorderItemsCategory.ReorderItemsExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReorderItems : RadContentView
    {
        public ReorderItems()
        {
            InitializeComponent();

            // >> listview-gestures-reorderitems-code
            this.listView.ItemsSource = new ObservableCollection<string>()
            {
              "Check weather for London",
              "Call Brian Ingram",
              "Check the childrens' documents",
              "Take care of the dog",
              "Airplane tickets reschedule",
              "Check the trains schedule",
              "Bills due: Alissa's ballet class",
              "Weekly organic basket"
            };
            // << listview-gestures-reorderitems-code
        }
    }
}