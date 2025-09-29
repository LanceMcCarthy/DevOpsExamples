namespace MauiDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState) => new Window(activationState?.Context.Services.GetRequiredService<AppShell>() ?? new AppShell());
}
