using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using System;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Primitives;
using Telerik.XamarinForms.Input;

namespace HelloMaui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage
    {
        private RadPopup aboutPopup;

        public MainPage()
        {
            InitializeComponent();

            this.aboutPopup = new RadPopup();
            this.aboutPopup.Placement = PlacementMode.Center;
            this.aboutPopup.OutsideBackgroundColor = Color.FromArgb("#88000000");
            this.aboutPopup.IsModal = true;
            this.aboutPopup.Content = this.GenerateAboutContent();
        }

        private void ButtonAssignTask_Clicked(object sender, EventArgs args)
        {
            int count = int.Parse(this.LabelNotStartedTasks.Text);
            this.LabelNotStartedTasks.Text = (count + 1).ToString();
        }

        private void ButtonUnassignTask_Clicked(object sender, EventArgs args)
        {
            int count = int.Parse(this.LabelNotStartedTasks.Text);
            if (count > 0)
            {
                this.LabelNotStartedTasks.Text = (count - 1).ToString();
            }
        }

        private void ButtonAbout_Clicked(object sender, EventArgs args)
        {
            this.aboutPopup.IsOpen = true;
        }

        private View GenerateAboutContent()
        {
            var stack = new VerticalStackLayout();
            stack.WidthRequest = 300;
#if WINDOWS
            stack.HeightRequest = 400;
#else
            stack.HeightRequest = 428;
#endif
            stack.Margin = new Thickness(15, 0);

            Label label = new Label();
            label.Margin = new Thickness(0, 24, 0, 0);
            label.TextColor = Colors.Black;
            label.HorizontalOptions = LayoutOptions.Center;
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.Text = "Telerik UI for MAUI is an early experiment for the UI component suite.\n\nThe app purpose is to demonstrate the development of modern and feature-rich cross-platform components.";

            var image = new Image();
            image.Source = ImageSource.FromFile("about.png");
            image.Margin = new Thickness(0, 18, 0, 18);
#if WINDOWS
            image.WidthRequest = 156;
            image.HeightRequest = 156;
            image.HorizontalOptions = LayoutOptions.Center;
#endif

            var buttonBorder = new RadBorder();
            buttonBorder.WidthRequest = 74;
            buttonBorder.HeightRequest = 36;
            buttonBorder.HorizontalOptions = LayoutOptions.Center;
            buttonBorder.CornerRadius = new Thickness(25);
            
            var closeButton = new RadButton();
            closeButton.TextColor = Colors.White;
            closeButton.BackgroundColor = Color.FromArgb("#FF0E88F2");
            closeButton.Text = "GOT IT";
            closeButton.Clicked += this.ClosePopupBtnClicked;
            buttonBorder.Content = closeButton;

            stack.Add(label);
            stack.Add(image);
            stack.Add(buttonBorder);

            RadBorder border = new RadBorder();
            border.BackgroundColor = Colors.White;
            border.CornerRadius = 2;
            border.Content = stack;
            border.WidthRequest = stack.WidthRequest;
            border.HeightRequest = stack.HeightRequest;

            return border;
        }

         private void ClosePopupBtnClicked(object sender, EventArgs args)
         {
             this.aboutPopup.IsOpen = false;
         }
    }
}