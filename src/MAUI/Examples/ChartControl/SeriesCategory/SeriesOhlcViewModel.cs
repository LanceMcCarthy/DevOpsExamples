using SDKBrowserMaui.Data;
using System;
using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ChartControl.SeriesCategory
{
    public class SeriesOhlcViewModel
    {
        public SeriesOhlcViewModel()
        {
            this.SeriesData = new ObservableCollection<OhlcDataPoint>();
            this.SeriesData.Add(new OhlcDataPoint() { High = 10, Open = 5, Low = 2, Close = 8, Category = new DateTime(1990, 1, 1) });
            this.SeriesData.Add(new OhlcDataPoint() { High = 15, Open = 7, Low = 3, Close = 5, Category = new DateTime(1990, 2, 1) });
            this.SeriesData.Add(new OhlcDataPoint() { High = 20, Open = 15, Low = 10, Close = 19, Category = new DateTime(1990, 3, 1) });
            this.SeriesData.Add(new OhlcDataPoint() { High = 7, Open = 2, Low = 1, Close = 5, Category = new DateTime(1990, 4, 1) });
            this.SeriesData.Add(new OhlcDataPoint() { High = 25, Open = 15, Low = 10, Close = 12, Category = new DateTime(1990, 5, 1) });
        }
        public ObservableCollection<OhlcDataPoint> SeriesData { get; private set; }
    }
}
