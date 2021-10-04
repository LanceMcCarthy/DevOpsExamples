using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;
using System;
using System.Diagnostics;
using SDKBrowserMaui.Services;
using SDKBrowserMaui.ViewModels;
using Telerik.Maui.Controls;
using SDKBrowserMaui.Common;
using Telerik.XamarinForms.DataControls;

namespace SDKBrowserMaui.Pages
{
    public partial class ControlPage : ContentPage
    {
        public ControlPage()
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
            (this.BindingContext as ControlViewModel).SelectedCategory = null;
        }
    }
}
