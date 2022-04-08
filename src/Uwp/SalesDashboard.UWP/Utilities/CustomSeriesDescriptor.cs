using System;
using Windows.UI.Xaml;
using SalesDashboard.UWP.Models;
using Telerik.UI.Xaml.Controls.Chart;

namespace SalesDashboard.UWP.Utilities
{
    public class CustomSeriesDescriptor : ChartSeriesDescriptor
    {
       public DataTemplate IntersectionPointTemplate { get; set; }
       public DataTemplate TrackInfoTemplate { get; set; }   

        protected override ChartSeries CreateInstanceCore(object context)
        {
            var data = context as Data;

            var lineSeries = new LineSeries
            {
                ValueBinding = new PropertyNameDataPointBinding("ActualAmount"),
                CategoryBinding = new PropertyNameDataPointBinding("OrderDate")
            };

            ChartTrackBallBehavior.SetIntersectionTemplate(lineSeries, IntersectionPointTemplate);

            ChartTrackBallBehavior.SetTrackInfoTemplate(lineSeries, TrackInfoTemplate);

            return lineSeries;
        }

        public override Type DefaultType => typeof(LineSeries);
    }
}
