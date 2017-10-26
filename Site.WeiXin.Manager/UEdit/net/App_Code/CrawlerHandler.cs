using Site.Service.UploadService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Crawler 的摘要说明
/// </summary>
public class CrawlerHandler : Handler
{
    private string[] Sources;
    private Crawler[] Crawlers;
    public CrawlerHandler(HttpContext context) : base(context) { }

    public override void Process()
    {
        Sources = Request.Form.GetValues("source[]");
        if (Sources == null || Sources.Length == 0)
        {
            WriteJson(new
            {
                state = "参数错误：没有指定抓取源"
            });
            return;
        }
        Crawlers = Sources.Select(x => new Crawler(x, Server).Fetch()).ToArray();
        WriteJson(new
        {
            state = "SUCCESS",
            list = Crawlers.Select(x => new
            {
                state = x.State,
                source = x.SourceUrl,
                url = x.ServerUrl,
                wcfSourceUrl = x.WcfSourceUrl
            })
        });
    }
}

public class Crawler
{
    public string SourceUrl { get; set; }

    //抓取回来的图片，上传到服务后的缩略图地址
    public string ServerUrl { get; set; }

    /// <summary>
    /// 抓取回来的图片，上传到服务后的原图地址
    /// </summary>
    public string WcfSourceUrl { get; set; }
    public string State { get; set; }

    private HttpServerUtility Server { get; set; }


    public Crawler(string sourceUrl, HttpServerUtility server)
    {
        this.SourceUrl = sourceUrl;
        this.Server = server;
    }

    public Crawler Fetch()
    {
        if (!IsExternalIPAddress(this.SourceUrl))
        {
            State = "INVALID_URL";
            return this;
        }
        var request = HttpWebRequest.Create(this.SourceUrl) as HttpWebRequest;
        using (var response = request.GetResponse() as HttpWebResponse)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                State = "Url returns " + response.StatusCode + ", " + response.StatusDescription;
                return this;
            }
            if (response.ContentType.IndexOf("image") == -1)
            {
                State = "Url is not an image";
                return this;
            }
            
            List<string> urlResult = new List<string>();
            
            try
            {
                var stream = response.GetResponseStream();
                var reader = new BinaryReader(stream);
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int count;
                    while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ms.Write(buffer, 0, count);
                    }
                    bytes = ms.ToArray();
                }
                //File.WriteAllBytes(savePath, bytes);
                //抓取回来的图片，改为图片服务上传
                //调用站点上传服务
                urlResult = UploadImageBySiteService(bytes);


                State = "SUCCESS";
            }
            catch (Exception e)
            {
                State = "抓取错误：" + e.Message;
            }

            this.ServerUrl = urlResult[1];
            this.WcfSourceUrl = urlResult[0];

            return this;
        }
    }

    private List<string> UploadImageBySiteService(byte[] imgData)
    {
        string uploadConfigName = Config.GetString("imageUploadConfigName");
        string uploadConfigSize = Config.GetString("imageUploadConfigSize");

        List<string> abbreviationsConfig = new List<string>();
        abbreviationsConfig.Add(uploadConfigSize);

        List<string> result = UploadServiceClass.UploadImg(imgData, uploadConfigName, abbreviationsConfig, "jpg");

        return result;
    }

    private bool IsExternalIPAddress(string url)
    {
        var uri = new Uri(url);
        switch (uri.HostNameType)
        {
            case UriHostNameType.Dns:
                var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                foreach (IPAddress ipAddress in ipHostEntry.AddressList)
                {
                    byte[] ipBytes = ipAddress.GetAddressBytes();
                    if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        if (!IsPrivateIP(ipAddress))
                        {
                            return true;
                        }
                    }
                }
                break;

            case UriHostNameType.IPv4:
                return !IsPrivateIP(IPAddress.Parse(uri.DnsSafeHost));
        }
        return false;
    }

    private bool IsPrivateIP(IPAddress myIPAddress)
    {
        if (IPAddress.IsLoopback(myIPAddress)) return true;
        if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            byte[] ipBytes = myIPAddress.GetAddressBytes();
            // 10.0.0.0/24 
            if (ipBytes[0] == 10)
            {
                return true;
            }
            // 172.16.0.0/16
            else if (ipBytes[0] == 172 && ipBytes[1] == 16)
            {
                return true;
            }
            // 192.168.0.0/16
            else if (ipBytes[0] == 192 && ipBytes[1] == 168)
            {
                return true;
            }
            // 169.254.0.0/16
            else if (ipBytes[0] == 169 && ipBytes[1] == 254)
            {
                return true;
            }
        }
        return false;
    }
}