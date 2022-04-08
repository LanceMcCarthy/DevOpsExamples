using System;
using Windows.UI.Xaml.Data;
using Telerik.UI.Xaml.Controls.Chart;

namespace SalesDashboard.UWP.Converters
{
    internal class IntersectionPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var info = value as DataPointInfo;
            var palette = parameter as ChartPalette;

            var brush = palette.GetBrush(info.Series.ActualPaletteIndex, PaletteVisualPart.Fill);
         
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}