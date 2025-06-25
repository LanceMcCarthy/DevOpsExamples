using MauiDemo.Interfaces;
using MauiDemo.ViewModels;
using Telerik.Maui.Data;

namespace MauiDemo.Views;

public partial class MainPage : ContentPage, IDataGridView
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;

        // Identify this view for the IoC reference
        vm.DataGridView = this;
    }

    public IDataViewCollection GetDataView()
    {
        return EmployeesGrid.GetDataView();
    }
}