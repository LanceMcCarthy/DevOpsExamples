using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;
using System;
using System.Diagnostics;
using SDKBrowserMaui.Services;
using SDKBrowserMaui.ViewModels;

namespace SDKBrowserMaui.Pages
{
    public partial class ExamplePage : ContentPage
    {
        public ExamplePage()
        {
            InitializeComponent();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            var navigationService = DependencyService.Get<INavigationService>();
            await navigationService.NavigateBackAsync();
        }
    }
}
