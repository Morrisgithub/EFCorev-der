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
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public decimal Temperature { get; set; }
            public decimal Humidity { get; set; }

        }
    }
