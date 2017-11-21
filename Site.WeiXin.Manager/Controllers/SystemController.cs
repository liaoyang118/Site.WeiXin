using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;
using Site.WeiXin.DataAccess.Service.PartialService.Search;

namespace Site.WeiXin.Manager.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult UserList(string key, int? page)
        {
            SystemUserSearchInfo search = new SystemUserSearchInfo();
            search.Account = HttpUtility.UrlDecode(key);

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<SystemUser> list = SystemUserService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


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

            ViewBag.obj = obj;

            return PartialView();
        }

        public ActionResult UserEdit(SystemUser obj)
        {
            int result = 0;

            if (obj.Id > 0)
            {
                SystemUser info = SystemUserService.SelectObject(obj.Id);
                info.AppId = obj.AppId ?? string.Empty;

                //修改
                result = SystemUserService.Update(info);
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
                    obj.AppId = obj.AppId ?? string.Empty;
                    obj.CreateTime = DateTime.Now;
                    obj.CreateUserName = User.Identity.Name;
                    obj.AccountState =(int)SiteEnum.AccountState.正常;

                    if (!string.IsNullOrEmpty(obj.Password.Trim(' ')))
                    {
                        obj.Password = UntityTool.Md5_32(obj.Password);
                    }
                    else
                    {
                        return Json(UntityTool.JsonResult(false, "密码不能为空"));
                    }

                    
                    //新增
                    result = SystemUserService.Insert(obj);
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

        public ActionResult ResetPwdEdit(int id,string pwd)
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

        public ActionResult CustomerList()
        {
            ViewBag.name = User.Identity.Name;

            return View("~/Views/Common/Test.cshtml");
        }
    }
}