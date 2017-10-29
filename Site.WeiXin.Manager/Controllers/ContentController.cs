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
    public class ContentController : Controller
    {
        public ActionResult Index(string title, int? page)
        {
            ArticleSearchInfo search = new ArticleSearchInfo();
            search.Title = HttpUtility.UrlDecode(title);
            int pageSize = 20;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<Article> list = ArticleService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.title = HttpUtility.UrlDecode(title);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;
            return View();
        }

        public ActionResult ContentEditView(string id)
        {
            Article obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = ArticleService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new Article();
            }

            ViewBag.obj = obj;

            return PartialView();
        }

        [ValidateInput(false)]
        public ActionResult ArticleEdit(Article obj)
        {
            int result = 0;
            if (obj.Id > 0)
            {
                Article info = ArticleService.SelectObject(obj.Id);
                info.ArticleContent = obj.ArticleContent ?? string.Empty;
                info.AuthorName = obj.AuthorName ?? string.Empty;
                info.ContentSourceUrl = obj.ContentSourceUrl ?? string.Empty;
                info.Intro = obj.Intro ?? string.Empty;
                info.MediaId = obj.MediaId ?? string.Empty;
                info.ShowCover = obj.ShowCover;
                info.Title = obj.Title;

                //修改
                result = ArticleService.Update(info);
            }
            else
            {
                obj.MediaId = obj.MediaId ?? string.Empty;
                obj.CreateTime = DateTime.Now;
                obj.CreateUserAccount = User.Identity.Name;

                //新增
                result = ArticleService.Insert(obj);

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
            if (string.IsNullOrEmpty(id))
            {
                result = ArticleService.Delete(int.Parse(id));
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

        public ActionResult CheckArticle(string id, string status)
        {
            int result = 0;
            if (string.IsNullOrEmpty(id))
            {
                result = ArticleService.Delete(int.Parse(id));
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

        public ActionResult Test()
        {
            return View();
        }
    }
}