using Microsoft.Maui.Controls;
using Telerik.XamarinForms.DataControls.ListView.Commands;

namespace SDKBrowserMaui.Examples.ListViewControl.CommandsCategory.ListViewCommandExample
{
    // >> listview-features-commands-listviewcommand
    public class ItemTappedUserCommand : ListViewCommand
    {
        public ItemTappedUserCommand()
        {
            Id = CommandId.ItemTap;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            var tappedItem = (parameter as ItemTapCommandContext).Item;
            //add your logic here
            App.DisplayAlert("You've selected " + tappedItem);
        }
    }
    // << listview-features-commands-listviewcommand
}
