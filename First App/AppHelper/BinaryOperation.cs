using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class BinaryOperation
    {
        public static string GetResult(long input, NumberUnits method)
        {
            if (method == NumberUnits.Binary)
            {
                return Convert.ToString(input, 2);
            }
            else if (method == NumberUnits.HexaDecimal)
            {
                return Convert.ToString(input, 16);
            }
            else if (method == NumberUnits.Octal)
            {
                return Convert.ToString(input, 8);
            }
            else
            {
                return "";
            }
        }
    }
}
