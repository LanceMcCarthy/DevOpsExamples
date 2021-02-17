using System;
using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace XamForms.Portable
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DataGridData = new ObservableCollection<Person>(SampleDataService.Current.GeneratePeopleData(true));
            ChartData = new ObservableCollection<ChartDataPoint>(SampleDataService.Current.GenerateCategoricalData());
        }

        public ObservableCollection<Person> DataGridData { get; set; }

        public ObservableCollection<ChartDataPoint> ChartData { get; set; }
    }
}