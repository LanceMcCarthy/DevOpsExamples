using HelloMaui.Models;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;

namespace HelloMaui.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<Task> Tasks { get; }
        public ObservableCollection<Experience> Experiences { get; }
        public ObservableCollection<CategoricalData> Data { get; }
        public ObservableCollection<CategoricalData> Data1 { get; }
        public ObservableCollection<CategoricalData> Data2 { get; }
        public ObservableCollection<CategoricalData> Data3 { get; }
        public ObservableCollection<CategoricalData> Data4 { get; }

        public MainViewModel()
        {
            this.Tasks = new ObservableCollection<Task>()
            {
                new Task() { Title = "Create a MAUI app to test handlers ", Status = "Status: in progress" },
                new Task() { Title = "Migrate wrappers to .NET 6", Status = "Status: in progress" },
            };

            this.Experiences = new ObservableCollection<Experience>()
            {
                new Experience() { Title = "JS Developer", Company = "@ Progress Software" },
                new Experience() { Title = "Technical Support Engineer", Company = "@ Progress Software" },
                new Experience() { Title = "Junior Technical Support Engineer", Company = "@ Progress Software" },
            };

            this.Data = new ObservableCollection<CategoricalData>()
            {
                new CategoricalData { Category = "Mon", Value = 5 },
                new CategoricalData { Category = "Tue", Value = 15 },
                new CategoricalData { Category = "Wed", Value = 3 },
                new CategoricalData { Category = "Thu", Value = 10 },
                new CategoricalData { Category = "Fri", Value = 2 },
            };

            this.Data1 = new ObservableCollection<CategoricalData>()
            {
                new CategoricalData { Category = "Mon", Value = 9 },
                new CategoricalData { Category = "Tue", Value = 10 },
                new CategoricalData { Category = "Wed", Value = 6 },
                new CategoricalData { Category = "Thu", Value = 9 },
                new CategoricalData { Category = "Fri", Value = 7 },
            };

            this.Data2 = new ObservableCollection<CategoricalData>()
            {
                new CategoricalData { Category = "Mon", Value = 11 },
                new CategoricalData { Category = "Tue", Value = 25 },
                new CategoricalData { Category = "Wed", Value = 3 },
                new CategoricalData { Category = "Thu", Value = 20 },
                new CategoricalData { Category = "Fri", Value = 3 },
            };

            this.Data3 = new ObservableCollection<CategoricalData>()
            {
                new CategoricalData() { Category = "Mon", Value = 45 },
                new CategoricalData() { Category = "Tue", Value = 20 },
                new CategoricalData() { Category = "Wed", Value = 30 },
                new CategoricalData() { Category = "Thu", Value = 55 },
                new CategoricalData() { Category = "Fri", Value = 40 }
            };

            this.Data4 = new ObservableCollection<CategoricalData>()
            {
                new CategoricalData() { Category = "Mon", Value = 95 },
                new CategoricalData() { Category = "Tue", Value = 70 },
                new CategoricalData() { Category = "Wed", Value = 85 },
                new CategoricalData() { Category = "Thu", Value = 45 },
                new CategoricalData() { Category = "Fri", Value = 55 }
            };
        }
    }
}