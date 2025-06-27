using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace MyWpfApp;

public class MainViewModel
{
    public MainViewModel()
    {
        Products = new ObservableCollection<Product>();

        LoadProductsCommand = new DelegateCommand(o =>
        {
            foreach (var i in Enumerable.Range(1,200))
            {
                Products.Add(new Product
                {
                    Name = $"Product {i}",
                    Price = i * i * 1.23,
                    Quantity = i,
                    Reordered = DateTime.Now.AddDays(-i)
                });
            }
        });

        LoadProductsCommand.Execute(null);
    }

    public ObservableCollection<Product> Products { get; set; }

    public DelegateCommand LoadProductsCommand { get; set; }
}