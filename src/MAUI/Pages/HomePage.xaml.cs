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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //this.controls.SelectedItem = null;
            (this.BindingContext as HomeViewModel).SelectedControl= null;
        }
    }
}
