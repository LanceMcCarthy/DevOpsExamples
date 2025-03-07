using System.Collections.ObjectModel;
using Telerik.Maui.Controls.Scheduler;

namespace MauiDemo;

public partial class SchedulerPage : ContentPage
{
	public SchedulerPage(SchedulerPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}

public class CustomAppointmentDataTemplate : DataTemplateSelector
{
    public DataTemplate AllDayAppointmentTemplate { get; set; }
    public DataTemplate AppointmentTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is AppointmentNode node)
        {
            if (node.Occurrence.Appointment.IsAllDay || (node.Occurrence.Appointment.End - node.Occurrence.Appointment.Start).TotalDays > 1)
            {
                return this.AllDayAppointmentTemplate;
            }
        }

        return this.AppointmentTemplate;
    }
}

public class SchedulerPageViewModel
{
    public SchedulerPageViewModel()
    {
        var date = DateTime.Today;

        Appointments =
        [
            new()
            {
                Subject = "Meeting with Tom",
                Start = date.AddHours(10),
                End = date.AddHours(11)
            },
            new()
            {
                Subject = "Lunch with Sara",
                Start = date.AddHours(12).AddMinutes(30),
                End = date.AddHours(14)
            },
            new()
            {
                Subject = "Elle Birthday",
                Start = date,
                End = date.AddHours(11),
                IsAllDay = true
            },
            new()
            {
                Subject = "Football Game",
                Start = date.AddDays(2).AddHours(15),
                End = date.AddDays(2).AddHours(17)
            }
        ];
    }

    public ObservableCollection<Appointment> Appointments { get; set; }
}