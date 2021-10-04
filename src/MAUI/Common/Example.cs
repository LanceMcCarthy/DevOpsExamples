using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKBrowserMaui.Common
{
    public class Example
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Page { get; set; }
        public string Info { get; set; }
        public string ExcludeFrom { get; set; }

        [XmlIgnore]
        public Category Category { get; set; }
    }
}
