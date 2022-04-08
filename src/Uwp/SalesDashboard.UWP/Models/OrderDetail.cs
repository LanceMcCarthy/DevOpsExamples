using System;

namespace SalesDashboard.UWP.Models
{
    public class OrderDetail
    {
        public string SalesOrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int ItemsSold { get; set; }

        public decimal SalesAmount { get; set; }

        public string Country { get; set; }

        public string Products { get; set; }
    }
}
