using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;
using System;
using System.ComponentModel;
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

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
#if __ANDROID__
            //TODO: Remove this when NavigationPage starts using the Maui Handler instead of the old compat Renderer.
            if (e.PropertyName == nameof(this.Width) || e.PropertyName == nameof(this.Height))
            {
                this.Frame = this.Content.Frame;
            }
#endif
        }
    }
}
