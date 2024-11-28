using System;
using System.Diagnostics;
using Väder.DataAccess;


class Program 
{
    static void Main(string[] args)
    {
        using (var context = new Vädercontext ())
        {
          
            double averageTemperature = 16d;
            int averageHumidity = 90;

            
            var (riskvalue, riskDescription) = Calculations.Calculate(averageTemperature, averageHumidity);

           
            var newWeather = new Weathermodel
            {
                date = DateTime.Now,
                Location = "Södertälje",
                Temprature = averageTemperature,
                Humidity = averageHumidity,
                Moldrisk = riskDescription,
                Winter = "5 december 2023",
                Autumn = "22 september 2024"
            };


            context.Weatherdata.Add(newWeather);
            context.SaveChanges();


            string csvFilePath = "TempFuktData.csv";

           
            bool fileExists = File.Exists(csvFilePath);


            using (var writer = new StreamWriter(csvFilePath, append: true))
            {
                
                if (!fileExists)
                {
                    writer.WriteLine("date,Location,Temprature,Humidity,Moldrisk,Winter,Autumn");
                }


                writer.WriteLine($"{newWeather.date},{newWeather.Location},{newWeather.Temprature},{newWeather.Humidity},{newWeather.Moldrisk},{newWeather.Winter},{newWeather.Autumn}");
            }

            Console.WriteLine("A weather record has been saved in the database and TempfuktData.csv!");
            Console.WriteLine($"Moldrisk: {riskvalue} ({riskDescription})");


            Process.Start(new ProcessStartInfo(csvFilePath) { UseShellExecute = true });
        }
    }
}




    