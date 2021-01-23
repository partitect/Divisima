 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public static string getMD5(string _text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_text));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

    }
}
