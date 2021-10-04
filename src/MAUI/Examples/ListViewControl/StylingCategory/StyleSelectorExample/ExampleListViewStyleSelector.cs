using Microsoft.Maui.Graphics;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.StylingCategory.StyleSelectorExample
{

    // >> listview-features-onselectstyle
    public class ExampleListViewStyleSelector : ListViewStyleSelector
    {
        protected override void OnSelectStyle(object item, ListViewStyleContext styleContext)
        {
            var style = new ListViewItemStyle
            {
                BackgroundColor = Colors.Transparent
            };

            styleContext.ItemStyle = style;
            styleContext.SelectedItemStyle = new ListViewItemStyle
            {
                BackgroundColor = Colors.Gray,
                BorderColor = Colors.Red,
                BorderWidth = 2
            };

            var sourceItem = item as Person;
            if (sourceItem.Age < 18)
            {
                styleContext.ItemStyle.BackgroundColor = Colors.Blue;
            }
            else if (sourceItem.Age < 65)
            {
                styleContext.ItemStyle.BackgroundColor = Colors.Green;
            }
        }
    }

    // << listview-features-onselectstyle
}
