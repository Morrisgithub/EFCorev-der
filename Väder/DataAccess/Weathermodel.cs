using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väder.DataAccess
{
    public class Weathermodel
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string Location { get; set; }
        public double Temprature { get; set; }
        public int Humidity { get; set; }
        public string Moldrisk { get; set; }
        public string Winter { get; set; }
        public string Autumn { get; set; }


    }
}
