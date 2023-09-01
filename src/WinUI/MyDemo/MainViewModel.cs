using System;
using CommonHelpers.Models;
using Telerik.Core;

namespace MyDemo;

public class MainViewModel : CommonHelpers.Common.ViewModelBase
{
    public MainViewModel()
    {
    }

    private BindableCollection<Employee> employees = new()
    {
        new() { Name = "John Doe", Salary = 10000, StartDate = DateTime.Today, Position = "TSE I", VacationTotal = 21, VacationUsed = 7 },
        new() { Name = "John Doe Junior", Salary = 10000, StartDate = DateTime.Today, Position = "TSE II", VacationTotal = 21, VacationUsed = 7 },
        new() { Name = "Jane Doe", Salary = 10000, StartDate = DateTime.Today, Position = "TSE IV", VacationTotal = 21, VacationUsed = 7 },
    };

    public BindableCollection<Employee> Employees
    {
        get => employees;
        set => SetProperty(ref employees, value);
    }
}