using MauiDemo.ViewModels;
using MauiDemo.Views;
using Telerik.Maui.Controls.Compatibility;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using WinUIEx;

#elif MACCATALYST
using CoreGraphics;
using UIKit;

#elif IOS
#elif ANDROID
#elif TIZEN

#endif

[assembly: XamlCompilation(XamlCompilationOptions.Compile)] // For XamlC
namespace MauiDemo;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("telerikfontexamples.ttf", "telerikfontexamples");
            });

        // Register views with DI
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<SchedulerPage>();

        // Register view models with DI
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SchedulerPageViewModel>();

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
            events.AddWindows(b => b.OnWindowCreated(window => window.CenterOnScreen(1024,768)));

#elif MACCATALYST

                events.AddiOS(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.SceneWillConnect((scene, session, options) =>
                    {
                        if (scene is UIWindowScene { SizeRestrictions: { } } windowScene)
                        {
                            windowScene.SizeRestrictions.MaximumSize = new CGSize(1200, 900);
                            windowScene.SizeRestrictions.MinimumSize = new CGSize(600, 400);
                        }
                    });

                });
#endif
        });

        return builder.Build();
    }
}