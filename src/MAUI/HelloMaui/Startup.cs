using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Telerik.Maui;
using Telerik.Maui.Handlers;
using Microsoft.Maui.Controls.Hosting;
using SkiaSharp.Views.Maui.Controls.Compatibility;
using SkiaSharp.Views.Maui.Controls;

#if __ANDROID__
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.Android;
using InputRenderer = Telerik.XamarinForms.InputRenderer.Android;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.Android;
#elif __IOS__
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.iOS;
using InputRenderer = Telerik.XamarinForms.InputRenderer.iOS;
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
				.UseSkiaSharpCompatibilityRenderers()
				.UseSkiaSharpHandlers()
				.UseMauiApp<App>();
		}
	}
}