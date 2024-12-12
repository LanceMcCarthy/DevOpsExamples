using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TabView : ResourceDictionary
{
	public TabView()
	{
		InitializeComponent();
	}
}