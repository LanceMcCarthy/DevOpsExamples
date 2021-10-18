using System.Collections.ObjectModel;

namespace SDKBrowserMaui.Examples.ChartControl.SeriesCategory
{
    // >> chart-series-series-categorical-view-model
    public class SeriesCategoricalViewModel
    {
        public ObservableCollection<CategoricalData> Data1 { get; set; }
        public ObservableCollection<CategoricalData> Data2 { get; set; }

        public SeriesCategoricalViewModel()
        {
            this.Data1 = GetCategoricalData1();
            this.Data2 = GetCategoricalData2();
        }

        private static ObservableCollection<CategoricalData> GetCategoricalData1()
        {
            var data = new ObservableCollection<CategoricalData>
            {
                new CategoricalData { Category = "Greenings", Value = 52 },
                new CategoricalData { Category = "Perfecto", Value = 19 },
                new CategoricalData { Category = "NearBy", Value = 82 },
                new CategoricalData { Category = "Family", Value = 23 },
                new CategoricalData { Category = "Fresh", Value = 56 },
            };
            return data;
        }

        private static ObservableCollection<CategoricalData> GetCategoricalData2()
        {
            var data = new ObservableCollection<CategoricalData>
            {
                new CategoricalData { Category = "Greenings", Value = 33 },
                new CategoricalData { Category = "Perfecto", Value = 51 },
                new CategoricalData { Category = "NearBy", Value = 11 },
                new CategoricalData { Category = "Family", Value = 94 },
                new CategoricalData { Category = "Fresh", Value = 12 },
            };
            return data;
        }
    }
    // << chart-series-series-categorical-view-model
}
