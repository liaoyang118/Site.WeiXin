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
using Site.WeiXin.DataAccess.Service;
using Site.Log;

namespace Site.Untity
{
    public class WeiXinCommon
    {
        #region 回复消息格式

        /// <summary>
        /// 回复文本信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}文本内容
        /// </summary>
        public static string TextFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[text]]></MsgType>
                        <Content><![CDATA[{3}]]></Content></xml>";
            }
        }

        /// <summary>
        /// 回复图片信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}MediaId
        /// </summary>
        public static string ImageFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[image]]></MsgType>
                        <Image>
                        <MediaId><![CDATA[{3}]]></MediaId>
                        </Image></xml>";
            }
        }


        /// <summary>
        /// 回复语音信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}MediaId
        /// </summary>
        public static string VoiceFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[voice]]></MsgType>
                        <Image>
                        <MediaId><![CDATA[{3}]]></MediaId>
                        </Image></xml>";
            }
        }

        /// <summary>
        /// 回复视频信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}MediaId
        /// </summary>
        public static string VideoFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[video]]></MsgType>
                        <Image>
                        <MediaId><![CDATA[{3}]]></MediaId>
                        </Image></xml>";
            }
        }

        /// <summary>
        /// 回复图文信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}图文条数，限制为8条以内{4}单条图文信息格式
        /// </summary>
        public static string ImageTextFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[news]]></MsgType>
                        <ArticleCount>{3}</ArticleCount>
                        <Articles>{4}</Articles>
                        </xml>";
            }
        }

        /// <summary>
        /// 图文信息,单条图文格式，{0}标题,{1}描述，{2}图片链接，较好的效果为大图360*200，小图200*200，{3}图文消息跳转链接
        /// </summary>
        public static string ItemFormat
        {
            get
            {
                return @"<item>
                         <Title><![CDATA[{0}]]></Title> 
                         <Description><![CDATA[{1}]]></Description>
                         <PicUrl><![CDATA[{2}]]></PicUrl>
                         <Url><![CDATA[{3}]]></Url>
                         </item>";
            }
        }





        /// <summary>
        /// 回复成功消息
        /// </summary>

        public static string Success
        {
            get
            {
                return "";
            }
        }

        #endregion


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
                //消息
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
                //事件
                case "event":
                    string eventName = doc.GetElementsByTagName("Event")[0].InnerText;
                    switch (eventName)
                    {
                        case "subscribe":
                            baseHandle = new SubscribeEvent();
                            break;
                        case "unsubscribe":
                            baseHandle = new UnSubscribeEvent();
                            break;
                        case "SCAN"://关注用户扫二维码
                            baseHandle = new ScanEvent();
                            break;
                        case "LOCATION":
                            baseHandle = new LocationEvent();
                            break;
                        case "CLICK":
                            baseHandle = new ClickEvent();
                            break;
                        case "VIEW":
                            baseHandle = new ViewEvent();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    baseHandle = new TextMessageHandle();
                    break;
            }

            result = baseHandle.Handle(xmlContent);
            return result;
        }

        private static bool GetHttpToken(out string result)
        {
            result = string.Empty;
            try
            {
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
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return false;
            }
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

        public static bool GetAccessToken(out string result)
        {
            result = string.Empty;
            try
            {
                IList<GloblaToken> list = GloblaTokenService.Select(string.Format(" and AppId='{0}'", UntityTool.GetConfigValue("appID"), DateTime.Now));
                bool isSuccess = false;
                if (list.Count > 0)
                {
                    GloblaToken info = list.FirstOrDefault();
                    if (info.ExpireTime > DateTime.Now)
                    {
                        result = info.Token;
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = GetHttpToken(out result);
                        if (isSuccess)
                        {
                            //更新时间
                            info.ExpireTime = DateTime.Now.AddHours(2);
                            GloblaTokenService.Update(info);
                        }
                    }
                }
                else
                {
                    //获取新的access_token
                    isSuccess = GetHttpToken(out result);
                    if (isSuccess)
                    {
                        //插入
                        GloblaTokenService.Insert(new GloblaToken()
                        {
                            AppId = UntityTool.GetConfigValue("appID"),
                            ExpireTime = DateTime.Now.AddHours(2),
                            Token = result
                        });
                    }
                }
                LogHelp.Error("获取acess_token成功：" + result);
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelp.Error("获取acess_token错误：" + ex.Message);
                return false;
            }
        }

        public static bool GetUserInfo(string openid, out UserInfo uInfo)
        {
            uInfo = null;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", access_token, openid);
                    string content = HttpTool.Get(url);
                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("openid", out token);
                        if (token != null)
                        {
                            //反序列化用户
                            uInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errmsg", out token);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("获取用户信息错误:" + ex.Message);
                return false;
            }
        }

    }
}
