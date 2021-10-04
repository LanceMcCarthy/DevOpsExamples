using System.Collections.ObjectModel;
namespace SDKBrowserMaui.Examples.ItemsControlControl.GettingStartedCategory.GettingStartedExample
{
    public class Experience
    {
        public string Title { get; set; }
        public string Company { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Experiences = new ObservableCollection<Experience>()
        {
            new Experience() { Title = "JS Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Technical Support Engineer", Company = "@ Progress Software" },
            new Experience() { Title = "Junior Technical Support Engineer", Company = "@ Progress Software" },
        };
        }

        public ObservableCollection<Experience> Experiences { get; set; }
    }
}
