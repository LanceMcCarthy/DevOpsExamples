using Sales_Dashboard.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SalesDashboard.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Lance - Legacy code, used for Windows 10 Mobile to hide the status bar at the top of the screen
            //if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            //{
            //    var i = Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            //}

            this.DataContext = new MainViewModel();

            this.SizeChanged += Page_SizeChanged;
        }

        private void Page_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 650)
            {
                WideView.Visibility = Visibility.Visible;
                SmallView.Visibility = Visibility.Collapsed;
            }
            else
            {
                SmallView.Visibility = Visibility.Visible;
                WideView.Visibility = Visibility.Collapsed;
            }
        }
    }
}
