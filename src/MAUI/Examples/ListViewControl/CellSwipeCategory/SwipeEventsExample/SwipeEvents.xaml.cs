using Microsoft.Maui.Controls.Xaml;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.CellSwipeCategory.SwipeEventsExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeEvents : RadContentView
    {
        public SwipeEvents()
        {
            InitializeComponent();
        }

        // >> listview-gestures-cellswipe-swipeevents-swipecompleted
        void OnItemSwipeCompleted(object sender, ItemSwipeCompletedEventArgs e)
        {
            var listView = sender as RadListView;
            var item = e.Item as Mail;

            listView.EndItemSwipe();

            if (e.Offset >= 70)
            {
                item.IsUnread = false;
            }
            else if (e.Offset <= -70)
            {
                (listView.ItemsSource as ObservableCollection<Mail>).Remove(item);
            }
        }
        // << listview-gestures-cellswipe-swipeevents-swipecompleted
    }
}