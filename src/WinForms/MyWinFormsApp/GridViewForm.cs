using System.Collections.Generic;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class GridViewForm : Form
    {
        public GridViewForm()
        {
            InitializeComponent();

            radGridView1.DataSource = new List<Person>
            {
                new Person { Id = 1, Name = "John Doe", Age = 30 },
                new Person { Id = 2, Name = "Jane Doe", Age = 25 },
                new Person { Id = 3, Name = "Sam Smith", Age = 40 }
            };
        }

        private class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
