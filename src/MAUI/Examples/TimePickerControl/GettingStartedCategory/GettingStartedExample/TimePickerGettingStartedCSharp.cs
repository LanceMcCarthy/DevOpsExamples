using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Input;

namespace SDKBrowserMaui.Examples.TimePickerControl.GettingStartedCategory.GettingStartedExample
{
    public class TimePickerGettingStartedCSharp : RadContentView
    {
        public TimePickerGettingStartedCSharp()
        {
            // >> timepicker-getting-started-csharp
            var timePicker = new RadTimePicker();
            // << timepicker-getting-started-csharp
            var panel = new VerticalStackLayout();
            panel.Children.Add(timePicker);
            panel.Padding = new Thickness(10);
            this.Content = panel;
        }
    }
}
