﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class FansController : Controller
    {
        #region 01 粉丝列表
        public ActionResult UserList(string key, int? page)
        {
            UserSearchInfo search = new UserSearchInfo();
            search.NickName = HttpUtility.UrlDecode(key);
            search.AppID = HttpContextUntity.CurrentUser.AppID;

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<User> list = UserService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.nickName = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }


        public ActionResult DownloadUser()
        {
            List<string> ids = new List<string>();

            List<string> openIdList = new List<string>();
            string next_openid = string.Empty;
            int total = 0;//总数
            int getTotal = 0;//已经获取的总数
            bool isSuccess = true;
            int count = 0;
            do
            {
                isSuccess = WeiXinCommon.GetUserList(next_openid, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret, out openIdList, out total, out count, out next_openid);
                if (isSuccess)
                {
                    ids.AddRange(openIdList);
                }
                getTotal += count;
            } while (!string.IsNullOrEmpty(next_openid) && total > getTotal);

            int result = 0;
            isSuccess = false;
            UserInfo wInfo;
            User info = null;
            foreach (string openId in ids)
            {
                isSuccess = WeiXinCommon.GetUserInfo(openId, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret, out wInfo);
                if (isSuccess)
                {
                    info = new User();
                    info.OpenID = openId;
                    info.Subscribe_Time = DateTime.Now;
                    info.IsSubscribe = true;
                    info.UnSubscribe_Time = DateTime.Now;
                    info.Subscribe_Time = UntityTool.TimespanToDatetime(wInfo.subscribe_time);

                    info.City = wInfo.city;
                    info.Country = wInfo.country;
                    info.HeadImg = wInfo.headimgurl;
                    info.IsSubscribe = wInfo.subscribe == 1 ? true : false;
                    info.Language = wInfo.language;
                    info.NickName = wInfo.nickname;
                    info.Province = wInfo.province;
                    info.Sex = wInfo.sex;
                    info.Unionid = wInfo.unionid ?? string.Empty;
                    info.AppId = HttpContextUntity.CurrentUser.AppID;

                    result += UserService.Insert(info);
                }
            }

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "同步成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "同步失败"));
            }
        }

        #endregion

        #region 02 标签管理
        // GET: Fans
        public ActionResult UserMark(string key, int? page)
        {
            UserTagSearchInfo search = new UserTagSearchInfo();
            search.TagName = HttpUtility.UrlDecode(key);
            search.AppID = HttpContextUntity.CurrentUser.AppID;

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<UserTag> list = UserTagService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }

        public ActionResult UserMarkEditView(string id)
        {
            UserTag obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = UserTagService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new UserTag();
            }

            ViewBag.obj = obj;

            return PartialView();
        }

        public ActionResult UserMarkEdit(UserTag obj)
        {
            int result = 0;

            IList<UserTag> allList = UserTagService.Select("");
            if (allList.Count >= 100)
            {
                return Json(UntityTool.JsonResult(false, "标签数超过100"));
            }

            if (obj.Id > 0)
            {
                UserTag info = UserTagService.SelectObject(obj.Id);
                info.TagName = obj.TagName ?? string.Empty;

                bool isSuccess = WeiXinCommon.EditMark(info.TagId, obj.TagName, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret);
                if (isSuccess)
                {
                    //修改
                    result = UserTagService.Update(info);
                }
            }
            else
            {
                if (allList.Where(u => u.TagName == obj.TagName).Count() > 0)
                {
                    return Json(UntityTool.JsonResult(false, "存在同名标签"));
                }

                obj.CreateTime = DateTime.Now;
                obj.CreateUserAccount = HttpContextUntity.CurrentUser.Account;
                obj.AppId = HttpContextUntity.CurrentUser.AppID;

                string tagId;
                bool isSuccess = WeiXinCommon.AddMark(obj.TagName, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret, out tagId);

                if (isSuccess)
                {
                    obj.TagId = tagId;
                    //新增
                    result = UserTagService.Insert(obj);
                }
            }

            if (obj.Id > 0)
            {
                if (result > 0)
                {
                    return Json(UntityTool.JsonResult(true, "修改成功"));
                }
                else
                {
                    return Json(UntityTool.JsonResult(false, "修改失败"));
                }
            }
            else
            {
                if (result > 0)
                {
                    return Json(UntityTool.JsonResult(true, "新增成功"));
                }
                else
                {
                    return Json(UntityTool.JsonResult(false, "新增失败"));
                }
            }
        }

        public ActionResult UserMarkDelete(string id)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(id))
            {
                UserTag info = UserTagService.SelectObject(int.Parse(id));
                bool isSuccess = WeiXinCommon.DeleteMark(info.TagId, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret);
                if (isSuccess)
                {
                    result = UserTagService.Delete(int.Parse(id));
                }
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

        public ActionResult UserMarkList(string openId)
        {
            ViewBag.openId = openId;
            return PartialView();
        }

        public ActionResult UserMarkListView(string key, string openId)
        {
            int rowCount;
            int pageIndex = Request["pageIndex"].ToInt32(1);
            int pageSize = Request["pageSize"].ToInt32(15);

            string where = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                where = string.Format(" and t2.TagName like '{0}' ", key);
            }

            IList<UserGroup> list = UserGroupService.SelectPageExcuteSql("t1.*,t2.TagName", "t1.CreateTime DESC", "left join [UserTag] t2 on t1.TagId=t2.TagId where t1.OpenId='" + openId + "'" + where, pageIndex, pageSize, out rowCount);


            ViewBag.list = list;

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return PartialView();
        }

        public ActionResult DeleteUserMark(string openIds, string tagId, string id)
        {
            List<string> ids = openIds.Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            bool isSuccess = WeiXinCommon.DeleteBatchUserMark(ids, tagId, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret);

            if (isSuccess)
            {
                UserGroupService.Delete(id.ToInt32(0));

                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "删除失败"));
            }
        }



        #endregion

        #region 03 分组管理

        public ActionResult MarkGroupView()
        {
            return PartialView();
        }

        public ActionResult SearchMarkList(string key)
        {
            UserTagSearchInfo search = new UserTagSearchInfo();
            search.TagName = HttpUtility.UrlDecode(key);
            search.AppID = HttpContextUntity.CurrentUser.AppID;

            int rowCount;
            int pageIndex = Request["pageIndex"].ToInt32(1);
            int pageSize = Request["pageSize"].ToInt32(15);

            IList<UserTag> list = UserTagService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return PartialView();
        }

        public ActionResult MarkGroupEdit(string openIds, string tagId)
        {
            List<string> ids = openIds.Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            bool isSuccess = WeiXinCommon.BatchUserMark(ids, tagId, HttpContextUntity.CurrentUser.AppID, HttpContextUntity.CurrentUser.AppSecret);

            if (isSuccess)
            {
                UserGroup obj = null;
                foreach (string openId in ids)
                {
                    obj = new UserGroup();
                    obj.CreateTime = DateTime.Now;
                    obj.OpenId = openId;
                    obj.TagId = tagId;
                    UserGroupService.Insert(obj);
                }

                return Json(UntityTool.JsonResult(true, "分组成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "分组失败"));
            }
        }

        #endregion

    }
}