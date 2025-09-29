using MauiDemo.Models;

namespace MauiDemo.Views;

public partial class DataFormPage : ContentPage
{
	public DataFormPage()
	{
		InitializeComponent();
        MyDataForm.BindingContext = new DataTypeEditorsModel();
    }
}