using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Telerik.Maui.Controls.Compatibility;

namespace SDKBrowserMaui
{
    public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseTelerik()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("telerikfontexamples.ttf", "TelerikFontExamples");
				});

			return builder.Build();
		}
	}
}
