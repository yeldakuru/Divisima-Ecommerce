using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Divisima.Tools
{
	public class GeneralTool
	{
		public static string UrlConvert(string url)
		{
			string result = url.ToLower().Replace(" ", "-").Replace("ş", "s")
				   .Replace("ı", "i")
				   .Replace("ğ", "g")
				   .Replace("ü", "u")
				   .Replace("ö", "o")
				   .Replace("ç", "c")
				   .Replace(" ", "-")
				   .Replace("'", "")
				   .Replace("\"", "")
				   .Replace(",", "")
				   .Replace(".", "")
				   .Replace("?", "")
				   .Replace("!", "")
				   .Replace("&", "and");
			result = Regex.Replace(result, @"[^a-z0-9-]", "");


			result = Regex.Replace(result, @"-{2,}", "-");


			result = result.Trim('-');

			return result;
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
