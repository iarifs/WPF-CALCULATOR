using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class WeightMethodString
    {
        public static string GetResult(WeightUnits method)
        {

            if (method == WeightUnits.Kilograms)
            {
                return "kg";
            }
            else if (method == WeightUnits.Milligrams)
            {
                return "mg";
            }
            else if (method == WeightUnits.Grams)
            {
                return "gr";
            }
            else if (method == WeightUnits.Ounces)
            {
                return "oz";
            }
            else if (method == WeightUnits.Pounds)
            {
                return "lb";
            }

            return "";
        }
    }
}
