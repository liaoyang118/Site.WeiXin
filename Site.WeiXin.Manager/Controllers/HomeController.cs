using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;

namespace Site.WeiXin.Manager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {

            IList<Menu> list = MenuService.SelectMenuList();


            ViewBag.list = list;
            return View();
        }


        public ActionResult Delete(string id, string parentId)
        {
            int result = 0;
            if (string.IsNullOrEmpty(parentId))
            {
                result = MenuService.Delete(int.Parse(id));
            }
            else
            {
                result = MenuService.DeleteByParentId(int.Parse(id), int.Parse(parentId));
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

        public ActionResult MenuEditView(string id, string parentId)
        {
            Menu obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = MenuService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new Menu();
            }

            //查询菜单类型
            List<MenuType> list = MenuTypeService.Select("").ToList();
            List<SelectListItem> selectList = list.Select(t =>
            {
                return new SelectListItem()
                {
                    Text = string.Format("{0}({1})", t.Intro, t.Type),
                    Value = t.Type,
                    Selected = t.Type == obj.Type

                };
            }).ToList();



            ViewBag.obj = obj;
            ViewBag.selectList = selectList;
            ViewBag.parentId = parentId;

            return PartialView();
        }

        public ActionResult MenuEdit(Menu obj)
        {
            int result = 0;
            if (obj.Id > 0)
            {
                Menu info = MenuService.SelectObject(obj.Id);
                info.Name = obj.Name ?? string.Empty;
                info.Type = obj.Type ?? string.Empty;
                info.Value = obj.Value ?? string.Empty;

                //修改
                result = MenuService.Update(info);
            }
            else
            {
                obj.CreateTime = DateTime.Now;
                obj.Status = (int)SiteEnum.MenuState.正常;
                obj.Value = obj.Value ?? string.Empty;

                //新增
                result = MenuService.Insert(obj);

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


        public ActionResult PublishButton()
        {
            #region 拿取access_token
            IList<GloblaToken> list = GloblaTokenService.Select(string.Format(" and AppId='{0}'", UntityTool.GetConfigValue("appID"), DateTime.Now));
            string result = string.Empty;
            if (list.Count > 0)
            {
                GloblaToken info = list.FirstOrDefault();
                if (info.ExpireTime > DateTime.Now)
                {
                    result = info.Token;
                }
                else
                {
                    bool isSuccess = UntityTool.GetHttpToken(out result);
                    if (isSuccess)
                    {
                        //更新时间
                        info.ExpireTime = DateTime.Now.AddHours(2);
                        GloblaTokenService.Update(info);
                    }
                    else
                    {
                        return Json(UntityTool.JsonResult(false, result));
                    }
                }
            }
            else
            {
                //获取新的access_token
                bool isSuccess = UntityTool.GetHttpToken(out result);
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
                else
                {
                    return Json(UntityTool.JsonResult(false, result));
                }

            }
            #endregion

            #region 组装按钮数据
            IList<Menu> menuList = MenuService.SelectMenuList();//带有 &nbsp;
            string btnParams = WeiXinCommon.GenerateButton(menuList.ToList());
            string publishResult;
            bool isPublishSuccess = UntityTool.PostBtn(result, btnParams, out publishResult);
            #endregion

            return Json(UntityTool.JsonResult(isPublishSuccess, publishResult));
        }


    }
}