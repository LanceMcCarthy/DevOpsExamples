using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SalesDashboard.UWP
{
    public sealed partial class SmallView : UserControl
    {
        public SmallView()
        {
            this.InitializeComponent();

            Window.Current.SizeChanged += WindowSizeChanged;
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
        }


        private void MessageBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageBox.Visibility = Visibility.Collapsed;
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            ApplicationViewOrientation winOrientation = ApplicationView.GetForCurrentView().Orientation;

            if (winOrientation == ApplicationViewOrientation.Landscape)
            {
                TotalSalesTrendChart.Visibility = Visibility.Visible;
            }
            else if (winOrientation == ApplicationViewOrientation.Portrait)
            {
                TotalSalesTrendChart.Visibility = Visibility.Collapsed;
            }
        }
    }
}
