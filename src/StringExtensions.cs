using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTrader
{
    public static class StringExtensions
    {
        public static int ToInt(this string s)
        {
            int res;
            int.TryParse(s, out res);
            return res;
        }

        public static long ToLong(this string s)
        {
            long res;
            long.TryParse(s, out res);
            return res;
        }

        public static float ToFloat(this string s)
        {
            float res;
            float.TryParse(s, out res);
            return res;
        }
    }
}
