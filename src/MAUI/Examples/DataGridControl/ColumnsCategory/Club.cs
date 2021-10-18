using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.DataGridControl.ColumnsCategory
{
    public class Club : NotifyPropertyChangedBase
    {
        private string name;
        private DateTime established;
        private DateTime time;
        private int stadiumCapacity;
        private bool isChampion;
        private string country;

        public Club(string name, DateTime established, DateTime time, int stadiumCapacity, string country)
        {
            Name = name;
            Established = established;
            Time = time;
            StadiumCapacity = stadiumCapacity;
            Country = country;
        }

        public string Name
        {
            get { return this.name; }
            set { this.UpdateValue(ref this.name, value); }
        }
        public DateTime Established
        {
            get { return this.established; }
            set { this.UpdateValue(ref this.established, value); }
        }

        public DateTime Time
        {
            get { return this.time; }
            set { this.UpdateValue(ref this.time, value); }
        }

        public int StadiumCapacity
        {
            get { return this.stadiumCapacity; }
            set { this.UpdateValue(ref this.stadiumCapacity, value); }
        }

        public string Country
        {
            get { return this.country; }
            set { this.UpdateValue(ref this.country, value); }
        }

        public bool IsChampion
        {
            get { return this.isChampion; }
            set { this.UpdateValue(ref this.isChampion, value); }
        }

        public List<string> Countries => new List<string> { "England", "Spain", "France", "Bulgaria" };
    }
}
