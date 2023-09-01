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
        m_window = new MainWindow();
        m_window.Activate();

        m_window.CenterOnScreen(1024,768);
    }

    private Microsoft.UI.Xaml.Window m_window;
}
