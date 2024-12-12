using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TreeView : ResourceDictionary
{
	public TreeView(ResourceDictionary core)
	{
		this.MergedDictionaries.Add(core);
		InitializeComponent();
	}
}