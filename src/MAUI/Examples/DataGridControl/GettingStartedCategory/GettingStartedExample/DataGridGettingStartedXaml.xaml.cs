using Microsoft.Maui.Controls.Xaml;
using System.Collections.Generic;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;

namespace SDKBrowserMaui.Examples.DataGridControl.GettingStartedCategory.GettingStartedExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataGridGettingStartedXaml : RadContentView
    {
        public DataGridGettingStartedXaml()
        {
            InitializeComponent();

            this.dataGrid.ItemsSource = new List<Data>
            {
                new Data { Country = "India", Capital = "New Delhi"},
                new Data { Country = "South Africa", Capital = "Cape Town"},
                new Data { Country = "Nigeria", Capital = "Abuja" },
                new Data { Country = "Singapore", Capital = "Singapore" }
            };
        }
    }
}