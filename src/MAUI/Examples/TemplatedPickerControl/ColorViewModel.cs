using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.TemplatedPickerControl
{
    public class ColorViewModel : NotifyPropertyChangedBase
    {
        public ColorViewModel()
        {
            this.Colors = new ObservableCollection<string>
            {
                "#FFFFFF",
                "#EE534F",
                "#AB47BC",
                "#7E57C2",
                "#5D6BC0",
                "#42A5F5",
                "#26C5DA",
                "#24A79A",
                "#66BB6A",
                "#9CCC65",
                "#D4E157",
                "#FFEE58",
                "#FFCA29",
                "#FFA726",
                "#FF7043",
                "#8D6E63",
                "#BDBDBD",
                "#78909C",
                "#3C3C3C",
                "#000000"
            };
        }

        public ObservableCollection<string> Colors { get; }
    }
}
