using Telerik.Maui.Controls.Compatibility;

// This is needed for the builder.ConfigureLifecycleEvents extensions method
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
// This is needed for the window.CenterOnScreen extensions method
using WinUIEx;
#endif

namespace MauiDemo
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
                    fonts.AddFont("telerikfontexamples.ttf", "telerikfontexamples");
				});

#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        //Set size and center on screen using WinUIEx extension method
                        window.CenterOnScreen(1024,768); 
                    });
                });
            });
#endif

            return builder.Build();
		}
	}
}