using Microsoft.Maui.Controls;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;

namespace SDKBrowserMaui.ViewModels
{
    public class InfoViewModel : PageViewModel
    {
        private string exampleTitle;
        private string exampleInfo;

        public string ExampleTitle
        {
            get
            {
                return this.exampleTitle;
            }
            private set
            {
                if (this.exampleTitle != value)
                {
                    this.exampleTitle = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string ExampleInfo
        {
            get
            {
                return this.exampleInfo;
            }
            private set
            {
                if (this.exampleInfo != value)
                {
                    this.exampleInfo = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Command OpenCommand { get; private set; }

        public InfoViewModel(Example example)
        {
            this.IsBackVisible = true;
            this.HeaderTitle = "Information";
            this.ExampleTitle = example.Title;
            this.ExampleInfo = example.Info;
            this.OpenCommand = new Command(() => this.OnOpenCommand(example));
        }

        private void OnOpenCommand(Example example)
        {
            var exampleServide = DependencyService.Get<IExampleService>();

            exampleServide.OpenExample(example);
        }
    }
}
