using System;
using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CommonHelpers.Models;

namespace MyDemo;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Employees =
        [
            new() { Name = "John Doe", Salary = 10000, StartDate = DateTime.Today, Position = "TSE I", VacationTotal = 21, VacationUsed = 7 },
            new() { Name = "John Doe Junior", Salary = 10000, StartDate = DateTime.Today, Position = "TSE II", VacationTotal = 21, VacationUsed = 7 },
            new() { Name = "Jane Doe", Salary = 10000, StartDate = DateTime.Today, Position = "TSE IV", VacationTotal = 21, VacationUsed = 7 }
        ];
    }

    public ObservableCollection<Employee> Employees
    {
        get;
        set => SetProperty(ref field, value);
    }
}