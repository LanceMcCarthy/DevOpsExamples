using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesDashboard.UWP.Models;
using SalesDashboard.UWP.Utilities;
using Telerik.Core;

namespace Sales_Dashboard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            var suppresionVariable = this.LoadData();
            this.StartDate = this.EndDate = this.MinDate;
            this.IsWeekPresetSelected = true;
        }

        private IEnumerable<SalesAmount> salesAccessiories;
        bool isPresetSelectionInProgress;

        private bool isWeekPresetSelected;

        public bool IsWeekPresetSelected
        {
            get => this.isWeekPresetSelected;
            set
            {
                this.isPresetSelectionInProgress = true;
                if (this.isWeekPresetSelected != value)
                {
                    this.isWeekPresetSelected = value;
                    this.OnPropertyChanged();
                }
                if (value)
                {
                    this.EffectiveEndDate = this.StartDate.AddDays(7) <= this.MaxDate ? this.StartDate.AddDays(7) : this.MaxDate;
                }
                this.isPresetSelectionInProgress = false;
            }
        }

        private bool isMonthPresetSelected;

        public bool IsMonthPresetSelected
        {
            get => isMonthPresetSelected;
            set
            {
                this.isPresetSelectionInProgress = true;

                if (isMonthPresetSelected != value)
                {
                    isMonthPresetSelected = value;
                }
                if (value)
                {
                    this.EffectiveEndDate = this.StartDate.AddMonths(1) <= this.MaxDate ? this.StartDate.AddMonths(1) : this.MaxDate;
                }

                this.isPresetSelectionInProgress = false;
            }
        }

        private bool isThreeMonthsSelected;

        public bool IsThreeMonthsSelected
        {
            get => isThreeMonthsSelected;
            set
            {
                this.isPresetSelectionInProgress = true;
                if (isThreeMonthsSelected != value)
                {
                    isThreeMonthsSelected = value;
                    this.OnPropertyChanged();
                }
                if (value)
                {
                    this.EffectiveEndDate = this.StartDate.AddMonths(3) <= this.MaxDate ? this.StartDate.AddMonths(3) : this.MaxDate;
                }
                this.isPresetSelectionInProgress = false;
            }
        }

        private bool isSixMonthsSelected;

        public bool IsSixMonthsSelected
        {
            get => isSixMonthsSelected;
            set
            {
                this.isPresetSelectionInProgress = true;
                if (isSixMonthsSelected != value)
                {
                    isSixMonthsSelected = value;
                    this.OnPropertyChanged();
                }
                if (value)
                {
                    this.EffectiveEndDate = this.StartDate.AddMonths(6) <= this.MaxDate ? this.StartDate.AddMonths(6) : this.MaxDate;
                }
                this.isPresetSelectionInProgress = false;
            }
        }


        private IEnumerable<OrderDetail> orderDetails;

        public IEnumerable<OrderDetail> OrderDetails
        {
            get
            {
                return this.orderDetails == null 
                    ? null 
                    : orderDetails.Where(item => item.OrderDate <= this.EffectiveEndDate && item.OrderDate >= this.StartDate);
            }
        }

        public IEnumerable<SalesAmount> SalesAmount { get; private set; }

        private IEnumerable<SalesAmount> actualTrendData;

        public IEnumerable<SalesAmount> ActualTrendData
        {
            get
            {
                if (this.actualTrendData == null && this.SalesAmount != null)
                {
                    var dataGroupedByDate = from all in this.SalesForPeriod
                                            group all by all.OrderDate into result
                                            select result;

                    var resultData = dataGroupedByDate.Select(x => new SalesAmount()
                    {
                        TargetAmount = x.Sum(y => y.TargetAmount),
                        ActualAmount = x.Sum(y => y.ActualAmount),
                        OrderDate = x.FirstOrDefault().OrderDate
                    });

                    this.actualTrendData = resultData.Count() != 0 ? resultData.OrderBy(c => c.OrderDate).ToList() : null;
                }

                return this.actualTrendData;
            }

            set
            {
                this.actualTrendData = null;

                this.OnPropertyChanged();
            }
        }

        private IEnumerable<SalesAmount> targetTrendData;

        public IEnumerable<SalesAmount> TargetTrendData
        {
            get
            {
                if (this.targetTrendData == null)
                {
                    if (this.ActualTrendData != null)
                    {
                        this.targetTrendData = this.ActualTrendData.Where(a => a.TargetAmount != null && a.TargetAmount != 0m);
                    }
                }
                return this.targetTrendData;
            }
            set
            {
                this.targetTrendData = null;
                this.OnPropertyChanged();
            }
        }

        private DateTime startDate;
        private DateTime endDate;

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    this.ClearPresets();
                    this.OnPropertyChanged();
                    this.Update();
                }
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    if (!this.isPresetSelectionInProgress)
                    {
                        this.ClearPresets();
                    }
                    this.EffectiveEndDate = value;
                    this.OnPropertyChanged();
                }

            }
        }

        public DateTime MaxDate => new DateTime(2015, 07, 30);

        public DateTime MinDate => new DateTime(2015, 01, 01);

        private DateTime effectiveEndDate;
        public DateTime EffectiveEndDate
        {
            get => this.effectiveEndDate;
            set
            {
                if (this.effectiveEndDate != value)
                {
                    this.effectiveEndDate = value;
                    this.EndDate = value;
                    this.OnPropertyChanged();
                    this.Update();
                }
            }
        }

        private IEnumerable<SalesAmount> salesForPeriod;

        public IEnumerable<SalesAmount> SalesForPeriod
        {
            get
            {
                if (salesForPeriod == null && this.SalesAmount != null)
                {

                    salesForPeriod = (from c in this.SalesAmount where c.OrderDate >= this.StartDate && c.OrderDate <= EffectiveEndDate select c).ToList();
                }
                return this.salesForPeriod;
            }
            private set
            {
                salesForPeriod = value;
                this.OnPropertyChanged();
            }

        }

        private IEnumerable<SalesAmount> salesBikes;

        public IEnumerable<SalesAmount> SalesBikes
        {
            get
            {
                if (salesBikes == null && this.SalesForPeriod != null)
                {
                    salesBikes = (this.SalesForPeriod.Where(c => c.ProductCategory == "Bikes")
                        .GroupBy(c => c.OrderDate)
                        .OrderBy(c => c.Key)
                        .Select(s => new SalesAmount { ActualAmount = s.Sum(d => d.ActualAmount), OrderDate = s.Key, TargetAmount = s.Sum(d => d.TargetAmount), ProductCategory = s.First().ProductCategory }).ToList());
                }
                return this.salesBikes;
            }

            private set
            {
                salesBikes = value;
                this.OnPropertyChanged();
            }
        }

        private IEnumerable<SalesAmount> salesComponents;

        public IEnumerable<SalesAmount> SalesComponents
        {
            get
            {
                if (salesComponents == null && this.SalesForPeriod != null)
                {
                    salesComponents = (this.SalesForPeriod.Where(c => c.ProductCategory == "Components")
                         .GroupBy(c => c.OrderDate)
                        .OrderBy(c => c.Key)
                        .Select(c => new SalesAmount { ActualAmount = c.Sum(d => d.ActualAmount), OrderDate = c.Key, TargetAmount = c.Sum(d => d.TargetAmount), ProductCategory = c.First().ProductCategory })).ToList();
                }

                return salesComponents;
            }

            private set
            {
                salesComponents = value;
                this.OnPropertyChanged();
            }
        }

        private IEnumerable<SalesAmount> salesClothing;

        public IEnumerable<SalesAmount> SalesClothing
        {
            get
            {
                if (salesClothing == null && this.SalesForPeriod != null)
                {
                    salesClothing = (this.SalesForPeriod.Where(c => c.ProductCategory == "Clothing")
                         .GroupBy(c => c.OrderDate)
                        .OrderBy(c => c.Key)
                        .Select(c => new SalesAmount { ActualAmount = c.Sum(d => d.ActualAmount), OrderDate = c.Key, TargetAmount = c.Sum(d => d.TargetAmount), ProductCategory = c.First().ProductCategory })).ToList();
                }

                return salesClothing;
            }
            private set
            {
                salesClothing = value;
                this.OnPropertyChanged();
            }
        }

        public IEnumerable<SalesAmount> SalesAccessiories
        {
            get
            {
                if (salesAccessiories == null)
                {
                    salesAccessiories = (this.SalesForPeriod
                        .Where(c => c.ProductCategory == "Accessories")
                        .GroupBy(c => c.OrderDate)
                        .OrderBy(c => c.Key)
                        .Select(c => new SalesAmount { ActualAmount = c.Sum(d => d.ActualAmount), OrderDate = c.Key, TargetAmount = c.Sum(d => d.TargetAmount), ProductCategory = c.First().ProductCategory })
                        ).ToList();
                }

                return salesAccessiories;
            }
            private set
            {
                salesAccessiories = value;
                this.OnPropertyChanged();
            }
        }

        private List<IEnumerable<SalesAmount>> totalTrendSalesByProducts;

        public List<IEnumerable<SalesAmount>> TotalTrendSalesByProducts
        {
            get
            {
                if (totalTrendSalesByProducts == null && this.SalesForPeriod != null)
                {
                    totalTrendSalesByProducts = new List<IEnumerable<SalesAmount>>
                {
                    this.SalesBikes,
                                        this.SalesClothing,
                    this.SalesAccessiories,

                    this.SalesComponents
                };
                }

                return totalTrendSalesByProducts;
            }
            set
            {
                totalTrendSalesByProducts = value;
                this.OnPropertyChanged();
            }
        }

        private List<SalesAmount> totalSalesByProducts;

        public List<SalesAmount> TotalSalesByProducts
        {
            get
            {
                if (totalSalesByProducts == null && this.SalesForPeriod != null)
                {
                    totalSalesByProducts = new List<SalesAmount>
                {
                   
                  
                  
            

                    new SalesAmount{ProductCategory = SalesComponents.Any()?SalesBikes.First().ProductCategory:null, ActualAmount = SalesBikes.Select(c=>c.ActualAmount).Sum(), TargetAmount = SalesBikes.Select(c=>c.TargetAmount).Sum()},
                    new SalesAmount{ProductCategory = SalesComponents.Any()?SalesClothing.First().ProductCategory:null, ActualAmount = SalesClothing.Select(c=>c.ActualAmount).Sum(), TargetAmount = SalesClothing.Select(c=>c.TargetAmount).Sum()},
                    new SalesAmount{ProductCategory = SalesComponents.Any()?SalesAccessiories.First().ProductCategory:null, ActualAmount = SalesAccessiories.Select(c=>c.ActualAmount).Sum(), TargetAmount = SalesAccessiories.Select(c=>c.TargetAmount).Sum()},  
                                        new SalesAmount{ProductCategory = SalesComponents.Any()? SalesComponents.First().ProductCategory:null, ActualAmount = SalesComponents.Select(c=>c.ActualAmount).Sum(), TargetAmount = SalesComponents.Select(c=>c.TargetAmount).Sum()},
                   
                };
                }

                return totalSalesByProducts;
            }
            set
            {
                totalSalesByProducts = value;
                this.OnPropertyChanged();
            }
        }

        private List<object> totalSalesByCountries;

        public List<object> TotalSalesByCountries
        {
            get
            {
                if (totalSalesByCountries == null && this.SalesForPeriod != null)
                {
                    totalSalesByCountries =
                        (from c in this.SalesForPeriod
                         group c by c.Country into countrySales
                         orderby countrySales.Key
                         select new
                         {
                             Country = countrySales.Key,
                             Items = from cs in countrySales
                                     group cs by cs.ProductCategory into totalCS
                                     select new ChartData
                                     {
                                         Category = totalCS.Key,
                                         Value = totalCS.Sum(c => c.ActualAmount)
                                     }
                         }).ToList<object>();
                }

                return totalSalesByCountries;
            }
            set
            {
                totalSalesByCountries = value;
                this.OnPropertyChanged();
            }
        }

        private decimal totalSalesActualAmount;

        public decimal TotalSalesActualAmount
        {
            get
            {
                if (totalSalesActualAmount == 0 && this.SalesForPeriod != null)
                {
                    totalSalesActualAmount = this.SalesForPeriod.Sum(c => c.ActualAmount);
                }
                return totalSalesActualAmount;
            }

            set
            {
                totalSalesActualAmount = value;
                this.OnPropertyChanged();
            }
        }

        private async Task LoadData()
        {
            this.SalesAmount = await CSVParser.LoadSalesAmount();
            this.orderDetails = await CSVParser.LoadDetails();

            this.Update();
        }

        private void Update()
        {
            this.SalesForPeriod = null;
            this.SalesAccessiories = null;
            this.SalesBikes = null;
            this.SalesClothing = null;
            this.SalesComponents = null;
            this.TotalTrendSalesByProducts = null;
            this.TotalSalesByProducts = null;
            this.TotalSalesByCountries = null;
            this.TotalSalesActualAmount = 0;

            this.OnPropertyChanged("EffectiveEndDate");
            this.OnPropertyChanged("OrderDetails");
            this.ActualTrendData = null;
            this.TargetTrendData = null;
        }

        private void ClearPresets()
        {
            this.IsWeekPresetSelected = false;
            this.IsMonthPresetSelected = false;
            this.IsThreeMonthsSelected = false;
            this.IsSixMonthsSelected = false;
        }
    }
}
