using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using SalesDashboard.UWP.Models;

namespace SalesDashboard.UWP.Utilities
{
    public class CSVParser
    {
        private static async Task<IEnumerable<T>> LoadData<T>(string filePath, Func<string[], T> parseAction)
        {
            var uri = new System.Uri(filePath);

            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);

            var stream = await file.OpenReadAsync();

            var list = new List<T>();

            using (var streamReader = new StreamReader(stream.AsStreamForRead()))
            {
                string line = await streamReader.ReadLineAsync();

                int skipCount = 0;

                while (line != null && skipCount < 1)
                {
                    line = await streamReader.ReadLineAsync();

                    skipCount++;
                }

                while (line != null)
                {
                    string[] columns = line.Split(',');

                    list.Add(parseAction(columns));

                    line = await streamReader.ReadLineAsync();
                }
            }

            return list;
        }

        public static async Task<IEnumerable<OrderDetail>> LoadDetails()
        {
            OrderDetail Func(string[] s) => new OrderDetail
            {
                SalesOrderNumber = s[0],
                OrderDate = DateTime.Parse(s[1], CultureInfo.InvariantCulture),
                ItemsSold = int.Parse(s[2], CultureInfo.InvariantCulture),
                SalesAmount = decimal.Parse(s[3], CultureInfo.InvariantCulture),
                Country = s[4],
                Products = ((ProductName)(int.Parse(s[5]) - 1)).ToString()
            };
            
            return await LoadData<OrderDetail>("ms-appx:///Data/OrderDetails.csv", Func);
        }

        public static async Task<IEnumerable<SalesAmount>> LoadSalesAmount()
        {
            SalesAmount Func(string[] s) => new SalesAmount
            {
                TargetAmount = string.IsNullOrEmpty(s[0]) ? 0 : decimal.Floor(decimal.Parse(s[0], CultureInfo.InvariantCulture)),
                OrderDate = DateTime.Parse(s[1], CultureInfo.InvariantCulture),
                ActualAmount = decimal.Floor(decimal.Parse(s[2], CultureInfo.InvariantCulture)),
                ProductCategory = s[3],
                Country = s[4]
            };
            
            return await LoadData<SalesAmount>("ms-appx:///Data/SalesAmount.csv", Func);
        }

    }
}
