using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SalesDashboard.UWP.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsReversed { get; set; }

        public object Convert(object value, Type typeName, object parameter, string language)
        {
            var val = System.Convert.ToBoolean(value);

            if (this.IsReversed)
            {
                val = !val;
            }

            return val ? Visibility.Visible : Visibility.Collapsed;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
