using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKBrowserMaui.Services;
using Microsoft.Maui.Controls;

namespace SDKBrowserMaui.ViewModels
{
    public abstract class SearchViewModel : PageViewModel
    {
        private bool isSearchVisible;
        private string searchText;
        private Func<object, bool> searchFilter;
        private Func<object, object> searchGrouping;

        public bool IsSearchVisible
        {
            get
            {
                return this.isSearchVisible;
            }
            private set
            {
                if (this.isSearchVisible != value)
                {
                    this.isSearchVisible = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                if (this.searchText != value)
                {
                    this.searchText = value;
                    this.OnPropertyChanged();
                    this.OnSearchChanged();
                }
            }
        }

        public Func<object, bool> SearchFilter
        {
            get
            {
                return this.searchFilter;
            }
            private set
            {
                if (this.searchFilter != value)
                {
                    this.searchFilter = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Func<object, object> SearchGrouping
        {
            get
            {
                return this.searchGrouping;
            }
            private set
            {
                if (this.searchGrouping != value)
                {
                    this.searchGrouping = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Command SearchCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public SearchViewModel()
        {
            this.searchText = string.Empty;
            this.SearchFilter = item => this.PassesFilter(item);
            this.SearchGrouping = item => this.ExtractGroup(item);
            this.SearchCommand = new Command(this.OnSearchCommand);
            this.CancelCommand = new Command(this.OnCancelCommand);
        }

        protected virtual bool PassesFilter(object item, params string[] tokens)
        {
            return true;
        }

        protected virtual object ExtractGroup(object item)
        {
            return null;
        }

        private void OnSearchCommand()
        {
            this.IsSearchVisible = true;
        }

        private void OnCancelCommand()
        {
            this.IsSearchVisible = false;
        }

        private void OnSearchChanged()
        {
            var tokens = this.SearchText.Split(default(char[]),
                StringSplitOptions.RemoveEmptyEntries);

            this.SearchFilter = item => this.PassesFilter(item, tokens);

            this.NavigateToExampleOnSearch();
        }

        private void NavigateToExampleOnSearch()
        {
            var strings = this.SearchText.Split(';');
            if (strings.Length > 1)
            {
                var controlName = strings[0].Trim();
                var exampleName = strings[1].Trim();
                if (exampleName.EndsWith("#"))
                {
                    exampleName = exampleName.Substring(0, exampleName.Length - 1);
                    var backdoorService = DependencyService.Get<IBackdoorService>();
                    if (backdoorService != null)
                    {
                        backdoorService.TryNavigateToExample(controlName, exampleName);
                    }
                }
            }
        }
    }
}
