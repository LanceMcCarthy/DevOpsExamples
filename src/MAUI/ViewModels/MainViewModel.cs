using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;
using MauiDemo.Interfaces;
using System.Collections.Specialized;

namespace MauiDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IEnumerable<Employee> data;
    private ObservableRangeCollection<Employee> employees;
    private bool hasItems;

    public MainViewModel()
    {
        AppearingCommand = new Command(OnAddRange);
        StartOverCommand = new Command(OnStartOver);
        AddRangeCommand = new Command(OnAddRange);
        ClearItemsCommand = new Command(OnClearItems);
        CheckDataViewCommand = new Command(CheckDataView);

        data = SampleDataService.Current.GenerateEmployeeData();

        Employees = [];
        Employees.AddRange(data.Skip(Employees.Count).Take(5));
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

    public Command CheckDataViewCommand { get; set; }

    public IDataGridView DataGridView { get; set; }

    private void CheckDataView()
    {
        while (true)
        {
            var currentView = DataGridView.GetDataView();

            if (currentView.IsDataReady)
            {
                // Items currently filtered/sorted/grouped
                var filteredItems = currentView.Items;

                Shell.Current.DisplayAlert(
                    "DataView Result", 
                    $"You have {filteredItems.Count} items in the dataView", 
                    "okay");
            }
            else
            {
                // Wait 500ms, then check IsDataReady again
                Task.Delay(500);
                continue;
            }

            break;
        }
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