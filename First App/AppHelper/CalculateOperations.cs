using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class CalculateOperations
    {
        public static string GetResult(string screenData)
        {
            Expression e = new Expression(screenData);
            return e.calculate().ToString();
        }

    }
}
