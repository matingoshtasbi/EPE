using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Core.NumberFormatter
{
    public static class NumberFormatter
    {
        public static string ConvertNumsToEnglish(string value) 
        {
            var formatted = value;
            formatted = formatted.Replace('۰', '0');
            formatted = formatted.Replace('۱', '1');
            formatted = formatted.Replace('۲', '2');
            formatted = formatted.Replace('۳', '3');
            formatted = formatted.Replace('۴', '4');
            formatted = formatted.Replace('۵', '5');
            formatted = formatted.Replace('۶', '6');
            formatted = formatted.Replace('۷', '7');
            formatted = formatted.Replace('۸', '8');
            formatted = formatted.Replace('۹', '9');
            return formatted;
        }
        public static string ConvertNumsToPersian(string value)
        {
            var formatted = value;
            formatted = formatted.Replace('0', '۰');
            formatted = formatted.Replace('1', '۱');
            formatted = formatted.Replace('2', '۲');
            formatted = formatted.Replace('3', '۳');
            formatted = formatted.Replace('4', '۴');
            formatted = formatted.Replace('5', '۵');
            formatted = formatted.Replace('6', '۶');
            formatted = formatted.Replace('7', '۷');
            formatted = formatted.Replace('8', '۸');
            formatted = formatted.Replace('9', '۹');
            return formatted;
        }
    }
}
