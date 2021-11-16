using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.BusyIndicatorControl.AnimationsCategory.CustomAnimationExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomAnimationXaml : RadContentView
    {
        public CustomAnimationXaml()
        {
            InitializeComponent();

            // >> busyindicator-animations-code
            RadDoubleAnimation annimation = new RadDoubleAnimation() { Duration = 800, From = 0.1, To = 1, PropertyPath = "Opacity", Target = radBusyIndicator.BusyContent, RepeatForever = true, AutoReverse = true };
            this.radBusyIndicator.Animations.Add(annimation);

            Device.StartTimer(TimeSpan.FromMilliseconds(5000),
                () =>
                {
                    this.radBusyIndicator.IsBusy = false;
                    return false;
                });
            // << busyindicator-animations-code
        }
    }
}