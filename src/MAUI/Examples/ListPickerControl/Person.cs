namespace SDKBrowserMaui.Examples.ListPickerControl
{
    // >> listpicker-getting-started-business-model
    public class Person
    {
        public Person(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.Name} {this.LastName}";
            }
        }
    }
    // << listpicker-getting-started-business-model
}
