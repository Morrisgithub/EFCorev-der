using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väder.DataAccess
{
    public class Calculations
    {
        
            public static (double riskvalue, string riskDescription) Calculate(double Temperature, double Humidity)
            {
                double riskvalue;
                string riskDescription;

                if (Humidity < 70 || Temperature < 5)
                {
                    riskvalue = 1.0d;
                    riskDescription = "Low risk";
                }
                else if (Humidity >= 70 && Humidity <= 85 && Temperature >= 5 && Temperature <= 15)
                {
                    riskvalue = 2.5d;
                    riskDescription = "Medium risk";
                }
                else if (Humidity > 85 && Temperature > 15)
                {
                    riskvalue = 4.0d;
                    riskDescription = "High risk";
                }
                else
                {
                    riskvalue = 0.5d;
                    riskDescription = "Much low risk";
                }

                return (riskvalue, riskDescription);
            }
        }
    
}

