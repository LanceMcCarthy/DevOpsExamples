using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui;
using Telerik.Maui.Handlers;

#if __ANDROID__
using InputRenderer = Telerik.XamarinForms.InputRenderer.Android;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.Android;
#elif __IOS__
using InputRenderer = Telerik.XamarinForms.InputRenderer.iOS;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.iOS;
#endif

namespace HelloMaui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseFormsCompatibility()
				.ConfigureFonts(fonts => {
					fonts.AddFont("ionicons.ttf", "IonIcons");
				})
				.ConfigureMauiHandlers(handlers => {
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Input.RadButton), typeof(InputRenderer.ButtonRenderer));
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(ChartRenderer.CartesianChartRenderer));
					handlers.AddHandler<IRadItemsControl, RadItemsControlHandler>();
					handlers.AddHandler<IRadBorder, RadBorderHandler>();
				})
				.UseMauiApp<App>()
				.ConfigureLifecycleEvents(lifecycle => {
#if ANDROID
					lifecycle.AddAndroid(d => {
						d.OnBackPressed(activity => {
							System.Diagnostics.Debug.WriteLine("Back button pressed!");
						});
					});
#endif
				});
		}
	}
}