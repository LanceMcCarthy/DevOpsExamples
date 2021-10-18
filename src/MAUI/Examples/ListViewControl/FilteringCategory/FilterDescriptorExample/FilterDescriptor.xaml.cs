using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;

namespace SDKBrowserMaui.Examples.ListViewControl.FilteringCategory.FilterDescriptorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterDescriptor : RadContentView
    {
        public FilterDescriptor()
        {
            InitializeComponent();

            this.listView.FilterDescriptors.Add(new Telerik.XamarinForms.DataControls.ListView.DelegateFilterDescriptor { Filter = this.AgeFilter });
        }

        private bool AgeFilter(object arg)
        {
            var age = ((Person)arg).Age;
            return age >= 25 && age <= 35;
        }
    }
}