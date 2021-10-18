using System;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Data
{
    // >> chart-ohlc-datapoint-csharp
    public class OhlcDataPoint : NotifyPropertyChangedBase
    {
        private DateTime category;
        private double open;
        private double high;
        private double low;
        private double close;

        public DateTime Category
        {
            get { return this.category; }
            set
            {
                if (value != this.category)
                {
                    this.category = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Open
        {
            get { return this.open; }
            set
            {
                if (value != this.open)
                {
                    this.open = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double High
        {
            get { return this.high; }
            set
            {
                if (value != this.high)
                {
                    this.high = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Low
        {
            get { return this.low; }
            set
            {
                if (value != this.low)
                {
                    this.low = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Close
        {
            get { return this.close; }
            set
            {
                if (value != this.close)
                {
                    this.close = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
    // << chart-ohlc-datapoint-csharp
}
