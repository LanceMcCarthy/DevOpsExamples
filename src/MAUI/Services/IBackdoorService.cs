using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKBrowserMaui.Services
{
    public interface IBackdoorService
    {
        string NavigateToExample(string controlName, string exampleName);

        bool TryNavigateToExample(string controlName, string exampleName);
    }
}
