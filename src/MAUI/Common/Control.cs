using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKBrowserMaui.Common
{
    public class Control
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string ExcludeFrom { get; set; }

        [XmlIgnore]
        public Configuration Configuration { get; set; }
        public List<Category> Categories { get; set; }

        public Control()
        {
            this.Categories = new List<Category>();
        }
    }
}
