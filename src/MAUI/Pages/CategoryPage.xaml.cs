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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            var navigationService = DependencyService.Get<INavigationService>();
            await navigationService.NavigateBackAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as CategoryViewModel).SelectedExample = null;
        }

    }
}
