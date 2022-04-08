using System;
using Windows.UI.Xaml.Data;

namespace SalesDashboard.UWP.Converters
{
    public class StringAppendConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

            if (!(value is int i)) 
                return value;

            if (parameter == null)
            {
                return i;
            }
            else
            {
                var suffix = parameter.ToString();

                if (i != 1)
                {
                    suffix = parameter.ToString() + "s";
                }

                return i + " " + suffix;
            }

        }

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
