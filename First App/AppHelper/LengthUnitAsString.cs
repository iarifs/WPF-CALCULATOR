using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class LengthUnitAsString
    {
        public static string GetResult(LengthUnits method)
        {
            if (method == LengthUnits.Centimeter)
            {
                return "cm";
            }
            else if (method == LengthUnits.Feet)
            {
                return "ft";
            }
            else if (method == LengthUnits.Inch)
            {
                return "inch";
            }
            else if (method == LengthUnits.Kilometer)
            {
                return "km";
            }
            else if (method == LengthUnits.Meter)
            {
                return "m";
            }
            else if (method == LengthUnits.Millimeter)
            {
                return "mm";
            }
            return "";
        }
    }
}
