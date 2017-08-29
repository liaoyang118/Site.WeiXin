using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Site.Untity
{
    public class UntityConfig
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
    }
}
