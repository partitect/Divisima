using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Tools
{
	public class GeneralTool
	{
        public static string KarakterDuzelt(string link)
        {
            string Temp = link.ToLower();
            Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "-");
            Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
            Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
            Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
            Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
            Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
            Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
            Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
            Temp = Temp.Replace("+", ""); Temp = Temp.Replace(".", "");
            Temp = Temp.Replace("?", ""); Temp = Temp.Replace(",", "");
            Temp = Temp.Replace("'", "-"); Temp = Temp.Replace("!", "");
            Temp = Temp.Replace("amp;", ""); Temp = Temp.Replace(":", "-");
            Temp = Temp.Replace("#", "");
            Temp = Temp.Replace(";", "");

            return Temp;
        }
    }
}
