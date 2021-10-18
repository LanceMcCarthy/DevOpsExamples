using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKBrowserMaui.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>(params object[] arguments);
        Task NavigateToRootAsync();
        Task NavigateBackAsync();
    }
}
