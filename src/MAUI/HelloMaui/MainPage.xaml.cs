using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace HelloMaui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage
    {
        public MainPage()
        {
            InitializeComponent();
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
    }
}
