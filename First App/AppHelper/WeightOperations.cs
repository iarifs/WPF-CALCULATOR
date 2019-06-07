using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class WeightOperations
    {
        public static string GetResult(string input, WeightUnits form, WeightUnits to)
        {
            var weightForm = WeightMethodString.GetResult(form);
            var weightTo = WeightMethodString.GetResult(to);

            //convert input to mxParser string;
            input = $"{input}*[{weightForm}] / [{weightTo}]";

            Expression e = new Expression(input);
            return e.calculate().ToString();
        }
    }
}
