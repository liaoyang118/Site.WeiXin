using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Site.Untity
{
    public class UntityTool
    {
        public static string GetConfigValue(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {

            }

            return result;
        }

        public static string Md5_32(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }


        public static object JsonResult(bool success, string message)
        {
            return new
            {
                success = success,
                message = new { text = message }
            };
        }


    }
}
