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
            string result;
            bool isSuccess = WeiXinCommon.GetAccessToken(out result);
            #endregion

            #region 组装按钮数据
            if (isSuccess)
            {
                IList<Menu> menuList = MenuService.SelectMenuList();//带有 &nbsp;
                string btnParams = WeiXinCommon.GenerateButton(menuList.ToList());
                string publishResult;
                bool isPublishSuccess = WeiXinCommon.PostBtn(result, btnParams, out publishResult);

                return Json(UntityTool.JsonResult(isPublishSuccess, publishResult));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, result));
            }
            #endregion


        }


        public ActionResult UserList(string nickName, int? page)
        {
            UserSearchInfo search = new UserSearchInfo();
            search.NickName = HttpUtility.UrlDecode(nickName);
            int pageSize = 20;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<User> list = UserService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.nickName = HttpUtility.UrlDecode(nickName);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }


        public ActionResult MessageList(string content, int? page)
        {
            MessageSearchInfo search = new MessageSearchInfo();
            search.ContentValue = HttpUtility.UrlDecode(content);
            int pageSize = 20;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<UserMessage> list = UserMessageService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.content = HttpUtility.UrlDecode(content);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            return View();
        }


    }
}