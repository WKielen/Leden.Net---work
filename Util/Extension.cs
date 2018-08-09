using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Extensions
{
    public static class Util
    {
        public static string ToEuroString(this decimal d)
        {
            return "€ " + d.ToString("0.00");
        }
        public static string ToXMLEuroString(this decimal d)
        {
            return "&euro; " + d.ToString("0.00");
        }
        public static string ToXMLString(this decimal d)
        {
            return d.ToString("0.00").Replace(",", ".");
        }
        public static string ToCSVString(this decimal d)
        {
            return d.ToString("0.00");
        }
	    public static bool IsNumeric(this string s)
	    {
            float output;
            return float.TryParse(s, out output);
        }
        private static bool IsNumeric(this char c)
        {
            if (c < '0' || c > '9')
                return false;
            return true;
        }
        public static string RemoveNonNumeric(this string s)
        {
            string r = string.Empty;
            foreach (char c in s)
                if (c.IsNumeric()) r += c;
            return r;
        }

        public static string RemoveBom(this string p)
        {
            string BOMMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (p.StartsWith(BOMMarkUtf8))
                p = p.Remove(0, BOMMarkUtf8.Length);
            return p.Replace("\0", "");
        }

    }
}
