using System.Windows;
using Telerik.Licensing;

namespace MyWpfApp
{
    public partial class App : Application
    {
        public App()
        {
            TelerikLicensing.EnableDiagnostics();
           this.InitializeComponent();
        }
    }
}
