using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Chat : ResourceDictionary
{
	public Chat(ResourceDictionary core, ResourceDictionary entry)
	{
		this.MergedDictionaries.Add(core);
		this.MergedDictionaries.Add(entry);
		InitializeComponent();
	}
}