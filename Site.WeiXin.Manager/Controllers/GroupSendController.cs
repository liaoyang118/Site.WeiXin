using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;
using Site.WeiXin.DataAccess.Service.PartialService.Search;
using Site.WeiXin.Manager.Common;

namespace Site.WeiXin.Manager.Controllers
{
    public class GroupSendController : Controller
    {
        public ActionResult Index(string key, int? page)
        {
            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            string where = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                where = string.Format(" where t2.MaterialName like '{0}' ", HttpUtility.UrlDecode(key));
            }

            IList<GroupSend> list = GroupSendService.SelectPageExcuteSql("t1.*,t2.MaterialName,t3.TagName", "t1.CreateTime DESC", "left join [Material] t2 on t1.Media_Id=t2.Media_id left join UserTag as t3 on t3.TagId=t1.TagId " + where, pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }


        public ActionResult GroupSendAddView(string id)
        {
            GroupSend obj = new GroupSend();

            ViewBag.obj = obj;
            return PartialView();
        }

        public ActionResult GroupSendEdit()
        {
            string name = Request["SendName"] ?? string.Empty;//群发名称
            bool IsToAll = Request["IsToAll"].ToBool(false);//是否记录客户端历史记录

            //mpnews、text、voice、image、mpvideo、wxcard
            string type = Request["MessageType"] ?? string.Empty;//消息类型 图文，图片，文本... 【注意此处类型和素材类型不同】
            string channel = Request["channel"] ?? string.Empty;//群发类型 openid、tag
            string selectIds = Request["selectIds"] ?? string.Empty;//接收群体ids
            string imageContentIds = Request["imageContentIds"] ?? string.Empty;//素材ids
            string text = Request["txt_content"] ?? string.Empty;//文本

            int result = 0;


            GroupSend info = new GroupSend();

            info.CreateTime = DateTime.Now;
            info.CreateUserAccount = HttpContextUntity.CurrentUser.Account;
            info.IsToAll = IsToAll;
            info.MessageType = type;
            info.SendName = name;
            info.SendType = channel;

            string contentFormat = string.Empty;
            if (channel == "openid")
            {
                //图文
                if (type == "mpnews")
                {
                    StringBuilder sb = new StringBuilder();
                    IList<Article> list = ArticleService.Select(string.Format(" where Id in ({0})", imageContentIds));
                    foreach (Article item in list)
                    {
                        sb.AppendFormat(WeiXinCommon.SignImageContentReplyFormat, item.Title, item.Intro, item.CoverSrc, item.ContentSourceUrl);
                    }

                    contentFormat = WeiXinCommon.BatchImageContentReplyFormat.Replace("{3}", list.Count.ToString())
                                                                             .Replace("{4}", sb.ToString());
                }
            }
            else if(channel == "tag")
            {

            }
            ////图文
            //if (type == "mpnews")
            //{
            //    StringBuilder sb = new StringBuilder();
            //    IList<Article> list = ArticleService.Select(string.Format(" where Id in ({0})", imageContentIds));
            //    foreach (Article item in list)
            //    {
            //        sb.AppendFormat(WeiXinCommon.SignImageContentReplyFormat, item.Title, item.Intro, item.CoverSrc, item.ContentSourceUrl);
            //    }

            //    contentFormat = WeiXinCommon.BatchImageContentReplyFormat.Replace("{3}", list.Count.ToString())
            //                                                             .Replace("{4}", sb.ToString());
            //}
            //else
            //{
            //    if (type == "text")
            //    {
            //        contentFormat = WeiXinCommon.TextFormat.Replace("{3}", text);
            //    }
            //    else
            //    {
            //        Material mInfo = MaterialService.SelectObject(int.Parse(imageContentIds));
            //        switch (type)
            //        {
            //            case "image":
            //                contentFormat = WeiXinCommon.ImageFormat.Replace("{3}", mInfo.Media_id);
            //                break;
            //            case "voice":
            //                contentFormat = WeiXinCommon.VoiceFormat.Replace("{3}", mInfo.Media_id);
            //                break;
            //            case "video":
            //                contentFormat = WeiXinCommon.VideoFormat.Replace("{3}", mInfo.Media_id);
            //                break;
            //            case "music":
            //                contentFormat = WeiXinCommon.MusicFormat.Replace("{3}", mInfo.MaterialName)
            //                                                        .Replace("{4}", mInfo.Intro)
            //                                                        .Replace("{5}", mInfo.Url)
            //                                                        .Replace("{6}", "")
            //                                                        .Replace("{7}", mInfo.Media_id);
            //                break;
            //        }
            //    }
            //}


            result = GroupSendService.Insert(info);
            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "新增成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "新增失败"));
            }
        }

        public ActionResult GroupSendSelectListView(string key, string channel, string type, int? page)
        {
            int rowCount;
            int pageIndex = Request["pageIndex"].ToInt32(1);
            int pageSize = Request["pageSize"].ToInt32(15);

            //用户列表
            if (channel == "openid")
            {
                UserSearchInfo search = new UserSearchInfo();
                search.NickName = HttpUtility.UrlDecode(key);
                search.IsSubscribe = true;

                

                IList<User> list = UserService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


                ViewBag.list = list;
                ViewBag.nickName = HttpUtility.UrlDecode(key);

                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;

                return PartialView("UserListView");
            }
            else //标签列表
            {
                UserTagSearchInfo search = new UserTagSearchInfo();
                search.TagName = HttpUtility.UrlDecode(key);

                IList<UserTag> list = UserTagService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);
                
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;


                ViewBag.list = list;
                return PartialView("TagListView");
            }
        }

        public ActionResult GroupSendMaterialSearch(string key, string type, int? page)
        {
            //图文
            if (type == "imageContent")
            {
                ArticleSearchInfo search = new ArticleSearchInfo();
                search.Title = HttpUtility.UrlDecode(key);
                search.Statu = (int)SiteEnum.ArticleState.通过;

                int pageSize = 15;
                int rowCount;
                int pageIndex = page == null ? 1 : page.Value;
                IList<Article> list = ArticleService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;

                ViewBag.list = list;
                return PartialView("GroupSendArticleContent");
            }
            else
            {
                MaterialSearchInfo search = new MaterialSearchInfo();
                search.MaterialName = HttpUtility.UrlDecode(key);
                search.MaterialType = type;

                int pageSize = 20;
                int rowCount;
                int pageIndex = page == null ? 1 : page.Value;
                IList<Material> list = MaterialService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);



                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;

                ViewBag.list = list;
                return PartialView("GroupSendMaterialContent");
            }
        }
    }
}