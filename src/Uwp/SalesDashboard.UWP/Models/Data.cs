using System.Collections.Generic;
using Telerik.Core;

namespace SalesDashboard.UWP.Models
{
    public class Data : ViewModelBase
    {
        public List<SubData> ChartItems { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public string Price { get; set; }
        public double Percent { get; set; }
        public string Type { get; set; }
        public string Order { get; set; }
        public string Date { get; set; }
        public string ItemSold { get; set; }
        public string Country { get; set; }
        public string Amount { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
