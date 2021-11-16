using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.TemplatedPickerControl
{
    // >> templatedpicker-country-businessmodel
    public class Country : NotifyPropertyChangedBase
    {
        private string name;

        public Country()
        {
            this.Cities = new ObservableCollection<City>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != this.name)
                {
                    this.UpdateValue(ref this.name, value);
                }
            }
        }

        public ObservableCollection<City> Cities { get; }
    }
    // << templatedpicker-country-businessmodel
}
