using System.Collections.Generic;

namespace SDKBrowserMaui.Examples.ListViewControl.StylingCategory.StyleSelectorExample
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new List<Person> {
                new Person("Tom", 25),
                new Person("Anna",18),
                new Person("Peter",43),
                new Person("Teodor",29),
                new Person("Lorenzo",65),
                new Person("Andrea",79),
                new Person("Martin",5) };
        }

        public List<Person> Source { get; set; }
    }
    // << listview-styleselector-source
}
