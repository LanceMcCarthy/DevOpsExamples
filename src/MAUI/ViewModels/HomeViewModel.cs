using Microsoft.Maui.Controls;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace SDKBrowserMaui.ViewModels
{
    public class HomeViewModel : PageViewModel
    {
        public Command NextCommand { get; private set; }

        public ObservableCollection<Control> Controls { get; private set; }
        public ObservableCollection<Example> Examples { get; private set; }

        private Control selectedControl;
        public Control SelectedControl
        {
            get
            {
                return this.selectedControl;
            }
            set
            {
                if (this.selectedControl != value)
                {
                    this.selectedControl = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public HomeViewModel()
        {
            var configurationService = DependencyService.Get<IConfigurationService>();
            var configuration = configurationService.Configuration;

            this.Controls = new ObservableCollection<Control>();
            this.Examples = new ObservableCollection<Example>();

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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(SelectedControl))
            {
                this.Select(this.selectedControl);
            }
        }

        private void Select(Control control)
        {
            var navigationService = DependencyService.Get<INavigationService>();

            if (control != null)
            {
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
}
