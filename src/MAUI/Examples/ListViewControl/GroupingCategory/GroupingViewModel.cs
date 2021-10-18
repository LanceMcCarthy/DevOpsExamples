using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.GroupingCategory
{
    public class GroupingViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<City> Cities { get; set; }

        public GroupingViewModel()
        {
            this.Cities = new ObservableCollection<City>()
            {
                new City() { Name = "Barcelona", Country = "Spain", Continent = "Europe"},
                new City() { Name = "Madrid", Country = "Spain", Continent = "Europe" },
                new City() { Name = "Rome", Country = "Italy", Continent = "Europe" },
                new City() { Name = "Florence", Country = "Italy", Continent = "Europe" },
                new City() { Name = "London", Country = "England", Continent = "Europe" },
                new City() { Name = "Manchester", Country = "England", Continent = "Europe"},
                new City() { Name = "New York", Country = "USA", Continent = "North America" },
                new City() { Name = "Boston", Country = "USA",  Continent = "North America" }
             };
        }
    }
}
