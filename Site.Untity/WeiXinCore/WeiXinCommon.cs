using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.WeiXin.DataAccess.Model;
using System.Xml;
using System.Xml.Serialization;
using Site.Untity.WeiXinCore.Handle;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Site.Untity
{
    public class WeiXinCommon
    {
        public static string GenerateButton(List<Menu> list)
        {
            string result = string.Empty;
            string btnFormat = "{\"button\":[**]}";
            string btnArr = GetString(list, "");
            result = btnFormat.Replace("**", btnArr);
            return result;
        }

        private static string GetString(List<Menu> list, string subBtn)
        {
            string btnALL = "";
            string btn = "";
            List<Menu> subList = new List<Menu>();
            foreach (Menu item in list)
            {
                //避免重复菜单出现
                if (list.Where(t => t.Id == item.ParentId).ToList().Count > 0 && item.ParentId != 1)//ID 为1的，为顶级根元素
                {
                    continue;
                }
                subList = list.Where(t => t.ParentId == item.Id).ToList();
                if (subList.Count > 0)
                {
                    btn = "{\"name\":\"" + item.Name.Replace("&nbsp;", "") + "\",\"sub_button\":[**]}";//**占位
                    //递归调用
                    btn = GetString(subList, btn);
                }
                else
                {
                    if (item.Type == "click" || item.Type == "scancode_push" || item.Type == "scancode_waitmsg" || item.Type == "pic_sysphoto" || item.Type == "pic_photo_or_album" || item.Type == "pic_weixin" || item.Type == "location_select")
                    {
                        btn = "{\"type\":\"" + item.Type + "\",\"name\":\"" + item.Name.Replace("&nbsp;", "") + "\", \"key\":\"" + item.Value + "\"}";
                    }
                    else if (item.Type == "view")
                    {
                        btn = "{\"type\":\"view\",\"name\":\"" + item.Name.Replace("&nbsp;", "") + "\", \"url\":\"" + item.Value + "\"}";
                    }
                    else if (item.Type == "media_id" || item.Type == "view_limited")
                    {
                        btn = "{\"type\":\"view\",\"name\":\"" + item.Name.Replace("&nbsp;", "") + "\", \"media_id\":\"" + item.Value + "\"}";
                    }
                }
                if (!string.IsNullOrEmpty(btnALL))
                {
                    btnALL += ",";
                }
                btnALL += btn;
            }
            if (string.IsNullOrEmpty(subBtn))
            {
                return btnALL;
            }
            else
            {
                return subBtn.Replace("**", btnALL);
            }
        }

        public static string HandelRequest(string xmlContent)
        {
            string result = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlContent);
            HandleBase baseHandle = null;
            string type = doc.GetElementsByTagName("MsgType")[0].InnerText;
            switch (type)
            {
                case "text"://文本消息
                    baseHandle = new TextMessageHandle();
                    break;
                case "image"://图片消息
                    break;
                case "voice"://语音消息
                    break;
                case "video"://视频消息
                    break;
                case "shortvideo"://小视频消息
                    break;
                case "location"://地理位置消息
                    break;
                case "link"://链接消息
                    break;
                default:
                    baseHandle = new TextMessageHandle();
                    break;
            }

            result = baseHandle.Handle(xmlContent);
            return result;
        }

        public static bool GetHttpToken(out string result)
        {
            result = string.Empty;
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", UntityTool.GetConfigValue("appID"), UntityTool.GetConfigValue("appsecret"));
            string content = HttpTool.Get(url);
            if (!string.IsNullOrEmpty(content))
            {
                JObject obj = (JObject)JsonConvert.DeserializeObject(content);
                JToken token;
                obj.TryGetValue("access_token", out token);
                if (token != null)
                {
                    //成功
                    result = token.ToString();
                    return true;
                }
                else
                {
                    //失败
                    obj.TryGetValue("errcode", out token);
                    int errorCode = int.Parse(token.ToString());
                    result = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                    return false;
                }
            }
            return false;
        }

        public static bool PostBtn(string access_token, string btnParams, out string result)
        {
            result = string.Empty;
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_token);
            string content = HttpTool.Post(url, btnParams);
            if (!string.IsNullOrEmpty(content))
            {
                JObject obj = (JObject)JsonConvert.DeserializeObject(content);
                JToken token;
                obj.TryGetValue("errcode", out token);
                if (token != null)
                {
                    //成功
                    if (int.Parse(token.ToString()) == 0)
                    {
                        result = "发布成功";
                        return true;
                    }
                    else
                    {
                        obj.TryGetValue("errmsg", out token);
                        result = token.ToString();
                        return false;
                    }
                }
            }
            return false;
        }

    }
}
