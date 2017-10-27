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

        //[ValidateInput(false)]
        //public ActionResult ContentEdit()
        //{

        //}
        
        public ActionResult Test()
        {
            return View();
        }
    }
}