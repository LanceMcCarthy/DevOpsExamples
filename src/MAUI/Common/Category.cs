using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKBrowserMaui.Common
{
    public class Category
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ExcludeFrom { get; set; }

        [XmlIgnore]
        public Control Control { get; set; }
        public List<Example> Examples { get; set; }

        public Category()
        {
            this.Examples = new List<Example>();
        }
    }
}
