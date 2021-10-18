using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView.Commands;

namespace SDKBrowserMaui.Examples.ListViewControl.GroupingCategory.ReorderInGroupedListViewExample
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Events = new ObservableCollection<Event>()
            {
                new Event() { Content = "Meeting with John", Day = "Tommorow" },
                new Event() { Content = "This also happens today", Day = "Yesterday" },
                new Event() { Content = "More events today", Day = "Today" },
                new Event() { Content = "Go shopping after 19:00", Day = "Yesterday" },
                new Event() { Content = "Lunch with Sara", Day = "Today" },
                new Event() { Content = "Planning for tommorow", Day = "Today"},
                new Event() { Content = "Free lunch time", Day = "Yesterday" },
                new Event() { Content = "Kids Party", Day = "Tommorow" },
                new Event() { Content = "Party", Day = "Tommorow" }
            };
            this.ReorderCommand = new Command<ReorderEndedCommandContext>(this.Reorder);
        }
        public ObservableCollection<Event> Events { get; set; }
        public Command<ReorderEndedCommandContext> ReorderCommand { get; }
        private void Reorder(ReorderEndedCommandContext context)
        {
            var sourceItem = (Event)context.Item;

            this.Events.Remove(sourceItem);

            var destinationItem = (Event)context.DestinationItem;
            var destinationGroup = context.DestinationGroup;
            var destinationIndex = this.Events.IndexOf(destinationItem);

            if (context.Placement == ItemReorderPlacement.After)
            {
                destinationIndex++;
            }

            sourceItem.Day = (string)destinationGroup.Key;
            this.Events.Insert(destinationIndex, sourceItem);
        }
    }
}
