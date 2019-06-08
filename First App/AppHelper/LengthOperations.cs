using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class LengthOperations
    {
        public static string GetResult(string input, LengthUnits from, LengthUnits to)
        {
            var convertFrom = LengthUnitAsString.GetResult(from);
            var convertTo = LengthUnitAsString.GetResult(to);

            //convert input to mxParser string;
            input = $"{input}*[{convertFrom}] / [{convertTo}]";

            Expression e = new Expression(input);
            return e.calculate().ToString();
        }
    }
}
