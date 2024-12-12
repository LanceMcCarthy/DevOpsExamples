using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AIPrompt : ResourceDictionary
{
	public AIPrompt(ResourceDictionary core)
	{
		this.MergedDictionaries.Add(core);
		InitializeComponent();
	}
}