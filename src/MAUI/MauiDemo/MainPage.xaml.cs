using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MauiDemo
{
	public partial class MainPage : ContentPage
    {
        private readonly List<Person> people;
        private readonly Random rand;
		
		public MainPage()
		{
			InitializeComponent();
            rand = new Random(DateTime.Now.DayOfYear);
			people = Enumerable.Range(1, 20).Select(i => new Person($"Person {i}", i)).ToList();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			CounterLabel.Text = $"you selected {people[rand.Next(0, 20)].FirstName}";
		}
	}

    public record Person(string FirstName, int Age);
}
