using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.FilteringCategory.BindableFilterDescriptorExample
{
    // >> listview-features-filtering-data-class
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    // << listview-features-filtering-data-class

    public class ViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<FilterDescriptorBase> filterDescriptors;
        private bool isFilterSwitchToggled;

        public ViewModel()
        {
            this.Items = GetData();
            this.filterDescriptors = new ObservableCollection<FilterDescriptorBase>();
        }

        public ObservableCollection<Person> Items { get; set; }

        public ObservableCollection<FilterDescriptorBase> FilterDescriptors
        {
            get { return this.filterDescriptors; }
            set { this.UpdateValue(ref this.filterDescriptors, value); }
        }

        public bool IsFilterSwitchToggled
        {
            get { return this.isFilterSwitchToggled; }
            set
            {
                this.UpdateValue(ref this.isFilterSwitchToggled, value);
                UpdateExistingFilterDescriptor("IsFilterSwitchToggled");
            }
        }

        private static ObservableCollection<Person> GetData()
        {
            var items = new ObservableCollection<Person>();

            items.Add(new Person { Name = "Tom", Age = 41 });
            items.Add(new Person { Name = "Anna", Age = 32 });
            items.Add(new Person { Name = "Peter", Age = 28 });
            items.Add(new Person { Name = "Teodor", Age = 39 });
            items.Add(new Person { Name = "Lorenzo", Age = 25 });
            items.Add(new Person { Name = "Andrea", Age = 33 });
            items.Add(new Person { Name = "Martin", Age = 36 });
            items.Add(new Person { Name = "Alexander", Age = 29 });
            items.Add(new Person { Name = "Maria", Age = 22 });
            items.Add(new Person { Name = "Elena", Age = 27 });
            items.Add(new Person { Name = "Stefano", Age = 44 });
            items.Add(new Person { Name = "Jake", Age = 31 });
            items.Add(new Person { Name = "Leon", Age = 28 });

            return items;
        }
        private void UpdateExistingFilterDescriptor(string propertyName)
        {
            if (this.FilterDescriptors == null)
                return;

            if (this.FilterDescriptors.Count == 0)
            {
                this.FilterDescriptors.Add(new DelegateFilterDescriptor()
                {
                    Filter = new Func<object, bool>((item) => ((Person)item).Name.Equals("A"))
                });
            }

            if (propertyName.Equals(nameof(IsFilterSwitchToggled)))
            {
                ((DelegateFilterDescriptor)this.FilterDescriptors.FirstOrDefault()).Filter =
                                this.isFilterSwitchToggled ?
                                new Func<object, bool>((item) => ((Person)item).Name.StartsWith("T")) :
                                new Func<object, bool>((item) => ((Person)item).Name.StartsWith("A"));
            }
        }
        // << listview-features-filtering-viewmodel
    }
}
