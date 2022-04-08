using System;

namespace SalesDashboard.UWP.Models
{
    public class SalesAmount
    {
        public decimal? TargetAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal ActualAmount { get; set; }

        public string ProductCategory { get; set; }

        public string Country { get; set; }
    }
}
