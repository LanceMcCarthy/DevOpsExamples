using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.CellTypesCategory.TemplateCellSelectorExample
{
    public class DataItem : NotifyPropertyChangedBase
    {
        private string name;
        private bool isSpecial;

        public string Name
        {
            get { return this.name; }
            set { this.UpdateValue(ref this.name, value); }
        }

        public bool IsSpecial
        {
            get { return this.isSpecial; }
            set { this.UpdateValue(ref this.isSpecial, value); }
        }    
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new ObservableCollection<DataItem>{
                new DataItem{ Name = "Item1"},
                new DataItem{ Name = "Item2"},
                new DataItem{ Name = "Item3", IsSpecial = true },
                new DataItem{ Name = "Item4"},
                new DataItem{ Name = "Item5"},
                new DataItem{ Name = "Item6"},
                new DataItem{ Name = "Item7"},
                new DataItem{ Name = "Item8"},
                new DataItem{ Name = "Item9"},
                new DataItem{ Name = "Item10", IsSpecial = true },
                new DataItem{ Name = "Item11"},
                new DataItem{ Name = "Item12"},
                new DataItem{ Name = "Item13"},
                new DataItem{ Name = "Item14", IsSpecial = true },
                new DataItem{ Name = "Item15"},
                new DataItem{ Name = "Item16"}
            };
        }

        public ObservableCollection<DataItem> Source { get; private set; }
    }
}
