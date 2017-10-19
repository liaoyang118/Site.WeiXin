using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Site.Untity
{

    public class HttpTool
    {
        static HttpClient client = new HttpClient();

        public static string Get(string url)
        {
            string content = string.Empty;
            HttpResponseMessage result = client.GetAsync(url).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

    }
}
