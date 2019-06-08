using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App.AppHelper
{
    public static class FileUnitAsString
    {
        public static string GetResult(FileUnits method)
        {
            if (method == FileUnits.Byte)
            {
                return "B";
            }
            else if (method == FileUnits.Kilobyte)
            {
                return "kB";
            }
            else if (method == FileUnits.Megabyte)
            {
                return "MB";
            }
            else if (method == FileUnits.Gigabyte)
            {
                return "GB";
            }
            else if (method == FileUnits.Terabyte)
            {
                return "TB";
            }
            return "";

        }
    }
}
