using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using SDKBrowserMaui.Pages;
using SDKBrowserMaui.Services;
using System.Threading;
using Application = Microsoft.Maui.Controls.Application;

namespace SDKBrowserMaui
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			this.InitializeDependencies();
			MainPage = new NavigationPage(new HomePage());
		}

		private void InitializeDependencies()
		{
			DependencyService.Register<IConfigurationService, ConfigurationService>();
			DependencyService.Register<INavigationService, NavigationService>();
			DependencyService.Register<IExampleService, ExampleService>();
		}
	}
}
