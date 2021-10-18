using SDKBrowserMaui.Data;
using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ChartControl.SeriesCategory
{
    // >> chart-series-series-numerical-view-model
    public class SeriesNumericalViewModel
    {
        public ObservableCollection<NumericalData> Data1 { get; set; }
        public ObservableCollection<NumericalData> Data2 { get; set; }

        public SeriesNumericalViewModel()
        {
            this.Data1 = GetNumericData1();
            this.Data2 = GetNumericData2();
        }

        public static ObservableCollection<NumericalData> GetNumericData1()
        {
            var data = new ObservableCollection<NumericalData>
            {
                new NumericalData { XData = 2, YData = 13 },
                new NumericalData { XData = 19, YData = 31 },
                new NumericalData { XData = 22, YData = 33 },
                new NumericalData { XData = 28, YData = 35 },
                new NumericalData { XData = 33, YData = 46 },
                new NumericalData { XData = 38, YData = 34 },
                new NumericalData { XData = 49, YData = 66 },
                new NumericalData { XData = 55, YData = 24 },
                new NumericalData { XData = 62, YData = 41 },
            };
            return data;
        }
        public static ObservableCollection<NumericalData> GetNumericData2()
        {
            var data = new ObservableCollection<NumericalData>
            {
                new NumericalData { XData = 7, YData = 13 },
                new NumericalData { XData = 19, YData = 17 },
                new NumericalData { XData = 22, YData = 19 },
                new NumericalData { XData = 28, YData = 21 },
                new NumericalData { XData = 33, YData = 35 },
                new NumericalData { XData = 38, YData = 43 },
                new NumericalData { XData = 49, YData = 15 },
                new NumericalData { XData = 55, YData = 21 },
                new NumericalData { XData = 62, YData = 47 },
            };
            return data;
        }
    }
    // << chart-series-series-numerical-view-model
}
