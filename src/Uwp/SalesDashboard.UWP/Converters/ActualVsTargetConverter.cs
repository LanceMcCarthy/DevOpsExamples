using System;
using Windows.UI.Xaml.Data;
using SalesDashboard.UWP.Models;

namespace SalesDashboard.UWP.Converters
{
    internal class ActualVsTargetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is SalesAmount am && am.TargetAmount > 0)
            {
                return $"{am.ActualAmount / am.TargetAmount * 100:N0}";
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
