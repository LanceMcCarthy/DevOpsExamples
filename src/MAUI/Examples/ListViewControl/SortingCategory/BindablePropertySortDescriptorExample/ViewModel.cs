using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.SortingCategory.BindablePropertySortDescriptorExample
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class ViewModel : NotifyPropertyChangedBase
    {
        private bool isPropertyNameSortSwitchToggled;
        private bool isSortOrderSortSwitchToggled;
        private ObservableCollection<SortDescriptorBase> sortDescriptors;

        public ViewModel()
        {
            this.Items = GetData();
            this.sortDescriptors = new ObservableCollection<SortDescriptorBase>();
        }

        public bool IsPropertyNameSortSwitchToggled
        {
            get { return this.isPropertyNameSortSwitchToggled; }
            set { 
                this.UpdateValue(ref this.isPropertyNameSortSwitchToggled, value);
                UpdateExistingSortDescriptor("IsPropertyNameSortSwitchToggled"); 
              }
        }

        public bool IsSortOrderSortSwitchToggled
        {
            get { return this.isSortOrderSortSwitchToggled; }
            set { this.UpdateValue(ref this.isSortOrderSortSwitchToggled, value);
                UpdateExistingSortDescriptor("IsSortOrderSortSwitchToggled");
            }
        }

        public ObservableCollection<Person> Items { get; set; }

        // >> listview-features-bindable-sortdescriptor-viewmodel
        public ObservableCollection<SortDescriptorBase> SortDescriptors
        {
            get
            {
                return this.sortDescriptors;
            }
            set
            {
                if (this.sortDescriptors != value)
                {
                    this.sortDescriptors = value;
                    OnPropertyChanged();
                }
            }
        }
        // << listview-features-bindable-sortdescriptor-viewmodel
      
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

        private void UpdateExistingSortDescriptor(string propertyToUpdate)
        {
            if (this.SortDescriptors == null)
                return;

            if (this.SortDescriptors.Count == 0)
            {
                this.SortDescriptors.Add(new PropertySortDescriptor()
                {
                    PropertyName = "Day",
                    SortOrder = SortOrder.Ascending
                });
            }

            if (propertyToUpdate.Equals(nameof(IsSortOrderSortSwitchToggled)))
            {
                var descriptor = (PropertySortDescriptor)this.SortDescriptors.FirstOrDefault();
                descriptor.SortOrder = isSortOrderSortSwitchToggled ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (propertyToUpdate.Equals(nameof(IsPropertyNameSortSwitchToggled)))
            {
                var descriptor = (PropertySortDescriptor)this.SortDescriptors.FirstOrDefault();
                descriptor.PropertyName = isPropertyNameSortSwitchToggled ? "Name" : "Age";
            }
        }
    }
}
