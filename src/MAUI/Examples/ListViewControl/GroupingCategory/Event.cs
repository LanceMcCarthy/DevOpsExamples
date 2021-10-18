using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.GroupingCategory
{
    public class Event : NotifyPropertyChangedBase
    {
        public string content;
        public string day;
        public string category;

        public string Content
        {
            get { return this.content; }
            set { this.UpdateValue(ref this.content, value); }

        }
        public string Day
        {
            get { return this.day; }
            set { this.UpdateValue(ref this.day, value); }

        }
        public string Category
        {
            get { return this.category; }
            set { this.UpdateValue(ref this.category, value); }

        }
    }
}
