using Microsoft.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace HelloMaui
{
	public partial class App : Microsoft.Maui.Controls.Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	}
}
