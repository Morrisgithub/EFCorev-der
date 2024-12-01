using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Väder.DataAccess;
// Använd din databas kontext här
class Program
{
    static void Main(string[] args)
    {
        using (var context = new Vädercontext())
        {
            // Create the database if it does not exist
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine($"The database was created. Time: {DateTime.Now}");
            }
            else
            {
                Console.WriteLine($"The database already exists. Time: {DateTime.Now}");
            }

            // Remove all previous weather data
            context.Weatherdata.RemoveRange(context.Weatherdata);
            context.SaveChanges();
            Console.WriteLine($"Previous weather data cleared. Time: {DateTime.Now}");

            // Import data from CSV
            string importFilePath = "TempFuktData01VS.csv";
            if (File.Exists(importFilePath))
            {
                Console.WriteLine($"Importing data from CSV... Time: {DateTime.Now}");
                ImportCSV.ImportfromCSV(context, importFilePath);
            }

            // Example weather data
            decimal averageTemperature = 4m;
            decimal averageHumidity = 90.2m;
            string location = "Stockholm";

            // Create new weather object
            var NewWeather = new Weathermodel
            {
                Date = DateTime.Now,
                Location = location,
                Temperature = averageTemperature,
                Humidity = averageHumidity
            };

            // Check for existing data
            var existingWeather = context.Weatherdata
                .FirstOrDefault(w => w.Location == NewWeather.Location && w.Date.Date == NewWeather.Date.Date);

            if (existingWeather == null)
            {
                Console.WriteLine($"Weather object created. Time: {NewWeather.Date}");

                // Save to database
                context.Weatherdata.Add(NewWeather);
                context.SaveChanges();
                Console.WriteLine($"Weather data saved to the database. Time: {DateTime.Now}");

                // Export to CSV
                ImportCSV.SaveToCSV(NewWeather, "TempFuktData01VS.csv");
                Console.WriteLine($"Weather data saved to CSV. Time: {DateTime.Now}");

                // Display data
                Console.WriteLine("A weather record has been saved to the database and TempFuktData01VS.csv!");

                // Find the hottest day
                var hottestDay = context.Weatherdata.OrderByDescending(w => w.Temperature).FirstOrDefault();
                Console.WriteLine($"Hottest day: {hottestDay?.Date:d} with {hottestDay?.Temperature}°C");
            }
            else
            {
                Console.WriteLine($"Weather data for {NewWeather.Location} on {NewWeather.Date.Date} already exists. No new data was saved.");
            }
        }
    }
}