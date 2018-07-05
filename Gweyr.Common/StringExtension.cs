using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweyr.Common
{
    public static class StringExtension
    {
        public static string FirstToUpper(this string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
                return str;

            return Char.ToUpperInvariant(str[0]) + str.Substring(1).ToLower();
        }
    }
}
