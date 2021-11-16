using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.BusyIndicatorControl.IntegrationCategory.ListViewIntegrationExample
{
    // >> busyindicator-withlistview-csharp
    public class ViewModel : NotifyPropertyChangedBase
    {
        private bool _isLoading = false;
        private ObservableCollection<Book> _source;
        private bool hasStartedLoadingData;

        public ViewModel()
        {
            this.LoadDataCommand = new Command(this.LoadDataAsync, this.CanLoadData);
        }

        public bool IsLoading
        {
            get { return this._isLoading; }
            set { this.UpdateValue(ref this._isLoading, value); }
        }
        public ObservableCollection<Book> Source
        {
            get { return this._source; }
            set { this.UpdateValue(ref this._source, value); }
        }

        public Command LoadDataCommand { get; set; }

        private bool CanLoadData()
        {
            return !this.hasStartedLoadingData;
        }

        public async void LoadDataAsync()
        {
            this.hasStartedLoadingData = true;
            this.LoadDataCommand.ChangeCanExecute();
            this.IsLoading = true;
            this.Source = await GetItemsAsync();
            this.IsLoading = false;
        }

        private Task<ObservableCollection<Book>> GetItemsAsync()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                return new ObservableCollection<Book>
                {
                    new Book{ Title = "The Fault in Our Stars ",  Author = "John Green"},
                    new Book{ Title = "Divergent",  Author = "Veronica Roth"},
                    new Book{ Title = "Gone Girl",  Author = "Gillian Flynn" },
                    new Book{ Title = "Clockwork Angel",  Author = "Cassandra Clare"},
                    new Book{ Title = "The Martian",  Author = "Andy Weir"},
                    new Book{ Title = "Ready Player One",  Author = "Ernest Cline"},
                    new Book{ Title = "The Lost Hero",  Author = "Rick Riordan"},
                    new Book{ Title = "All the Light We Cannot See",  Author = "Anthony Doerr"},
                    new Book{ Title = "Cinder",  Author = "Marissa Meyer"},
                    new Book{ Title = "Me Before You",  Author = "Jojo Moyes"},
                    new Book{ Title = "The Night Circus",  Author = "Erin Morgenstern"},
                };
            });
        }
    }
    // << busyindicator-withlistview-csharp
}
