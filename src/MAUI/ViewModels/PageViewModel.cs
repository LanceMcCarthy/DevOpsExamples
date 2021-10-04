using Microsoft.Maui.Controls;
using SDKBrowserMaui.Services;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.ViewModels
{
    public abstract class PageViewModel : NotifyPropertyChangedBase
    {
        private string appTitle;
        private string headerTitle;
        private string headerIcon;
        private bool isBackVisible;

        public string AppTitle
        {
            get
            {
                return this.appTitle;
            }
            protected set
            {
                this.UpdateValue(ref this.appTitle, value);
            }
        }

        public string HeaderTitle
        {
            get
            {
                return this.headerTitle;
            }
            protected set
            {
                this.UpdateValue(ref this.headerTitle, value);
            }
        }

        public string HeaderIcon
        {
            get
            {
                return this.headerIcon;
            }
            protected set
            {
                this.UpdateValue(ref this.headerIcon, value);
            }
        }

        public bool IsBackVisible
        {
            get
            {
                return this.isBackVisible;
            }
            protected set
            {
                this.UpdateValue(ref this.isBackVisible, value);
            }
        }

        public Command BackCommand { get; private set; }

        public PageViewModel()
        {
            var configurationService = DependencyService.Get<IConfigurationService>();

            this.AppTitle = configurationService.Configuration.HeaderTitle;
            this.BackCommand = new Command(this.OnBackCommand);
        }

        private void OnBackCommand()
        {
            var navigationService = DependencyService.Get<INavigationService>();

            navigationService.NavigateBackAsync();
        }
    }
}
