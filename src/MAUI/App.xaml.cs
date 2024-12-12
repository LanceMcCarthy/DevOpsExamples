namespace MauiDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        Application.Current.UserAppTheme = AppTheme.Unspecified;
        Application.Current.RequestedThemeChanged += (s, e) => ApplyTelerikTheme();
        this.ApplyTelerikTheme();

		MainPage = new AppShell();
	}

    private void ApplyTelerikTheme()
    {
        var telerikTheming = Application.Current
            .Resources
            .MergedDictionaries
            .OfType<TelerikTheming>()
            .Single();

        var swatchName = Application.Current.RequestedTheme == AppTheme.Dark ? "Purple Dark" : "Purple";
        telerikTheming.Theme = TelerikTheming.Themes
            .Single(t => t.Theme == "Telerik" && t.Swatch == swatchName);
    }
}
