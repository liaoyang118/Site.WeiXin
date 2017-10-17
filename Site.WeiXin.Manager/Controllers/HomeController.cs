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

        public ActionResult MenuEditView(string id)
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

            ViewBag.obj = obj;
            return PartialView();
        }

        public ActionResult MenuEdit(Menu obj)
        {
            int result = 0;
            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(true, "删除失败"));
            }
        }


    }
}