using Microsoft.Maui.Controls.Xaml;
using Telerik.Maui.Controls;

namespace SDKBrowserMaui.Examples.ListViewControl.CommandsCategory.ListViewCommandExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InheritListViewCommand : RadContentView
    {
        public InheritListViewCommand()
        {
            InitializeComponent();

            // >> listview-features-commands-add
            listView.Commands.Add(new ItemTappedUserCommand());
            // << listview-features-commands-add
        }
    }
}