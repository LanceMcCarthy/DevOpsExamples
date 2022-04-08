using System;
using Windows.UI.Xaml.Data;

namespace SalesDashboard.UWP.Converters
{
    public class StringFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is DateTime time)
			{
				if (parameter is string s)
				{
					if (s.StartsWith("#"))
					{
						return time.ToString(s.Substring(1));
					}
					else if (DateTime.Today.CompareTo(time.Date) == 0)
					{
						return "today";
					}
					else
					{
						return time.ToString(s);
					}
				}
			}

            if (parameter == null) 
                return value;

            switch (value)
            {
                case double _:
                    return double.Parse(value.ToString()).ToString(parameter.ToString());
                case decimal _:
                    return decimal.Parse(value.ToString()).ToString(parameter.ToString());
            }

            return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value is string s)
            {
                return string.Equals(s, "today", StringComparison.CurrentCultureIgnoreCase) 
                    ? DateTime.Now 
                    : DateTime.Parse(s);
            }

			return null;
		}
	}
}
