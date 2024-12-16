namespace MauiDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //this.UserAppTheme = AppTheme.Unspecified;
        //this.RequestedThemeChanged += (s, e) => ApplyTelerikTheme();
        //this.ApplyTelerikTheme();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        this.MainPage ??= activationState?.Context.Services.GetRequiredService<AppShell>();

        return base.CreateWindow(activationState);
    }

    //private void ApplyTelerikTheme()
    //{
    //    var swatchName = this.RequestedTheme == AppTheme.Dark ? "Purple Dark" : "Purple";

    //    this.Resources.MergedDictionaries.OfType<TelerikTheming>()
    //        .Single().Theme = TelerikTheming.Themes.Single(t => t.Theme == "Telerik" && t.Swatch == swatchName);
    //}
}
