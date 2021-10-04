using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace SDKBrowserMaui.Examples.ListViewControl.GroupingCategory.MultiLevelGroupingExample
{
    public class LevelToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var level = (int)value;
                return new Thickness(((level - 1) * 20) + 8, 12, 0, 6);
            }
            else return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
