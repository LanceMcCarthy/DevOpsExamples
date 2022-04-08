using System;

namespace SalesDashboard.UWP.Models
{
    public class DailySalesInfoGrouping
    {
        public DateTime Date { get; set; }

        public decimal BikesValue { get; set; }

        public decimal ComponentsValue { get; set; }

        public decimal ClothingValue { get; set; }

        public decimal AccessoriesValue { get; set; }

        public decimal MinAllValues
        {
            get
            {
                var value = Math.Min(this.BikesValue, Math.Min(this.ComponentsValue, Math.Min(this.ClothingValue, this.AccessoriesValue)));
                return value;
            }
        }

        public decimal MaxAllValues
        {
            get
            {
                var value = Math.Max(this.BikesValue, Math.Max(this.ComponentsValue, Math.Max(this.ClothingValue, this.AccessoriesValue)));
                return value;
            }
        }

        public decimal TotalActualValue { get; set; }

        public decimal TotalTargetValue { get; set; }

        public decimal Profit => this.TotalActualValue - this.TotalTargetValue;
    }
}
