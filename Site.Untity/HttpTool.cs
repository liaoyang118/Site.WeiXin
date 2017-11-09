using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Site.Untity
{

    public class HttpTool
    {
        //fiddler 代理
        static HttpClientHandler handler = new HttpClientHandler()
        {
            Proxy = new WebProxy("127.0.0.1", 8888),//8888 fiddler 端口
            UseProxy = true
        };

        static HttpClient client = new HttpClient(handler);

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

        /// <summary>
        /// post提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string content = string.Empty;
            HttpContent requestContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        /// <summary>
        /// 表单提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name=""></param>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string Post(string url, string fileName, byte[] bytes)
        {
            string content = string.Empty;

            #region  【无效】HttpClient模式 post,微信服务器无法解析，改用 WebRequest
            //MultipartFormDataContent requestContent = new MultipartFormDataContent();
            //requestContent.Add(CreateFileContent(bytes, fileName, "application/octet-stream"));
            //使用代理
            //HttpClientHandler handler = new HttpClientHandler()
            //{
            //    Proxy = new WebProxy("127.0.0.1", 8888),//8888 fiddler 端口
            //    UseProxy = true
            //};
            //using (var http = new HttpClient(handler))
            //{

            //    HttpResponseMessage result = http.PostAsync(url, requestContent).Result;
            //    if (result.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        content = result.Content.ReadAsStringAsync().Result;
            //    }
            //} 
            #endregion

            content = WebRequestPost(url, fileName, bytes);
            return content;
        }

        private static HttpContent CreateFileContent(byte[] bytes, string fileName, string contentType)
        {
            var fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.Clear();
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"media\"",//微信端上传文件固定是media,普通post为file
                FileName = "\"" + fileName + "\""
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");


            //Stream stream = new MemoryStream(bytes);
            //StreamContent fileContent = new StreamContent(stream);
            //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            //fileContent.Headers.ContentDisposition.Name = "\"media\"";
            //fileContent.Headers.ContentDisposition.FileName = "\"搜狗截图20170718171309.png\"";
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            //fileContent.Headers.ContentType.CharSet = "\"utf-8\"";


            //var fileContent = new ByteArrayContent(bytes);
            //fileContent.Headers.Clear();
            //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //{
            //    Name = "\"file\"",
            //    FileName = "\"" + fileName + "\""
            //}; // the extra quotes are key here
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return fileContent;
        }


        /// <summary>
        /// post body字符参数提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Post(string url, string param)
        {
            string content = string.Empty;
            HttpContent requestContent = new StringContent(param);
            HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }


        /// <summary>
        /// WebRequest Post
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <param name="bf"></param>
        /// <returns></returns>
        public static string WebRequestPost(string url, string fileName, byte[] bf)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Proxy = new WebProxy("127.0.0.1", 8888);

            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            //请求头部信息 
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bf, 0, bf.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string content = sr.ReadToEnd();
            return content;
        }

    }
}
