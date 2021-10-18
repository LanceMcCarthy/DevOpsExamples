using System.Collections.Generic;

namespace SDKBrowserMaui.Examples.ListViewControl.StylingCategory.ItemStylesExample
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new List<Person> { new Person("Tom"), new Person("Anna"), new Person("Peter"), new Person("Teodor"), new Person("Lorenzo"), new Person("Andrea"), new Person("Martin") };
        }

        public List<Person> Source { get; set; }
    }
    // << listview-itemstyles-source
}