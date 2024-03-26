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
    private bool hasItems;

    public MainViewModel()
    {
        AppearingCommand = new(OnAddRange);
        StartOverCommand = new(OnStartOver);
        AddRangeCommand = new(OnAddRange);
        ClearItemsCommand = new(OnClearItems);

        data = SampleDataService.Current.GenerateEmployeeData();

        Employees = new();
        Employees.CollectionChanged += Employees_CollectionChanged;
    }

    private void Employees_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        HasItems = Employees.Count > 0;
    }

    public ObservableRangeCollection<Employee> Employees
    {
        get => employees;
        set => SetProperty(ref employees, value);
    }

    public bool HasItems
    {
        get => hasItems;
        set => SetProperty(ref hasItems, value);
    }

    public Command StartOverCommand { get; set; }

    public Command AddRangeCommand { get; set; }

    public Command ClearItemsCommand { get; set; }

    public Command AppearingCommand { get; set; }

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