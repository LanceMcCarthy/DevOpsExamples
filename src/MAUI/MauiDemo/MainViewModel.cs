using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;
using System.Collections.Specialized;

namespace MauiDemo;

public class MainViewModel : ViewModelBase
{
    private readonly IEnumerable<Employee> data;
    private ObservableRangeCollection<Employee> employees;

    public MainViewModel()
    {
        data = SampleDataService.Current.GenerateEmployeeData();
        AppearingCommand = new(OnAddRange);
        StartOverCommand = new(OnStartOver);
        AddRangeCommand = new(OnAddRange);
        ClearItemsCommand = new(OnClearItems);
    }

    public Command StartOverCommand { get; set; }

    public Command AddRangeCommand { get; set; }

    public Command ClearItemsCommand { get; set; }

    public Command AppearingCommand { get; set; }

    public ObservableRangeCollection<Employee> Employees
    {
        get => employees ??= new();
        set => SetProperty(ref employees, value);
    }

    private void OnAddRange()
    {
        Employees.AddRange(data.Skip(Employees.Count).Take(5), NotifyCollectionChangedAction.Reset);
    }

    private void OnStartOver()
    {
        Employees = new();
    }

    private void OnClearItems()
    {
        Employees.Clear();
    }
}