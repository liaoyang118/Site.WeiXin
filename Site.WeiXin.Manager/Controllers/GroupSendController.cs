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
using Site.WeiXin.Manager.Filder;

namespace Site.WeiXin.Manager.Controllers
{
    [Permission]
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
                where = string.Format(" and t2.MaterialName like '{0}' ", HttpUtility.UrlDecode(key));
            }

            IList<GroupSend> list = GroupSendService.SelectPageExcuteSql("t1.*,t2.MaterialName,t3.TagName", "t1.CreateTime DESC", "left join [Material] t2 on t1.Media_Id=t2.Media_id left join UserTag as t3 on t3.TagId=t1.TagId where t1.AppId='" + HttpContextUntity.CurrentUser.AppID + "'" + where, pageIndex, pageSize, out rowCount);


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
            string selectIds = Request["selectIds"] ?? string.Empty;//接收群体ids,openid可以多个，tagid只有一个
            string materialId = Request["materialId"] ?? string.Empty;//素材id
            string text = Request["txt_content"] ?? string.Empty;//文本

            GroupSend info = new GroupSend();
            info.CreateTime = DateTime.Now;
            info.CreateUserAccount = HttpContextUntity.CurrentUser.Account;
            info.IsToAll = IsToAll;
            info.MessageType = type;
            info.SendName = name;
            info.SendType = channel;
            info.AppId = HttpContextUntity.CurrentUser.AppID;

            string contentBody = string.Empty;
            string groupFormat = string.Empty;
            if (channel == "openid")
            {
                IList<string> openIds = UserService.Select(string.Format(" where Id in ({0})", selectIds)).Select(u => { return string.Format("\"{0}\"", u.OpenID); }).ToList();
                groupFormat = string.Format(WeiXinCommon.OpenIdGroupFormat, string.Join(",", openIds));
            }
            else if (channel == "tag")
            {
                groupFormat = string.Format(WeiXinCommon.TagIdGroupFormat, IsToAll.ToString(), selectIds);
                info.TagId = selectIds;
            }

            Material mInfo = MaterialService.SelectObject(materialId.ToInt32(0));
            int clientMsgId = UntityTool.GetTimeStamp();
            switch (type)
            {
                case "mpnews":
                    contentBody = string.Format(WeiXinCommon.GroupSendNewsFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "text":
                    contentBody = string.Format(WeiXinCommon.GroupSendTextFormat, groupFormat, text, clientMsgId);
                    break;
                case "voice":
                    contentBody = string.Format(WeiXinCommon.GroupSendVoiceFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "image":
                    contentBody = string.Format(WeiXinCommon.GroupSendImageFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "mpvideo": //TODO:视频群发特殊处理
                    contentBody = string.Format(WeiXinCommon.GroupSendVideoFormat, groupFormat, "", clientMsgId);
                    break;
                case "wxcard": //TODO:卡券群发特殊处理
                    contentBody = string.Format(WeiXinCommon.GroupSendCardFormat, groupFormat, "", clientMsgId);
                    break;
            }

            int result = 0;
            string msg_id, msg_data_id;
            bool isSuccess = WeiXinCommon.GroupSendMessage(channel, type, contentBody, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret, out msg_id, out msg_data_id);
            if (isSuccess)
            {

                info.Media_Id = mInfo.Media_id;
                info.Msg_data_id = msg_data_id;
                info.Msg_id = msg_id;
                info.SendStatu = (int)SiteEnum.GroupSendState.成功;

                result = GroupSendService.Insert(info);
            }


            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "新增成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "新增失败"));
            }
        }

        public ActionResult GroupSendPreviewEdit()
        {
            string name = Request["SendName"] ?? string.Empty;//群发名称
            bool IsToAll = Request["IsToAll"].ToBool(false);//是否记录客户端历史记录

            //mpnews、text、voice、image、mpvideo、wxcard
            string type = Request["MessageType"] ?? string.Empty;//消息类型 图文，图片，文本... 【注意此处类型和素材类型不同】
            string channel = Request["channel"] ?? string.Empty;//群发类型 openid、tag
            string selectIds = Request["selectIds"] ?? string.Empty;//接收群体ids,openid可以多个，tagid只有一个
            string materialId = Request["materialId"] ?? string.Empty;//素材id
            string text = Request["txt_content"] ?? string.Empty;//文本

            GroupSend info = new GroupSend();
            info.CreateTime = DateTime.Now;
            info.CreateUserAccount = HttpContextUntity.CurrentUser.Account;
            info.IsToAll = IsToAll;
            info.MessageType = type;
            info.SendName = name;
            info.SendType = channel;

            string contentBody = string.Empty;
            string groupFormat = string.Empty;
            if (channel == "openid")
            {
                User uInfo = UserService.Select(string.Format(" where Id = {0}", selectIds)).FirstOrDefault();
                groupFormat = string.Format(WeiXinCommon.OpenIdGroupPreviewFormat, uInfo.OpenID);
            }
            Material mInfo = MaterialService.SelectObject(materialId.ToInt32(0));
            int clientMsgId = UntityTool.GetTimeStamp();
            switch (type)
            {
                case "mpnews":
                    contentBody = string.Format(WeiXinCommon.GroupSendNewsPreviewFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "text":
                    contentBody = string.Format(WeiXinCommon.GroupSendTextFormat, groupFormat, text, clientMsgId);
                    break;
                case "voice":
                    contentBody = string.Format(WeiXinCommon.GroupSendVoiceFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "image":
                    contentBody = string.Format(WeiXinCommon.GroupSendImageFormat, groupFormat, mInfo.Media_id, clientMsgId);
                    break;
                case "mpvideo": //TODO:视频群发特殊处理
                    contentBody = string.Format(WeiXinCommon.GroupSendVideoFormat, groupFormat, "", clientMsgId);
                    break;
                case "wxcard": //TODO:卡券群发特殊处理
                    contentBody = string.Format(WeiXinCommon.GroupSendCardFormat, groupFormat, "", clientMsgId);
                    break;
            }

            string msg_id, msg_data_id;
            bool isSuccess = WeiXinCommon.GroupSendMessage(channel, type, contentBody, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret, out msg_id, out msg_data_id, true);

            //预览记录不记入数据库
            //if (isSuccess)
            //{

            //    info.Media_Id = mInfo.Media_id;
            //    info.Msg_data_id = msg_data_id;
            //    info.Msg_id = msg_id;
            //    info.SendStatu = (int)SiteEnum.GroupSendState.成功;

            //    result = GroupSendService.Insert(info);
            //}


            if (isSuccess)
            {
                return Json(UntityTool.JsonResult(true, "预览发送成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "预览发送失败"));
            }
        }


        public ActionResult GroupSendDelete(int id, string msg_id, int index)
        {
            bool isSuccess = WeiXinCommon.DeleteGroupSend(msg_id, index, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret);
            int result = 0;
            if (isSuccess)
            {
                result = GroupSendService.Delete(id);
            }
            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "删除失败"));
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
                search.AppID = HttpContextUntity.CurrentUser.AppID;
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
                search.AppID = HttpContextUntity.CurrentUser.AppID;
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

            MaterialSearchInfo search = new MaterialSearchInfo();
            search.MaterialName = HttpUtility.UrlDecode(key);
            search.AppID = HttpContextUntity.CurrentUser.AppID;
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