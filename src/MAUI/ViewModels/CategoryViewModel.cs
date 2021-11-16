using Microsoft.Maui.Controls;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SDKBrowserMaui.ViewModels
{
    public class CategoryViewModel : SearchViewModel
    {
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

        public ObservableCollection<Example> Examples { get; private set; }

        public void NavigateTo(Example example)
        {
            if (example == null)
            {
                return;
            }

            var navigationService = DependencyService.Get<INavigationService>();
            navigationService.NavigateToAsync<ExampleViewModel>(example);
        }

        protected override bool PassesFilter(object item, params string[] tokens)
        {
            var example = (Example)item;
            var comparison = StringComparison.OrdinalIgnoreCase;

            return tokens.All(token =>
                example.Name.IndexOf(token, comparison) >= 0 ||
                example.Title.IndexOf(token, comparison) >= 0);
        }
    }
}
