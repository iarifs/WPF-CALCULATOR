using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class TimeOperations
    {
        public static string GetResult(string input, TimeUnits from, TimeUnits to)
        {
            var convertFrom = TimeUnitsAsString.GetResult(from);
            var convertTo = TimeUnitsAsString.GetResult(to);

            //convert input to mxParser string;
            input = $"{input}*[{convertFrom}] / [{convertTo}]";

            Expression e = new Expression(input);
            return e.calculate().ToString();
        }
    }
}
