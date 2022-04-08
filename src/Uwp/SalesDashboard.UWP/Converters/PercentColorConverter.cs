using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using SalesDashboard.UWP.Models;

namespace SalesDashboard.UWP.Converters
{
    public class PercentColorConverter : IValueConverter
    {
        public Brush Positive { get; set; }
        public Brush Negative { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is SalesAmount am && am.TargetAmount < am.ActualAmount)
            {
                return this.Positive;
            }

            return this.Negative;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
