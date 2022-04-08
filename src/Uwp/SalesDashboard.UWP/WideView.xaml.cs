using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SalesDashboard.UWP
{
    public sealed partial class WideView : UserControl
    {
        public WideView()
        {
            this.InitializeComponent();
        }

        private void OnCheckCloseDatePickerButton(object sender, RoutedEventArgs e)
        {
            CustomDatePickerPopUp.IsOpen = false;
        }

        private void CustomDatePicker_Click(object sender, RoutedEventArgs e)
        {
            CustomDatePickerPopUp.IsOpen = true;
        }
    }
}
