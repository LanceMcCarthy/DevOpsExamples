using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Windows.Input;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.NumericInputControl.FeaturesCategory.CommandsExample
{
    // >> numericinput-features-commands-viewmodel
    public class CommandsViewModel : NotifyPropertyChangedBase
    {
        private double value;
        public CommandsViewModel()
        {
            this.CustomIncreaseCommand = new Command(this.IncreaseCommandExecute, this.IncreaseCommandCanExecute);
            this.CustomDecreaseCommand = new Command(this.DecreaseCommandExecute, this.DecreaseCommandCanExecute);
            this.Step = 2;
            this.Value = 0;
            this.Minimum = 0;
            this.Maximum = 6;
        }
        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public double Step { get; set; }
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
        public ICommand CustomDecreaseCommand { get; set; }
        public ICommand CustomIncreaseCommand { get; set; }
        private bool DecreaseCommandCanExecute(object arg)
        {
            return true;
        }
        private void DecreaseCommandExecute(object obj)
        {
            double newValue = this.Value - this.Step;
            if (newValue >= this.Minimum)
                this.Value = newValue;
            else
                this.Value = this.Maximum;
        }
        private bool IncreaseCommandCanExecute(object arg)
        {
            return true;
        }
        private void IncreaseCommandExecute(object obj)
        {
            double nextValue = this.Value + this.Step;
            if (nextValue <= this.Maximum)
                this.Value = nextValue;
            else
                this.Value = this.Minimum;
        }
    }
    // << numericinput-features-commands-viewmodel
}
