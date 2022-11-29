using System.Collections.ObjectModel;

namespace MauiDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
	}
}

public class MainViewModel
{
    public MainViewModel()
    {
        this.Books = new ObservableCollection<Book>{
            new() { Title = "The Fault in Our Stars ",  Author = "John Green", Description = "Small length description."},
            new() { Title = "Divergent",  Author = "Veronica Roth", Description = "Another small description."},
            new() { Title = "Gone Girl",  Author = "Gillian Flynn", IsFavourite = true, Description = "This is a medium length description, it will likely cause a line break or two (depending on the app's width)."},
            new() { Title = "Clockwork Angel",  Author = "Cassandra Clare", Description = "This is a small description."},
            new() { Title = "The Martian",  Author = "Andy Weir", Description = "Long description - Telerik ListView for .NET MAUI is a virtualizing list component that provides the most popular features associated with scenarios where a list of items is used. All these features are embedded in a single control for saving developers' time and providing better experience."},
            new() { Title = "Ready Player One",  Author = "Ernest Cline", Description = "Another small description."},
            new() { Title = "The Lost Hero",  Author = "Rick Riordan", IsFavourite = true, Description = "This is a medium length description, it will likely cause a line break or two (depending on the app's width)."},
            new() { Title = "All the Light We Cannot See",  Author = "Anthony Doerr", Description = "This is a medium length description, it will likely cause a line break or two (depending on the app's width)."},
            new() { Title = "Cinder",  Author = "Marissa Meyer", Description = "This is a small description."},
            new() { Title = "Me Before You",  Author = "Jojo Moyes", Description = "Telerik ListView for .NET MAUI is a virtualizing list component that provides the most popular features associated with scenarios where a list of items is used. All these features are embedded in a single control for saving developers' time and providing better experience."},
            new() { Title = "The Night Circus",  Author = "Erin Morgenstern", Description = "This is a small description."},
        };
    }

    public ObservableCollection<Book> Books { get; set; }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsFavourite { get; set; }
    public string Description { get; set; }
}