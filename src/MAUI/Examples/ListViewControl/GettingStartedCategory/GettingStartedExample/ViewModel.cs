using System.Collections.Generic;

namespace SDKBrowserMaui.Examples.ListViewControl.GettingStartedCategory.GettingStartedExample
{
    // >> listview-gettingstarted-source
    public class SourceItem
    {
        public SourceItem(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new List<SourceItem> 
            {
                new SourceItem("Tom"),
                new SourceItem("Anna"), 
                new SourceItem("Peter"), 
                new SourceItem("Teodor"), 
                new SourceItem("Lorenzo"), 
                new SourceItem("Andrea"), 
                new SourceItem("Jeremy"), 
                new SourceItem("Linda"), 
                new SourceItem("Mario"), 
                new SourceItem("Alex"), 
                new SourceItem("Barbara"), 
                new SourceItem("Nicole"), 
                new SourceItem("Paul"), 
                new SourceItem("Raul"), 
                new SourceItem("Lenny"), 
                new SourceItem("Laura"), 
                new SourceItem("Mike"), 
                new SourceItem("Taylor"), 
                new SourceItem("Martin") 
            };
        }

        public List<SourceItem> Source { get; set; }
    }
    // << listview-gettingstarted-source
}
