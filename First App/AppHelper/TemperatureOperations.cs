using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class TemperatureOperations
    {
        public static string GetResult(string input, TemperatureUnits method)
        {
            if (input == "")
            {
                input = "0";
            }
            var inputAsFloat = float.Parse(input, CultureInfo.InvariantCulture.NumberFormat);

            if (method == TemperatureUnits.Fahrenheit)
            {
                return ((inputAsFloat * 9) / 5 + 32).ToString() + "°C";
            }
            else
            {
                return ((inputAsFloat - 32) * (5.0 / 9.0)).ToString() + "°F";
            }
        }
    }
}
