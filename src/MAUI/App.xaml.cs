namespace MauiDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        this.MainPage ??= activationState?.Context.Services.GetRequiredService<AppShell>();

        return base.CreateWindow(activationState);
    }
}
