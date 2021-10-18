using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ListViewControl.FilteringCategory.FilterDescriptorExample
{
    // >> listview-features-filtering-data-class
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    // << listview-features-filtering-data-class

    public class ViewModel
    {
        public ViewModel()
        {
            this.Items = GetData();
        }

        public ObservableCollection<Person> Items { get; set; }

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
    }
    // << listview-features-filtering-viewmodel
}
