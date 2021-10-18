using System.ComponentModel;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.NumericInputControl.FeaturesCategory.BindingsExample
{
    public class ViewModel : NotifyPropertyChangedBase
    {
        private double step;
        private double value;
        private double minimum;
        private double maximum;
        public ViewModel()
        {
            this.Step = 1;
            this.Value = 0;
            this.Minimum = 0;
            this.Maximum = 5;
        }

        public double Maximum
        {
            get
            {
                return this.maximum;
            }

            set
            {
                this.UpdateValue(ref this.maximum, value);
            }
        }
        public double Minimum
        {
            get
            {
                return this.minimum;
            }

            set
            {
                this.UpdateValue(ref this.minimum, value);
            }
        }
        public double Step
        {
            get
            {
                return this.step;
            }

            set
            {
                this.UpdateValue(ref this.step, value);
            }
        }
        public double Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.UpdateValue(ref this.value, value);
            }
        }
    }
}