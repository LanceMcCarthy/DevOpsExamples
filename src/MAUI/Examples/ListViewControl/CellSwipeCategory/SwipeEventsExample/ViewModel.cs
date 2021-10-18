using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.ListViewControl.CellSwipeCategory.SwipeEventsExample
{
    // >> listview-gestures-cellswipe-swipeevents-viewmodel
    public class Mail : NotifyPropertyChangedBase
    {
        bool isUnread;

        public string Sender { get; set; }

        public string Subject { get; set; }

        public bool IsUnread
        {
            get { return isUnread; }
            set { this.UpdateValue(ref this.isUnread, value); }
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new ObservableCollection<Mail> {
                new Mail{ Sender = "Terry Tye",  Subject = "Re: Summer Vacation" , IsUnread = true},
                new Mail{ Sender = "Felicia Keegan",  Subject = "Seminar Invitation", IsUnread = true},
                new Mail{ Sender = "Jared Linton",  Subject = "Discount code"},
                new Mail{ Sender = "Mark Therese",  Subject = "Quick feedback", IsUnread = true},
                new Mail{ Sender = "Elvina Randall",  Subject = "Happy Birthday!"},
                new Mail{ Sender = "Emilia Porter",  Subject = "Check the attachment", IsUnread = true},
                new Mail{ Sender = "Jared Linton",  Subject = "Gillian Flynn"},
                new Mail{ Sender = "Felicia Keegan",  Subject = "Re: Summer Vacation"},
                new Mail{ Sender = "Felicia Keegan",  Subject = "Pictures"},
            };
        }

        public ObservableCollection<Mail> Source { get; set; }
    }
    // << listview-gestures-cellswipe-swipeevents-viewmodel
}
