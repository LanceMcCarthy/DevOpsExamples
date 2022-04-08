using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Telerik.Charting;
using Telerik.UI.Xaml.Controls.Chart;

namespace SalesDashboard.UWP.Converters
{
    internal class DataPointToBrush: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var info = value as DataPointInfo;

            if (parameter is ChartPalette palette)
            {
                return palette.GetBrush((info.Series as BarSeries).DataPoints.IndexOf(info.DataPoint as CategoricalDataPoint), PaletteVisualPart.Fill);
            }

            return new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
