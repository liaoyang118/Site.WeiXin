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
        #region 01 文章管理
        public ActionResult Index(string key, int? page)
        {
            ArticleSearchInfo search = new ArticleSearchInfo();
            search.Title = HttpUtility.UrlDecode(key);
            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<Article> list = ArticleService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

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

            //文件
            HttpPostedFileBase file = Request.Files["lefile"] ?? null;
            List<string> urls = new List<string>();
            if (file != null && file.ContentLength > 0)
            {
                byte[] bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, bytes.Length);
                string ext = System.IO.Path.GetExtension(file.FileName);
                string[] allowExt = new string[] { ".jpg", ".png", ".bpm" };
                if (!allowExt.Contains(ext))
                {
                    return Json(UntityTool.JsonResult(false, "不支持该文件格式"));
                }
                //大图 360*200，小图200*200
                urls = UntityTool.UploadImg(bytes, "WeiXinUpload", new List<string>() { "360*200" }, ext);
            }


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

                if (urls.Count > 1)
                {
                    info.CoverSrc = urls[1];
                }

                //修改
                result = ArticleService.Update(info);
            }
            else
            {
                obj.MediaId = obj.MediaId ?? string.Empty;
                obj.CreateTime = DateTime.Now;
                obj.CreateUserAccount = User.Identity.Name;
                obj.ContentSourceUrl = obj.ContentSourceUrl ?? string.Empty;
                if (urls.Count > 1)
                {
                    obj.CoverSrc = urls[1];
                }

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
            if (!string.IsNullOrEmpty(id))
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
            if (!string.IsNullOrEmpty(id))
            {
                Article info = ArticleService.SelectObject(int.Parse(id));
                info.Statu = int.Parse(status);
                result = ArticleService.Update(info);
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
        #endregion

        #region 02 素材管理
        public ActionResult MaterialList(string key, int? page)
        {
            MaterialSearchInfo search = new MaterialSearchInfo();
            search.MaterialName = HttpUtility.UrlDecode(key);
            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<Material> list = MaterialService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;
            return View();
        }

        public ActionResult MaterialEditView(string id)
        {
            Material obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = MaterialService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new Material();
            }

            ViewBag.obj = obj;

            return PartialView();
        }

        public ActionResult MaterialEdit(int id)
        {
            string type = Request["MaterialType"] ?? string.Empty;
            string intro = Request["Intro"] ?? string.Empty;
            string name = Request["MaterialName"] ?? string.Empty;
            string expire = Request["expire"] ?? string.Empty;//temp 临时，long 永久

            //修改图文素材的索引 默认为0
            string index = Request["index"] ?? string.Empty;

            Material info = null;
            int result = 0;
            if (id > 0)
            {
                info = MaterialService.SelectObject(id);
            }
            else
            {
                info = new Material();
                info.CreateTime = DateTime.Now;
                info.CreateUserAccount = User.Identity.Name;
            }

            info.Intro = intro;
            info.MaterialName = name;
            info.MaterialType = type;
            info.Url = string.Empty;
            info.Expire = expire;

            bool isSuccess = false;
            string media_id = string.Empty;
            //图文 -- 只有图文能修改
            if (type == "imageContent")
            {
                string imageContentIds = Request["imageContentIds"] ?? string.Empty;
                IList<Article> list = ArticleService.Select(string.Format(" where Id in ({0})", imageContentIds));

                string body = WeiXinCommon.GenerateImageContentBody(list);
                if (id > 0)
                {
                    //修改
                    body = WeiXinCommon.GenerateUpdateImageContentBody(list.FirstOrDefault(), info.Media_id, int.Parse(index));
                    isSuccess = WeiXinCommon.EditPermanentMaterial(body);
                }
                else
                {
                    //新增
                    isSuccess = WeiXinCommon.AddPermanentMaterial(body, out media_id);
                }
            }
            else if (type == "video")//视频需要特殊处理
            {
                //TODO:视频素材处理
            }
            else
            {
                //上传多媒体资料到微信服务器
                HttpPostedFileBase file = Request.Files["lefile"] ?? null;
                if (file != null)
                {
                    byte[] bytes = new byte[file.ContentLength];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    if (expire == "temp")
                    {
                        isSuccess = WeiXinCommon.AddTempMaterial(type, bytes, file.FileName, out media_id);
                    }
                    else
                    {
                        isSuccess = WeiXinCommon.AddPermanentMaterial(type, bytes, file.FileName, out media_id);
                    }
                }
                else
                {
                    return Json(UntityTool.JsonResult(false, "素材内容为空"));
                }
            }
            if (isSuccess)
            {
                if (id > 0)
                {
                    result = MaterialService.Update(info);
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
                    //新增
                    info.Media_id = media_id;
                    result = MaterialService.Insert(info);
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
            else
            {
                return Json(UntityTool.JsonResult(false, "上传素材出错"));
            }
        }

        public ActionResult MaterialDelete(int id, string mediaId)
        {
            int result = MaterialService.Delete(id);
            if (!string.IsNullOrEmpty(mediaId))
            {
                WeiXinCommon.DeletePermanentMaterial(mediaId);
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

        public ActionResult MaterialContentSearch(string key)
        {
            ArticleSearchInfo search = new ArticleSearchInfo();
            search.Title = HttpUtility.UrlDecode(key);
            int rowCount;
            IList<Article> list = ArticleService.SelectPage("*", search.OrderBy, search.ToWhereString(), 1, 8, out rowCount);


            ViewBag.list = list;

            return PartialView();
        }
        #endregion

    }
}