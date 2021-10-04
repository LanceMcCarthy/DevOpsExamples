using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKBrowserMaui.Common;

namespace SDKBrowserMaui.Services
{
    public interface IConfigurationService
    {
        Configuration Configuration { get; }
    }
}
