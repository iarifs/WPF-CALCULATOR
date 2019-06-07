using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class PercentOperation
    {

        public static string GetResult(string input, PercentUnits mode)
        {
            var result = float.Parse(input, CultureInfo.InvariantCulture.NumberFormat);

            if (mode == PercentUnits.Percent)
            {
                return (result / 100).ToString();
            }
            else
            {
                return (result * 100).ToString() + "%";
            }
        }

    }
}
