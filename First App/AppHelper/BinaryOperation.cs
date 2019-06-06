using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class BinaryOperation
    {
        public static string GetResult(int input, NumberSystem method)
        {
            if (method == NumberSystem.Binary)
            {
                return Convert.ToString(input, 2);
            }
            else if (method == NumberSystem.HexaDecimal)
            {
                return Convert.ToString(input, 16);
            }
            else if (method == NumberSystem.Octal)
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
