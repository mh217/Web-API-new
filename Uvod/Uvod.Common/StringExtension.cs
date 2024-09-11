using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvod.Common
{
    public static class StringExtension
    {

        public static string AddToStartOfString(this string input)
        {
            return $"%{input}";
        }

        public static string AddToEndOfString(this string input)
        {
            return $"{input}%";
        }

        public static string AddStringBetween(this string input)
        {
            return $"%{input}%";
        }
    }
}
