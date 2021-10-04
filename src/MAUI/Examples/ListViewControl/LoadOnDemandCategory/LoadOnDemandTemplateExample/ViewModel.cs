using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowserMaui.Examples.ListViewControl.LoadOnDemandCategory.LoadOnDemandTemplateExample
{
    public class ViewModel
    {
        public ListViewLoadOnDemandCollection Source { get; set; }
        private int lodTriggerCount;
        public ViewModel()
        {
            this.Source = new ListViewLoadOnDemandCollection((cancelationToken) =>
            {
                List<string> result = new List<string>();

                try
                {
                    //simulates connection latency
                    Task.Delay(4000, cancelationToken).Wait();

                    this.lodTriggerCount++;
                    foreach (string item in Enum.GetNames(typeof(DayOfWeek)))
                    {
                        result.Add(string.Format("LOD: {0} - {1}", lodTriggerCount, item));
                    }
                    return result;
                }
                catch
                {
                    //exception is thrown when the task is canceled. Returning null does not affect the ItemsSource.
                    return null;
                }
            });

            for (int i = 0; i < 14; i++)
            {
                Source.Add(string.Format("Item {0}", i));
            }
        }
    }
}
