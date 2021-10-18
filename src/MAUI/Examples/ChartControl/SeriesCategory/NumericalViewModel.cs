using SDKBrowserMaui.Data;
using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ChartControl.SeriesCategory
{
    // >> chart-series-numerical-view-model
    public class NumericalViewModel
    {
        public ObservableCollection<NumericalData> Data { get; set; }

        public NumericalViewModel()
        {
            this.Data = GetNumericData();
        }

        public static ObservableCollection<NumericalData> GetNumericData()
        {
            var data = new ObservableCollection<NumericalData>
            {
                new NumericalData { XData = 4, YData = 9 },
                new NumericalData { XData = 8, YData = 10 },
                new NumericalData { XData = 9, YData = 13 },
                new NumericalData { XData = 12, YData = 24 },
                new NumericalData { XData = 17, YData = 24 },
                new NumericalData { XData = 21, YData = 4 },
                new NumericalData { XData = 26, YData = 13 },
                new NumericalData { XData = 29, YData = 3 },
                new NumericalData { XData = 30, YData = 16 },
            };
            return data;
        }
    }
    // << chart-series-numerical-view-model
}
