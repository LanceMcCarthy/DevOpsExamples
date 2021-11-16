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
            new Experience() { Title = ".NET Software Engineer", Company = "@ Progress Software" },
            new Experience() { Title = "Swift Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Ruby Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Android Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Full Stack Developer", Company = "@ Progress Software" },
            new Experience() { Title = "JS Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Back-end Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Front End Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Junior Developer", Company = "@ Progress Software" },
            new Experience() { Title = "Senior UX Designer", Company = "@ Progress Software" },
            new Experience() { Title = "Junior UX Designer ", Company = "@ Progress Software" },
            new Experience() { Title = "Senior Technical Support Engineer", Company = "@ Progress Software" },
            new Experience() { Title = "QA Automation Engineer", Company = "@ Progress Software" },
            new Experience() { Title = "Technical Support Engineer", Company = "@ Progress Software" },
            new Experience() { Title = "Junior Technical Support Engineer", Company = "@ Progress Software" },
        };
        }

        public ObservableCollection<Experience> Experiences { get; set; }
    }
}
