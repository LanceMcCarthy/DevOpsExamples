using System.Collections.Generic;

namespace SDKBrowserMaui.Examples.ListViewControl.CellTypesCategory.TextCellExample
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new List<Book>
            {
                new Book{ Title = "The Fault in Our Stars ",  Author = "John Green"},
                new Book{ Title = "Divergent",  Author = "Veronica Roth"},
                new Book{ Title = "Gone Girl",  Author = "Gillian Flynn"},
                new Book{ Title = "Clockwork Angel",  Author = "Cassandra Clare"},
                new Book{ Title = "The Martian",  Author = "Andy Weir"},
                new Book{ Title = "Ready Player One",  Author = "Ernest Cline"},
                new Book{ Title = "The Lost Hero",  Author = "Rick Riordan"},
                new Book{ Title = "All the Light We Cannot See",  Author = "Anthony Doerr"},
                new Book{ Title = "Cinder",  Author = "Marissa Meyer"},
                new Book{ Title = "Me Before You",  Author = "Jojo Moyes"},
                new Book{ Title = "The Night Circus",  Author = "Erin Morgenstern"},
                new Book{ Title = "The Girl With the Dragon Tattoo",  Author = "Stieg Larsson"},
                new Book{ Title = "Harry Potter and the Goblet of Fire",  Author = "JK Rowling"},
                new Book{ Title = "A Little Life",  Author = "Hanya Yanagihara"},
                new Book{ Title = "Darkmans",  Author = "Nicola Barker"},
                new Book{ Title = "The Siege",  Author = "Helen Dunmore"},
                new Book{ Title = "Harvest",  Author = "Jim Crace"},
                };
        }

        public List<Book> Source { get; set; }
    }
}
