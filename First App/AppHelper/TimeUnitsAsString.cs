using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class TimeUnitsAsString
    {
        public static string GetResult(TimeUnits method)
        {
            if (method == TimeUnits.Second)
            {
                return "s";
            }
            else if (method == TimeUnits.Minute)
            {
                return "min";
            }
            else if (method == TimeUnits.Hour)
            {
                return "h";
            }
            return "";
        }
    }
}
