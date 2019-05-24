using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class BinaryOperation
    {
        public static string GetResult(int input)
        {
            return Convert.ToString(input, 2);
        }
    }
}
