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
using System.Web;

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
                      </Image>
                  </xml>";
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
                        <Voice><MediaId><![CDATA[{3}]]></MediaId></Voice></xml>";
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
        /// 回复音乐信息格式 {0},openId,{1}公众号 微信号，{2}时间戳，{3}Title，{4},Description,{5}MusicUrl，{6}高音质音乐链接，{7}ThumbMediaId 缩略图ID
        /// </summary>
        public static string MusicFormat
        {
            get
            {
                return @"<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[music]]></MsgType>
                        <Music>
                        <Title><![CDATA[{3}]]></Title>
                        <Description><![CDATA[{4}]]></Description>
                        <MusicUrl><![CDATA[{5}]]></MusicUrl>
                        <HQMusicUrl><![CDATA[{6}]]></HQMusicUrl>
                        <ThumbMediaId><![CDATA[{7}]]></ThumbMediaId>
                        </Music>
                        </xml>";
            }
        }

        /// <summary>
        /// 回复图文信息格式，{0},openId,{1}公众号 微信号，{2}时间戳，{3}图文条数，限制为8条以内{4}单条图文信息格式
        /// </summary>
        public static string BatchImageContentReplyFormat
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
        public static string SignImageContentReplyFormat
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

        #region 群发消息格式

        /// <summary>
        /// 图文 {0}：OpenIdGroupFormat/TagIdGroupFormat，{1}：media_id,{2}clientmsgid 
        /// </summary>
        public static string GroupSendNewsFormat
        {
            get
            {
                return "{{{0},\"mpnews\":{{\"media_id\":\"{1}\"}},\"msgtype\":\"mpnews\"，\"send_ignore_reprint\":0,\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 文本 {0}：OpenIdGroupFormat/TagIdGroupFormat，{1}：content,{2}clientmsgid 
        /// </summary>
        public static string GroupSendTextFormat
        {
            get
            {
                return "{{{0},\"text\":{{\"content\":\"{1}\"}},\"msgtype\":\"text\",\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 语音 {0}：OpenIdGroupFormat/TagIdGroupFormat，{1}：media_id,{2}clientmsgid 
        /// </summary>
        public static string GroupSendVoiceFormat
        {
            get
            {
                return "{{{0},\"voice\":{{\"media_id\":\"{1}\"}},\"msgtype\":\"voice\",\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 图片 {0}：OpenIdGroupFormat/TagIdGroupFormat，{1}：media_id,{2}clientmsgid 
        /// </summary>
        public static string GroupSendImageFormat
        {
            get
            {
                return "{{{0},\"image\":{{\"media_id\":\"{1}\"}},\"msgtype\":\"image\",\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 卡券 {0}：OpenIdGroupFormat/TagIdGroupFormat，{1}：card_id,{2}clientmsgid 
        /// </summary>
        public static string GroupSendCardFormat
        {
            get
            {
                return "{{{0},\"wxcard\":{{\"card_id\":\"{1}\"}},\"msgtype\":\"wxcard\",\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 视频 
        /// {0}：OpenIdGroupFormat/TagIdGroupFormat，
        /// {1}：media_id 此处的media_id，不是上传视频获取的media_id，是需要额外在请求一次返回新的media_id
        /// {2}clientmsgid 
        /// </summary>
        public static string GroupSendVideoFormat
        {
            get
            {
                return "{{{0},\"mpvideo\":{{\"media_id\":\"{1}\"}},\"msgtype\":\"mpvideo\",\"clientmsgid\":\"{2}\"}}";
            }
        }

        /// <summary>
        /// 群发消息删除 {0}msg_id,{1}article_idx
        /// </summary>
        public static string GroupSendDeleteFormat
        {
            get
            {
                return "{{\"msg_id\":{0},\"article_idx\":{1}}}";
            }
        }

        #region 标签组成

        /// <summary>
        /// 按TagId 群发，{0}：is_to_all，{1}：tag_id
        /// </summary>
        public static string TagIdGroupFormat
        {
            get
            {
                return "\"filter\":{{\"is_to_all\":{0},\"tag_id\":{1}}}";
            }
        }


        #endregion

        #region openid组成

        /// <summary>
        /// 按openId群发消息，{0}："OPENID1","OPENID2"
        /// </summary>
        public static string OpenIdGroupFormat
        {
            get
            {
                return "\"touser\":[{0}]";
            }
        }




        #endregion

        #endregion

        #region 群发消息 预览格式

        /// <summary>
        /// 图文 {0}：OpenIdGroupPreviewFormat，{1}：media_id
        /// </summary>
        public static string GroupSendNewsPreviewFormat
        {
            get
            {
                return "{{{0},\"mpnews\":{{\"media_id\":\"{1}\"}},\"msgtype\":\"mpnews\"}}";
            }
        }

        //其它项目和正式群发一致


        #region 预览组成

        /// <summary>
        /// 按OpenId 群发，{0}：openid
        /// </summary>
        public static string OpenIdGroupPreviewFormat
        {
            get
            {
                return "\"touser\":\"{0}\"";
            }
        }

        /// <summary>
        /// 按微信名 群发
        /// </summary>
        public static string WxNameGroupPreviewFormat
        {
            get
            {
                return "\"towxname\":\"{0}\"";
            }
        }


        #endregion

        #endregion

        #region 图文素材格式

        /// <summary>
        /// 单个图文素材格式
        /// title,thumb_media_id,author,digest,show_cover_pic,content,content_source_url
        /// </summary>
        public static string ImageContentFormat
        {
            get
            {
                return "{{" +
                    "\"title\": \"{0}\"," +
                    "\"thumb_media_id\": \"{1}\"," +
                    "\"author\": \"{2}\"," +
                    "\"digest\": \"{3}\"," +
                    "\"show_cover_pic\": {4}," +
                    "\"content\": \"{5}\"," +
                    "\"content_source_url\":\"{6}\"}}";
            }
        }

        /// <summary>
        /// 新增图文素材参数格式
        /// ImageContentFormat 逗号隔开
        /// </summary>
        public static string ImageContentListFormat
        {
            get
            {
                return "{{\"articles\": [{0}]}}";
            }
        }

        /// <summary>
        /// 更新图文素材 参数格式 media_id,index,ImageContentFormat
        /// </summary>
        public static string UpdateImageContentFormat
        {
            get
            {
                return "{{\"media_id\":\"{0}\", \"index\":{1},\"articles\": {{{2}}}}}";
            }
        }

        /// <summary>
        /// 新增标签 参数格式
        /// </summary>
        public static string MarkFormat
        {
            get
            {
                return "{{\"tag\":{{\"name\" : \"{0}\"}}}}";
            }
        }
        /// <summary>
        /// 删除标签 参数格式
        /// </summary>
        public static string MarkDeleteFormat
        {
            get
            {
                return "{{\"tag\":{{\"id\" : \"{0}\"}}}}";
            }
        }

        /// <summary>
        /// 修改标签 参数格式 id,name
        /// </summary>
        public static string MarkEditFormat
        {
            get
            {
                return "{{\"tag\":{{\"id\" : \"{0}\",\"name\" : \"{1}\"}}}}";
            }
        }

        /// <summary>
        /// 批量为用户打标签 openid,tagid
        /// </summary>
        public static string BatchMarkFormat
        {
            get
            {
                return "{{\"openid_list\":[{0}],\"tagid\":{1}}}";
            }
        }


        #endregion

        #region 参数生成

        /// <summary>
        /// 生成菜单 参数格式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GenerateButton(List<Menu> list)
        {
            string result = string.Empty;
            string btnFormat = "{\"button\":[**]}";
            string btnArr = GetString(list, "");
            result = btnFormat.Replace("**", btnArr);
            return result;
        }

        /// <summary>
        /// 生成新增多图文素材 参数格式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GenerateImageContentBody(IList<Article> list)
        {
            string result = string.Empty;
            try
            {
                List<string> items = new List<string>();
                string articleStr = string.Empty;
                foreach (Article item in list)
                {
                    articleStr = string.Format(ImageContentFormat,
                                                        item.Title,
                                                        item.MediaId,
                                                        item.AuthorName,
                                                        item.Intro,
                                                        item.ShowCover,
                                                        item.ArticleContent.Replace("\"", "'"), 
                                                        item.ContentSourceUrl);
                    items.Add(articleStr);
                }
                result = string.Format(ImageContentListFormat, string.Join(",", items));
                
            }
            catch (Exception ex)
            {
                LogHelp.Error("组装图文素材参数主体信息错误:" + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 生成 更新多图文素材 参数格式
        /// </summary>
        /// <param name="info"></param>
        /// <param name="media_id"></param>
        /// <param name="index">需要更新多图文素材中的素材的索引，从0开始</param>
        /// <returns></returns>
        public static string GenerateUpdateImageContentBody(Article info, string media_id, int index)
        {
            string result = string.Empty;
            try
            {
                List<string> items = new List<string>();
                string articleStr = string.Empty;

                articleStr = string.Format(ImageContentFormat,
                                                    info.Title,
                                                    info.MediaId,
                                                    info.AuthorName,
                                                    info.Intro,
                                                    info.ShowCover,
                                                    info.ArticleContent.Replace("\"", "'"),
                                                    info.ContentSourceUrl);

                result = string.Format(UpdateImageContentFormat, media_id, index, articleStr);
            }
            catch (Exception ex)
            {
                LogHelp.Error("组装图文素材参数主体信息错误:" + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 生成 批量给用户打标签 参数格式
        /// </summary>
        /// <param name="openIds"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static string GenerateBatchMarkBody(List<string> openIds, string tagId)
        {
            string ids = string.Join(",", openIds.Select(u => { return string.Format("\"{0}\"", u); }).ToList());
            return string.Format(BatchMarkFormat, ids, tagId);
        }

        #endregion

        #region 用户信息、菜单

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
                        try
                        {
                            int errorCode = int.Parse(token.ToString());
                            result = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                        }
                        catch
                        {
                            result = token.ToString();
                        }

                        return false;
                    }
                }
            }
            return false;
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

        public static bool GetAccessToken(out string result)
        {
            result = string.Empty;
            try
            {
                IList<GloblaToken> list = GloblaTokenService.Select(string.Format(" where AppId='{0}'", UntityTool.GetConfigValue("appID"), DateTime.Now));
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
                            //跟新access_token
                            info.Token = result;
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
                            obj.TryGetValue("errcode", out token);

                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("获取用户信息错误:" + error);
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
        #endregion

        #region 素材管理

        /// <summary>
        /// 新增临时素材
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="type">素材类型：image、voice、video、thumb</param>
        /// <returns></returns>
        public static bool AddTempMaterial(string type, byte[] bytes, string fileName, out string media_id)
        {
            media_id = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", access_token, type);
                    string content = HttpTool.Post(url, fileName, bytes);
                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("media_id", out token);
                        if (token != null)
                        {
                            //反序列化
                            media_id = token.ToString();
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errcode", out token);

                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增临时素材错误:" + error);

                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增临时素材错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 新增永久素材
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="bytes"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static bool AddPermanentMaterial(string type, byte[] bytes, string fileName, out string media_id)
        {
            media_id = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}", access_token, type);
                    string content = HttpTool.Post(url, fileName, bytes);
                    //TODO:上传视频素材时需要POST另一个表单

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("media_id", out token);
                        if (token != null)
                        {
                            //反序列化
                            media_id = token.ToString();
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errcode", out token);
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增永久素材错误:" + error);

                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增永久素材错误:" + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="body">图文素材组装好的body内容</param>
        /// <returns></returns>
        public static bool AddPermanentMaterial(string body, out string media_id)
        {
            media_id = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}", access_token);
                    string content = HttpTool.Post(url, body);

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("media_id", out token);
                        if (token != null)
                        {
                            //反序列化
                            media_id = token.ToString();
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errcode", out token);
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增永久图文素材错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增永久图文素材错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新永久图文素材中的内容，一次只更新一篇内容，多图文消息时，需要指定更新图文消息的index
        /// </summary>
        /// <param name="body">更新图文素材组装好的body内容</param>
        /// <returns></returns>
        public static bool EditPermanentMaterial(string body)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}", access_token);
                    string content = HttpTool.Post(url, body);

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("更新永久图文素材中的内容错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("更新永久图文素材中的内容错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 新增图文信息中的图片，返回图片地址
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static bool AddArticalImage(byte[] bytes, string fileName, out string imageUrl)
        {
            imageUrl = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}", access_token);
                    string content = HttpTool.Post(url, fileName, bytes);
                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("url", out token);
                        if (token != null)
                        {
                            //反序列化
                            imageUrl = token.ToString();
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errcode", out token);
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增图文信息中的图片错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增图文信息中的图片错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除永久素材
        /// </summary>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static bool DeletePermanentMaterial(string media_id)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}", access_token);
                    string content = HttpTool.Post(url, "{\"media_id\":\"" + media_id + "\"}");
                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("删除永久素材错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("删除永久素材错误:" + ex.Message);
                return false;
            }
        }


        #endregion

        #region 网页授权

        /// <summary>
        /// 通过code换取网页授权access_token,该access_token与基础支持中的access_token不同，该access_token只用在网页授权获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="openid"></param>
        /// <param name="access_token"></param>
        /// <param name="scope">授权的作用域</param>
        /// <returns></returns>
        public static bool GetIdentityAccessToken(string code, out string openid, out string access_token, out string scope)
        {
            openid = string.Empty;
            access_token = string.Empty;
            scope = string.Empty;
            try
            {
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code ", UntityTool.GetConfigValue("appID"), UntityTool.GetConfigValue("appsecret"), code);
                string content = HttpTool.Get(url);
                if (!string.IsNullOrEmpty(content))
                {
                    JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                    JToken token;
                    obj.TryGetValue("access_token", out token);
                    if (token != null)
                    {
                        access_token = token.ToString();
                        //openid
                        obj.TryGetValue("openid", out token);
                        openid = token.ToString();
                        //scope
                        obj.TryGetValue("scope", out token);
                        scope = token.ToString();
                        return true;
                    }
                    else
                    {
                        //失败
                        obj.TryGetValue("errcode", out token);

                        string error = string.Empty;
                        try
                        {
                            int errorCode = int.Parse(token.ToString());
                            error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                        }
                        catch
                        {
                            obj.TryGetValue("errmsg", out token);
                            error = token.ToString();
                        }
                        LogHelp.Error("网页授权获取用户access_token、openid错误:" + error);
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("网页授权获取用户access_token、openid错误:" + ex.Message);
                return false;
            }
        }

        public static bool GetIdentityUserInfo(string openid, string access_token, out IdentityUserInfo uInfo)
        {
            uInfo = null;
            try
            {
                string url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", access_token, openid);
                string content = HttpTool.Get(url);
                if (!string.IsNullOrEmpty(content))
                {
                    JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                    JToken token;
                    obj.TryGetValue("openid", out token);
                    if (token != null)
                    {
                        //反序列化用户
                        uInfo = JsonConvert.DeserializeObject<IdentityUserInfo>(content);
                        return true;
                    }
                    else
                    {
                        //失败
                        obj.TryGetValue("errcode", out token);

                        string error = string.Empty;
                        try
                        {
                            int errorCode = int.Parse(token.ToString());
                            error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                        }
                        catch
                        {
                            obj.TryGetValue("errmsg", out token);
                            error = token.ToString();
                        }
                        LogHelp.Error("网页授权获取用户信息错误:" + error);
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("网页授权获取用户信息错误:" + ex.Message);
                return false;
            }
        }


        #endregion

        #region 标签管理
        public static bool AddMark(string markName, out string id)
        {
            id = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/create?access_token={0}", access_token);
                    string content = HttpTool.Post(url, string.Format(MarkFormat, markName));

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("tag", out token);
                        if (token != null)
                        {
                            obj = (JObject)JsonConvert.DeserializeObject(token.ToString());
                            obj.TryGetValue("id", out token);
                            id = token.ToString();
                            return true;
                        }
                        else
                        {
                            //失败
                            obj.TryGetValue("errcode", out token);
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增标签错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增标签错误:" + ex.Message);
                return false;
            }
        }

        public static bool DeleteMark(string markId)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/delete?access_token={0}", access_token);
                    string content = HttpTool.Post(url, string.Format(MarkDeleteFormat, markId));


                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("删除标签错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("删除标签错误:" + ex.Message);
                return false;
            }
        }

        public static bool EditMark(string markId, string markName)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/update?access_token={0}", access_token);
                    string content = HttpTool.Post(url, string.Format(MarkEditFormat, markId, markName));

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("修改标签错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("修改标签错误:" + ex.Message);
                return false;
            }
        }

        #endregion

        #region 分组管理

        /// <summary>
        /// 批量为用户打标签
        /// </summary>
        /// <param name="openIds"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static bool BatchUserMark(List<string> openIds, string tagId)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchtagging?access_token={0}", access_token);
                    string content = HttpTool.Post(url, GenerateBatchMarkBody(openIds, tagId));

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("批量给用户打标签错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("批量给用户打标签错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 批量为用户取消标签
        /// </summary>
        /// <param name="openIds"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static bool DeleteBatchUserMark(List<string> openIds, string tagId)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchuntagging?access_token={0}", access_token);
                    string content = HttpTool.Post(url, GenerateBatchMarkBody(openIds, tagId));

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            return true;
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("新增标签错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("新增标签错误:" + ex.Message);
                return false;
            }
        }

        #endregion

        #region 群发管理

        /// <summary>
        /// 群发消息
        /// </summary>
        /// <param name="channel">群发渠道，openid,tag</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="body">参数体</param>
        /// <param name="msg_id">返回的群发消息Id</param>
        /// <param name="msg_data_id">群发图文时该值才有效</param>
        /// <returns></returns>
        public static bool GroupSendMessage(string channel, string messageType, string body, out string msg_id, out string msg_data_id, bool isPreview = false)
        {
            msg_id = string.Empty;
            msg_data_id = string.Empty;
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string urlFormat = string.Empty;
                    if (channel == "openid")
                    {
                        urlFormat = "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";
                    }
                    else if (channel == "tag")
                    {
                        urlFormat = "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";
                    }
                    //预览
                    if (isPreview)
                    {
                        urlFormat = "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}";
                    }

                    string url = string.Format(urlFormat, access_token);
                    string content = HttpTool.Post(url, body);

                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null && token.ToString() == "0")
                        {
                            bool isSuccessRetrieved = obj.TryGetValue("msg_id", out token);
                            if (isSuccessRetrieved)
                            {
                                msg_id = token.ToString();
                            }

                            if (!isPreview)
                            {
                                //群发图文消息时,msg_data_id,可以用于在图文分析数据接口中，获取到对应的图文消息的数据
                                if (messageType == "mpnews")
                                {
                                    isSuccessRetrieved = obj.TryGetValue("msg_data_id", out token);
                                    if (isSuccessRetrieved)
                                    {
                                        msg_data_id = token.ToString();
                                    }
                                }
                            }
                            return true;

                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("群发消息错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("群发消息错误:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除群发消息
        /// </summary>
        /// <param name="msg_id">提交任务成功后的Id</param>
        /// <param name="article_idx">删除指定第几篇消息，从1开始；不填写或是0，删除全部</param>
        /// <returns></returns>
        public static bool DeleteGroupSend(string msg_id, int article_idx)
        {
            try
            {
                string access_token;
                bool isSuccess = GetAccessToken(out access_token);
                if (isSuccess)
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}", access_token);
                    string content = HttpTool.Post(url, string.Format(GroupSendDeleteFormat, msg_id, article_idx));


                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken token;
                        obj.TryGetValue("errcode", out token);
                        if (token != null)
                        {
                            if (token.ToString() == "0")
                            {
                                return true;
                            }
                        }
                        else
                        {
                            string error = string.Empty;
                            try
                            {
                                int errorCode = int.Parse(token.ToString());
                                error = ((SiteEnum.Access_tokenStatus)errorCode).ToString();
                            }
                            catch
                            {
                                obj.TryGetValue("errmsg", out token);
                                error = token.ToString();
                            }
                            LogHelp.Error("删除群发消息错误:" + error);
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelp.Error("删除群发消息错误:" + ex.Message);
                return false;
            }
        }

        #endregion

        #region 接口处理--入口
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
        #endregion

    }
}
