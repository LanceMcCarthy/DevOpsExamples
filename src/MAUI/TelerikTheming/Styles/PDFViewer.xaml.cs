using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Telerik.Theming.Styles;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PDFViewer : ResourceDictionary
{
	public PDFViewer(ResourceDictionary core, ResourceDictionary entry, ResourceDictionary toolbar)
	{
		this.MergedDictionaries.Add(core);
		this.MergedDictionaries.Add(entry);
		this.MergedDictionaries.Add(toolbar);
		InitializeComponent();
	}
}