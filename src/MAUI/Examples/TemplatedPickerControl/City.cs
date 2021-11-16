using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.TemplatedPickerControl
{
    // >> templatedpicker-city-businessmodel
    public class City : NotifyPropertyChangedBase
    {
        private string name;

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
    }
    // << templatedpicker-city-businessmodel
}
