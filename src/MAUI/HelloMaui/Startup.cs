using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui;
using Telerik.Maui.Handlers;
using Microsoft.Maui.Controls.Hosting;

#if __ANDROID__
using InputRenderer = Telerik.XamarinForms.InputRenderer.Android;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.Android;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.Android;
#elif __IOS__
using InputRenderer = Telerik.XamarinForms.InputRenderer.iOS;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.iOS;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.iOS;
#else
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.UWP;
using InputRenderer = Telerik.XamarinForms.InputRenderer.UWP;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.UWP;
#endif

namespace HelloMaui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.ConfigureFonts(fonts => {
					fonts.AddFont("ionicons.ttf", "IonIcons");
				})
				.ConfigureMauiHandlers(handlers => {
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Input.RadButton), typeof(InputRenderer.ButtonRenderer));
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(ChartRenderer.CartesianChartRenderer));
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Input.RadSegmentedControl), typeof(InputRenderer.SegmentedControlRenderer));
					handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Primitives.RadCheckBox), typeof(PrimitivesRenderer.CheckBoxRenderer));
					handlers.AddHandler(typeof(IRadItemsControl), typeof(RadItemsControlHandler));
					handlers.AddHandler(typeof(Telerik.Maui.Controls.RadBorder), typeof(RadBorderHandler));
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