using System.Collections.ObjectModel;
using System;
using System.Linq;
using SDKBrowserMaui.Common;
using System.Runtime.CompilerServices;
using SDKBrowserMaui.Services;
using Microsoft.Maui.Controls;

namespace SDKBrowserMaui.ViewModels
{
    public class CategoryViewModel : SearchViewModel
    {
        private Example selectedExample;

        public ObservableCollection<Example> Examples { get; private set; }
        
        public Example SelectedExample
        {
            get
            {
                return this.selectedExample;
            }
            set
            {
                if (this.selectedExample != value)
                {
                    this.selectedExample = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public CategoryViewModel(Category category)
        {
            this.IsBackVisible = true;
            this.HeaderTitle = category.Title;
            this.Examples = new ObservableCollection<Example>();

            foreach (var example in category.Examples)
            {
                this.Examples.Add(example);
            }
        }

        protected override bool PassesFilter(object item, params string[] tokens)
        {
            var example = (Example)item;
            var comparison = StringComparison.OrdinalIgnoreCase;

            return tokens.All(token =>
                example.Name.IndexOf(token, comparison) >= 0 ||
                example.Title.IndexOf(token, comparison) >= 0);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(SelectedExample))
            {
                this.Select(this.selectedExample);
            }
        }

        private void Select(Example example)
        {
            var navigationService = DependencyService.Get<INavigationService>();

            if (example is Example)
            {
                navigationService.NavigateToAsync<ExampleViewModel>(example);
            }
        }
    }
}
