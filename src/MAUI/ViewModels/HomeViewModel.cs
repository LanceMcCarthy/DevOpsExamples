using Microsoft.Maui.Controls;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;
using System.Collections.ObjectModel;

namespace SDKBrowserMaui.ViewModels
{
    public class HomeViewModel : PageViewModel
    {
        public HomeViewModel()
        {
            this.Controls = new ObservableCollection<Control>();
            this.Examples = new ObservableCollection<Example>();

            var configurationService = DependencyService.Get<IConfigurationService>();
            var configuration = configurationService.Configuration;

            foreach (var control in configuration.Controls)
            {
                this.Controls.Add(control);

                foreach (var category in control.Categories)
                {
                    foreach (var example in category.Examples)
                    {
                        this.Examples.Add(example);
                    }
                }
            }
        }

        public ObservableCollection<Control> Controls { get; private set; }
        public ObservableCollection<Example> Examples { get; private set; }

        public void NavigateTo(Control control)
        {
            if (control == null)
            {
                return;
            }

            var navigationService = DependencyService.Get<INavigationService>();

            if (control.Categories.Count > 1)
            {
                navigationService.NavigateToAsync<ControlViewModel>(control);
            }
            else if (control.Categories.Count > 0)
            {
                var category = control.Categories[0];

                if (category.Examples.Count > 1)
                {
                    navigationService.NavigateToAsync<CategoryViewModel>(category);
                }
                else if (category.Examples.Count > 0)
                {
                    var example = category.Examples[0];

                    navigationService.NavigateToAsync<ExampleViewModel>(example);
                }
            }
        }
    }
}
