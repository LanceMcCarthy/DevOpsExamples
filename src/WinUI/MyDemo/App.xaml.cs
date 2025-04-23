using WinUIEx;

namespace MyDemo;

public partial class App : Microsoft.UI.Xaml.Application
{
    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        mWindow = new MainWindow();
        mWindow.Activate();

        mWindow.CenterOnScreen(1024,768);
    }

    private Microsoft.UI.Xaml.Window mWindow = null!;
}
