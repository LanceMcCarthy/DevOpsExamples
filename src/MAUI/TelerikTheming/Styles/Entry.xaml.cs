using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Entry : ResourceDictionary
{
	public Entry(ResourceDictionary core)
	{
		this.MergedDictionaries.Add(core);
		InitializeComponent();
	}
}