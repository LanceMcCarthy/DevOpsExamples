using System.Collections.Specialized;
using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace MauiDemo;

public class MainViewModel : ViewModelBase
{
    private ObservableRangeCollection<Employee> employees;

    public MainViewModel()
    {
        var data = SampleDataService.Current.GenerateEmployeeData();
        
        StartOverCommand = new Command(() =>
        {
            Employees = new ObservableRangeCollection<Employee>();
        });

        AddRangeCommand = new Command(() =>
        {
            Employees.AddRange(data.Skip(Employees.Count).Take(5), NotifyCollectionChangedAction.Reset);
        });

        ClearItemsCommand = new Command(() =>
        {
            Employees.Clear();
        });
    }

    public Command StartOverCommand { get; set; }

    public Command AddRangeCommand { get; set; }

    public Command ClearItemsCommand { get; set; }

    public ObservableRangeCollection<Employee> Employees
    {
        get => employees ??= new ObservableRangeCollection<Employee>();
        set => SetProperty(ref employees, value);
    }
}