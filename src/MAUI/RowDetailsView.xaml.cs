namespace MauiDemo;

public partial class RowDetailsView : ContentView
{
	public RowDetailsView()
	{
		InitializeComponent();

        Loaded += RowDetailsView_Loaded;
	}

    private async void RowDetailsView_Loaded(object sender, EventArgs e)
    {
        // artificial delay because the inner data is small
        await Task.Delay(2000);

        OverlayIndicator.IsBusy = OverlayIndicator.IsVisible = false;
    }
}