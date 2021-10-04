using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SDKBrowserMaui.Common;
using SDKBrowserMaui.Services;
using Microsoft.Maui.Controls;

namespace SDKBrowserMaui.ViewModels
{
    public class ControlViewModel : SearchViewModel
    {
        private Category selectedCategory;

        public ObservableCollection<Category> Categories { get; private set; }
        public ObservableCollection<Example> Examples { get; private set; }

        public Category SelectedCategory
        {
            get
            {
                return this.selectedCategory;
            }
            set
            {
                if (this.selectedCategory != value)
                {
                    this.selectedCategory = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ControlViewModel(Control control)
        {
            this.IsBackVisible = true;
            this.HeaderTitle = control.Title;
            this.Categories = new ObservableCollection<Category>();
            this.Examples = new ObservableCollection<Example>();

            foreach (var category in control.Categories)
            {
                this.Categories.Add(category);

                foreach (var example in category.Examples)
                {
                    this.Examples.Add(example);
                }
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(SelectedCategory))
            {
                this.Select(this.selectedCategory);
            }
        }

        private void Select(Category category)
        {
            var navigationService = DependencyService.Get<INavigationService>();

            if (category != null)
            {
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

        protected override bool PassesFilter(object item, params string[] tokens)
        {
            var example = (Example)item;
            var category = example.Category;
            var comparison = StringComparison.OrdinalIgnoreCase;

            return tokens.All(token =>
                example.Name.IndexOf(token, comparison) >= 0 ||
                example.Title.IndexOf(token, comparison) >= 0 ||
                category.Name.IndexOf(token, comparison) >= 0 ||
                category.Title.IndexOf(token, comparison) >= 0);
        }

        protected override object ExtractGroup(object item)
        {
            var example = (Example)item;
            var category = example.Category;

            return category.Title;
        }
    }
}
