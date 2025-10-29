using MauiDemo.ViewModels;
using Telerik.Maui.Controls.Scheduler;

#pragma warning disable JMA001

namespace MauiDemo.Views;

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