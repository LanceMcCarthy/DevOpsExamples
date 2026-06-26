using MauiDemo.ViewModels;

namespace MauiDemo.Views;

public partial class MarkdownPage : ContentPage
{
    public MarkdownPage(MarkdownPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
