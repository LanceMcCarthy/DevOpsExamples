using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;
using Telerik.Maui.MaskedEntry;

namespace SDKBrowserMaui.Examples.MaskedEntryControl.EventsCategory.EventsExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Events : RadContentView
    {
        public Events()
        {
            InitializeComponent();
        }

        private void emailMaskedEntry_ValueChanged(object sender, MaskedEntryValueChangedEventArgs e)
        {
            this.emailMaskNewValue.Text = e.Value.ToString();
            this.emailMaskNewText.Text = e.Text;
            this.emailMaskIsValid.Text = e.IsValid.ToString();
        }

        private void EmailMaskedEntry_ValueChanging(object sender, MaskedEntryValueChangingEventArgs e)
        {
            e.Cancel = (bool) emailMaskCancelValueChanging.IsChecked;
            this.emailMaskNewValueChanging.Text = e.NewValue.ToString();
            e.IsValid = (bool) this.emailMaskIsValidChanging.IsChecked;
        }
        private void numericMaskedEntry_ValueChanged(object sender, MaskedEntryValueChangedEventArgs e)
        {
            this.numericMaskNewValue.Text = e.Value.ToString();
            this.numericMaskNewText.Text = e.Text;
            this.numericMaskIsValid.Text = e.IsValid.ToString();
        }

        private void numericMaskedEntry_ValueChanging(object sender, MaskedEntryValueChangingEventArgs e)
        {
            e.Cancel = (bool)numericMaskCancelValueChanging.IsChecked;
            this.numericMaskNewValueChanging.Text = e.NewValue.ToString();
            e.IsValid = (bool)this.numericMaskIsValidChanging.IsChecked;
        }

        private void ipMaskedEntry_ValueChanged(object sender, MaskedEntryValueChangedEventArgs e)
        {
            this.ipMaskNewValue.Text = e.Value.ToString();
            this.ipMaskNewText.Text = e.Text;
            this.ipMaskIsValid.Text = e.IsValid.ToString();
        }

        private void ipMaskedEntry_ValueChanging(object sender, MaskedEntryValueChangingEventArgs e)
        {
            e.Cancel = (bool)ipMaskCancelValueChanging.IsChecked;
            this.ipMaskNewValueChanging.Text = e.NewValue.ToString();
            e.IsValid = (bool)this.ipMaskIsValidChanging.IsChecked;
        }
    }
}