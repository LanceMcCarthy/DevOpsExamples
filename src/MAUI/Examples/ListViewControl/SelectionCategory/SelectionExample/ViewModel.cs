using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.SelectionCategory.SelectionExample
{
    // >> listview-features-selection-viewmodel
    public class ViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<object> _selectedNames;

        public ViewModel()
        {
            this.Names = new ObservableCollection<string>() { "Tom", "Anna", "Peter", "Teodor", "Lorenzo", "Andrea", "Martin" };
        }

        public ObservableCollection<string> Names { get; set; }
        public ObservableCollection<object> SelectedNames
        {
            get { return this._selectedNames; }
            set
            {
                if (this._selectedNames != value)
                {
                    if (this._selectedNames != null)
                    {
                        this._selectedNames.CollectionChanged -= this.SelectedNamesCollectionChanged;
                    }

                    this._selectedNames = value;

                    if (this._selectedNames != null)
                    {
                        this._selectedNames.CollectionChanged += this.SelectedNamesCollectionChanged;
                    }

                    OnPropertyChanged("SelectedNames");

                }
            }
        }

        private void SelectedNamesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.SelectedNames.Count > 0)
            {
                Application.Current.MainPage.DisplayAlert("Selected items:", string.Join(",", this.SelectedNames.ToArray()), "OK");
            }
        }
    }
    // << listview-features-selection-viewmodel
}
