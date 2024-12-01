using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väder.DataAccess
{
    public class ImportCSV
    {



        public static void ImportfromCSV(Vädercontext context, string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var culture = CultureInfo.InvariantCulture;

            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var values = line.Split(',');

                if (values.Length != 4)
                {
                    continue;
                }

                try
                {

                    var Väder = new Weathermodel
                    {
                        Date = DateTime.Parse(values[0], culture),
                        Location = values[1],
                        Temperature = decimal.Parse(values[2], culture),
                        Humidity = decimal.Parse(values[3], culture),
                    };


                    context.Weatherdata.Add(Väder);
                }
                catch (Exception ex)
                {

                }
            }

        }

        public static void SaveToCSV(Weathermodel väder, string filePath)
        {
            try
            {
                bool fileExists = File.Exists(filePath);

                using (var writer = new StreamWriter(filePath, append: true))
                {

                    if (!fileExists)
                    {
                        writer.WriteLine("Datum,Plats,Temperatur,Luftfuktighet");
                    }


                    string datetime = väder.Date.ToString("yyyy-MM-dd");
                    string location = väder.Location ?? "";
                    string temperature = väder.Temperature.ToString(CultureInfo.InvariantCulture);
                    string humidity = väder.Humidity.ToString(CultureInfo.InvariantCulture);


                    writer.WriteLine($"{datetime},{location},{temperature},{humidity}");
                }

                Console.WriteLine($"Data has been saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV: {ex.Message}");
            }
        }
    }
}