using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ImageEditor : ResourceDictionary
{
	public ImageEditor(ResourceDictionary core, ResourceDictionary toolbar)
	{
		this.MergedDictionaries.Add(core);
		this.MergedDictionaries.Add(toolbar);
		InitializeComponent();
	}
}