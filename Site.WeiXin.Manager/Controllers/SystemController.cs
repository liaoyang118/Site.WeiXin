using System;
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
    [Permission(AllowSuperAdmin = true)]
    public class SystemController : Controller
    {
        #region 系统用户管理
        public ActionResult UserList(string key, int? page)
        {
            SystemUserSearchInfo search = new SystemUserSearchInfo();
            search.Account = HttpUtility.UrlDecode(key);

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            string where = "left join [GongzhongAccount] t2 on t1.GongzhongAccountId=t2.Id where t1.IsSuperAdmin=0 ";
            if (!HttpContextUntity.CurrentUser.IsSuperAdmin)
            {
                where += " and t2.AppID='" + HttpContextUntity.CurrentUser.AppID + "'";
            }

            if (!string.IsNullOrEmpty(key))
            {

                where += string.Format(" and t1.Account like '{0}' ", HttpUtility.UrlDecode(key));
            }

            IList<SystemUser> list = SystemUserService.SelectPageExcuteSql("t1.*,t2.AppID,t2.AppSecret,t2.Name", "t1.CreateTime DESC", where, pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }
        public ActionResult UserEditView(string id)
        {
            SystemUser obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = SystemUserService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new SystemUser();
            }

            string where = string.Empty;
            if (!HttpContextUntity.CurrentUser.IsSuperAdmin)
            {
                where = " where AppID='" + HttpContextUntity.CurrentUser.AppID + "'";
            }

            //查询公众号
            List<GongzhongAccount> list = GongzhongAccountService.Select(where).ToList();
            List<SelectListItem> selectList = list.Select(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.Id.ToString(),
                    Selected = t.Id == obj.GongzhongAccountId

                };
            }).ToList();


            ViewBag.obj = obj;
            ViewBag.selectList = selectList;
            return PartialView();
        }
        public ActionResult UserEdit(SystemUser obj)
        {
            int result = 0;
            SystemUser info = null;
            if (obj.Id > 0)
            {
                info = SystemUserService.SelectObject(obj.Id);

            }
            else
            {
                IList<SystemUser> uList = SystemUserService.Select(string.Format(" where Account='{0}'", obj.Account));
                if (uList.Count > 0)
                {
                    return Json(UntityTool.JsonResult(false, "已存在同名账户"));
                }
                else
                {
                    obj.CreateTime = DateTime.Now;
                    obj.CreateUserName = User.Identity.Name;
                    obj.AccountState = (int)SiteEnum.AccountState.正常;

                    info = obj;
                    if (!string.IsNullOrEmpty(obj.Password.Trim(' ')))
                    {
                        info.Password = UntityTool.Md5_32(obj.Password);
                    }
                    else
                    {
                        return Json(UntityTool.JsonResult(false, "密码不能为空"));
                    }
                }
            }

            info.GongzhongAccountId = obj.GongzhongAccountId;
            info.IsAdmin = obj.IsAdmin;


            if (obj.Id > 0)
            {
                //修改
                result = SystemUserService.Update(info);
            }
            else
            {
                //新增
                result = SystemUserService.Insert(info);
            }

            if (obj.Id > 0)
            {
                if (result > 0)
                {
                    return Json(UntityTool.JsonResult(true, "修改成功"));
                }
                else
                {
                    return Json(UntityTool.JsonResult(true, "修改失败"));
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
                    return Json(UntityTool.JsonResult(true, "新增失败"));
                }
            }
        }
        public ActionResult Delete(string id)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(id))
            {
                result = SystemUserService.Delete(int.Parse(id));
            }

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "删除失败"));
            }
        }
        public ActionResult CheckSystemUser(string id, string status)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(id))
            {
                SystemUser info = SystemUserService.SelectObject(int.Parse(id));
                info.AccountState = int.Parse(status);
                result = SystemUserService.Update(info);
            }

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "审核成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "审核失败"));
            }
        }
        public ActionResult ResetPwdView(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        public ActionResult ResetPwdEdit(int id, string pwd)
        {
            int result = 0;
            if (id > 0)
            {
                SystemUser info = SystemUserService.SelectObject(id);
                info.Password = UntityTool.Md5_32(pwd);

                result = SystemUserService.Update(info);
            }

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "修改成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "修改失败"));
            }
        }

        #endregion

        #region 客服管理
        public ActionResult CustomerList()
        {
            ViewBag.title = "客服管理";
            ViewBag.words = "功能待开发";
            return View("~/Views/Common/Common.cshtml");
        }

        #endregion

        #region 公众号管理

        public ActionResult AppList(string key, int? page)
        {
            GongzhongAccountSearchInfo search = new GongzhongAccountSearchInfo();
            search.Name = HttpUtility.UrlDecode(key);

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            IList<GongzhongAccount> list = GongzhongAccountService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }

        public ActionResult AppEditView(string id)
        {
            GongzhongAccount obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = GongzhongAccountService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new GongzhongAccount();
            }

            ViewBag.obj = obj;
            return PartialView();
        }

        public ActionResult AppEdit(GongzhongAccount obj)
        {
            int result = 0;
            GongzhongAccount info = null;
            if (obj.Id > 0)
            {
                info = GongzhongAccountService.SelectObject(obj.Id);
            }
            else
            {
                IList<GongzhongAccount> gzList = GongzhongAccountService.Select(string.Format(" where AppID='{0}'", obj.AppID));
                if (gzList.Count > 0)
                {
                    return Json(UntityTool.JsonResult(false, "已存在相同的AppId"));
                }
                else
                {
                    obj.CreateTime = DateTime.Now;
                    obj.CreateUserAccount = User.Identity.Name;
                    info = obj;
                }
            }

            info.AppAccount = obj.AppAccount;
            info.AppID = obj.AppID;
            info.AppSecret = obj.AppSecret;
            info.Name = obj.Name;
            info.Intro = obj.Intro;


            if (obj.Id > 0)
            {
                //修改
                result = GongzhongAccountService.Update(info);
            }
            else
            {
                //新增
                result = GongzhongAccountService.Insert(info);
            }

            if (obj.Id > 0)
            {
                if (result > 0)
                {
                    return Json(UntityTool.JsonResult(true, "修改成功"));
                }
                else
                {
                    return Json(UntityTool.JsonResult(true, "修改失败"));
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
                    return Json(UntityTool.JsonResult(true, "新增失败"));
                }
            }
        }

        public ActionResult AppDelete(string id)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(id))
            {
                result = GongzhongAccountService.Delete(id.ToInt32(0));
            }

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "删除失败"));
            }
        }


        #endregion

    }
}