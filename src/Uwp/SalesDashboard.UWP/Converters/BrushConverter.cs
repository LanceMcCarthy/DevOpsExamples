using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SalesDashboard.UWP.Converters
{
    internal class BrushConverter :IValueConverter
    {
        public Brush BikesBrush { get; set; }
        public Brush ComponentsBrush { get; set; }
        public Brush ClothingBrush { get; set; }
        public Brush AccessoriesBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (System.Convert.ToString(value))
            {
                case "Bikes": return this.BikesBrush;
                case "Components": return this.ComponentsBrush;
                case "Accessories": return this.AccessoriesBrush;
                case "Clothing": return this.ClothingBrush;
                default:
                    break;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

       
    }
}
