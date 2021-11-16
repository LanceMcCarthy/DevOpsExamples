using System.Collections.ObjectModel;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.TemplatedPickerControl
{
    // >> templatedpicker-viewmodel
    public class LocationViewModel : NotifyPropertyChangedBase
    {
        private Country fromCountry;
        private City fromCity;

        public LocationViewModel()
        {
            this.Countries = new ObservableCollection<Country>
            {
                new Country
                {
                    Name = "Austria",
                    Cities =
                    {
                        new City { Name = "Graz" },
                        new City { Name = "Innsbruck" },
                        new City { Name = "Linz" },
                        new City { Name = "Ratz" },
                        new City { Name = "Salzburg" },
                        new City { Name = "Vienna" },
                        new City { Name = "Wolfsberg" },
                        new City { Name = "Zeltweg" }
                    }
                },
                new Country
                {
                    Name = "Belgium",
                    Cities =
                    {
                        new City { Name = "Antwerp" },
                        new City { Name = "Assesse" },
                        new City { Name = "Bruges" },
                        new City { Name = "Charleroi" },
                        new City { Name = "Lint" },
                        new City { Name = "Ranst" },
                        new City { Name = "Schaffen" },
                        new City { Name = "Veurne" },
                        new City { Name = "Zingem" },
                    }
                },
                new Country
                {
                    Name = "Denmark",
                    Cities =
                    {
                        new City { Name = "Aalborg" },
                        new City { Name = "Aarhus" },
                        new City { Name = "Billund" },
                        new City { Name = "Copenhagen" },
                        new City { Name = "Karup" },
                        new City { Name = "Odense" },
                        new City { Name = "Viborg" },
                        new City { Name = "Vojens" }
                    }
                },
                new Country
                {
                    Name = "France",
                    Cities =
                    {
                        new City { Name = "Aurillac" },
                        new City { Name = "Belley" },
                        new City { Name = "Bourg-en-Bresse" },
                        new City { Name = "Carcassonne" },
                        new City { Name = "Caen" },
                        new City { Name = "Deauville" },
                        new City { Name = "La Rochelle" },
                        new City { Name = "Nice" },
                        new City { Name = "Marseille" },
                        new City { Name = "Paris - Val-De-Marne" },
                        new City { Name = "Paris - Val d'Oise" },
                        new City { Name = "Rodez" }
                    }
                },
                new Country
                {
                    Name = "Germany",
                    Cities =
                    {
                        new City { Name = "Baden-Baden" },
                        new City { Name = "Berlin" },
                        new City { Name = "Borkum" },
                        new City{ Name = "Bremen" },
                        new City{ Name = "Dortmund" },
                        new City{ Name = "Dresden" },
                        new City{ Name = "Hamburg" },
                        new City{ Name = "Hannover" },
                        new City{ Name = "Leipzig" },
                        new City{ Name = "Mannheim" },
                        new City{ Name = "Munich" },
                        new City{ Name = "Nuremberg" }
                    }
                },
                new Country
                {
                    Name = "Italy",
                    Cities =
                    {
                        new City { Name = "Aosta" },
                        new City { Name = "Bari" },
                        new City { Name = "Bologna" },
                        new City { Name = "Parma" },
                        new City { Name = "Rimini" },
                        new City { Name = "Rome - Fiumicino" },
                        new City { Name = "Rome - Ciampino" }
                    }
                },
                new Country
                {
                    Name = "Netherlands",
                    Cities =
                    {
                        new City { Name = "Amsterdam" },
                        new City { Name = "Bonaire" },
                        new City { Name = "Eindhoven" },
                        new City { Name = "Maastricht" },
                        new City { Name = "Rotterdam" }
                    }
                },
                new Country
                {
                    Name = "Portugal",
                    Cities =
                    {
                        new City { Name = "Braga" },
                        new City { Name = "Cascais" },
                        new City { Name = "Lisbon" },
                        new City { Name = "Porto" }
                    }
                },
                new Country
                {
                    Name = "Spain",
                    Cities =
                    {
                        new City { Name = "Alicante" },
                        new City { Name = "Barcelona" },
                        new City { Name = "Madrid" },
                        new City { Name = "Seville" },
                        new City { Name = "Valencia" },
                        new City { Name = "Zaragoza" }
                    }
                },
                new Country
                {
                    Name = "United Kingdom",
                    Cities =
                    {
                        new City { Name = "Bristol Airport" },
                        new City { Name = "Castle Donington" },
                        new City { Name = "Liverpool" },
                        new City { Name = "London City Airport" },
                        new City { Name = "London Luton" },
                        new City { Name = "Manchester Airport" },
                        new City { Name = "Norwich" },
                        new City { Name = "Southampton" }
                    }
                },
            };
        }

        public Country FromCountry
        {
            get
            {
                return this.fromCountry;
            }
            set
            {
                if (value != this.fromCountry)
                {
                    this.UpdateValue(ref this.fromCountry, value);
                }
            }
        }

        public City FromCity
        {
            get
            {
                return this.fromCity;
            }
            set
            {
                if (value != this.fromCity)
                {
                    this.UpdateValue(ref this.fromCity, value);
                }
            }
        }

        public ObservableCollection<Country> Countries { get; }
    }
    // << templatedpicker-viewmodel
}
