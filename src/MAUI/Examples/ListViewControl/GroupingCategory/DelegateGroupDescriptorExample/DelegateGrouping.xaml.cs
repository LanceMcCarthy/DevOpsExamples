using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.GroupingCategory.DelegateGroupDescriptorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelegateGrouping : RadContentView
    {
        public DelegateGrouping()
        {
            InitializeComponent();

            var delegateDescriptor = new DelegateGroupDescriptor
            {
                KeyExtractor = FirstLetterKeyExtractor
            };

            listView.GroupDescriptors.Add(delegateDescriptor);
        }

        private object FirstLetterKeyExtractor(object arg)
        {
            var item = arg as City;
            return item?.Name.Substring(0, 1);
        }
    }
}