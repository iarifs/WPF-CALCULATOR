using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class FileOperations
    {
        public static string GetResult(string input, FileUnits from, FileUnits to)
        {
            var convertFrom = FileUnitAsString.GetResult(from);
            var convertTo = FileUnitAsString.GetResult(to);

            //convert input to mxParser string;
            input = $"{input}*[{convertFrom}] / [{convertTo}]";

            Expression e = new Expression(input);
            return e.calculate().ToString();
        }
    }
}
