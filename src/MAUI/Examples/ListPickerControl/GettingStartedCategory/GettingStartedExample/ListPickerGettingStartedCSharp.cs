using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Input;

namespace SDKBrowserMaui.Examples.ListPickerControl.GettingStartedCategory.GettingStartedExample
{
    public class ListPickerGettingStartedCSharp : RadContentView
    {
        public ListPickerGettingStartedCSharp()
        {
            // >> listpicker-getting-started-csharp
            this.BindingContext = new PeopleViewModel();
            var listPicker = new RadListPicker()
            {
                Placeholder = "Pick a name!",
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center
                    };
                    label.SetBinding(Label.TextProperty, new Binding(nameof(Person.Name)));

                    return label;
                }),
                DisplayMemberPath = "FullName"
            };
            listPicker.SetBinding(RadListPicker.ItemsSourceProperty, new Binding("Items"));
            // << listpicker-getting-started-csharp
            var panel = new VerticalStackLayout();
            panel.Children.Add(listPicker);
            panel.Padding = new Thickness(10);
            this.Content = panel;
        }
    }
}
