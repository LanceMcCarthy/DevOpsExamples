using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;
using Microsoft.Maui.Controls;

namespace SDKBrowserMaui.ViewModels
{
    public class ExampleViewModel : PageViewModel
    {
        private bool isInfoAvailable;
        private object content;

        public bool IsInfoAvailable
        {
            get
            {
                return this.isInfoAvailable;
            }
            private set
            {
                if (this.isInfoAvailable != value)
                {
                    this.isInfoAvailable = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public object Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                if (this.content != value)
                {
                    this.content = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Command OpenCommand { get; private set; }

        public ExampleViewModel(Example example)
        {
            this.IsBackVisible = true;
            this.HeaderTitle = example.Title;
            this.IsInfoAvailable = !string.IsNullOrEmpty(example.Info);
            this.OpenCommand = new Command(() => this.OnOpenCommand(example));

            var exampleServide = DependencyService.Get<IExampleService>();

            this.Content = exampleServide.CreateExample(example);
        }

        private void OnOpenCommand(Example example)
        {
            var exampleServide = DependencyService.Get<IExampleService>();

            exampleServide.OpenExample(example);
        }
    }
}
