using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;
using Site.WeiXin.DataAccess.Service.PartialService.Search;
using System.Text;

namespace Site.WeiXin.Manager.Controllers
{
    public class ReplyController : Controller
    {
        #region 被动回复管理
        public ActionResult KeyWordList(string key, int? page)
        {
            KeyWordsReplySearchInfo search = new KeyWordsReplySearchInfo();
            search.KeyWords = HttpUtility.UrlDecode(key);
            int pageSize = 20;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;
            IList<KeyWordsReply> list = KeyWordsReplyService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;
            return View();
        }


        public ActionResult ReplyEditView(string id)
        {
            KeyWordsReply obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                //修改
                obj = KeyWordsReplyService.SelectObject(int.Parse(id));
            }
            else
            {
                //新增
                obj = new KeyWordsReply();
            }

            ViewBag.obj = obj;

            return PartialView();
        }

        public ActionResult ReplyEdit(int id)
        {
            string type = Request["ReplyType"] ?? string.Empty;
            string intro = Request["Intro"] ?? string.Empty;
            string keywords = Request["keywords"] ?? string.Empty;
            string imageContentIds = Request["imageContentIds"] ?? string.Empty;
            string text = Request["txt_content"] ?? string.Empty;

            KeyWordsReply info = null;
            int result = 0;
            if (id > 0)
            {
                info = KeyWordsReplyService.SelectObject(id);
            }
            else
            {
                info = new KeyWordsReply();
                info.CreateTime = DateTime.Now;
                info.CreateUserAccount = UntityTool.CurrentUser.Account;
            }

            info.Intro = intro;
            info.KeyWords = keywords;
            info.ReplyType = type;

            string contentFormat = string.Empty;
            //图文,组装回复图文消息格式
            if (type == "imageContent")
            {
                StringBuilder sb = new StringBuilder();
                IList<Article> list = ArticleService.Select(string.Format(" where Id in ({0})", imageContentIds));
                foreach (Article item in list)
                {
                    //TODO: 第三方图片地址和文章链接地址
                    sb.AppendFormat(WeiXinCommon.SignImageContentReplyFormat, item.Title, item.Intro, item.CoverSrc, item.ContentSourceUrl);
                }

                contentFormat = WeiXinCommon.BatchImageContentReplyFormat.Replace("{3}", list.Count.ToString())
                                                                         .Replace("{4}", sb.ToString());
            }
            else
            {
                if (type == "text")
                {
                    contentFormat = WeiXinCommon.TextFormat.Replace("{3}", text);
                }
                else
                {
                    Material mInfo = MaterialService.SelectObject(int.Parse(imageContentIds));
                    switch (type)
                    {
                        case "image":
                            contentFormat = WeiXinCommon.ImageFormat.Replace("{3}", mInfo.Media_id);
                            break;
                        case "voice":
                            contentFormat = WeiXinCommon.VoiceFormat.Replace("{3}", mInfo.Media_id);
                            break;
                        case "video":
                            contentFormat = WeiXinCommon.VideoFormat.Replace("{3}", mInfo.Media_id);
                            break;
                        case "music":
                            contentFormat = WeiXinCommon.MusicFormat.Replace("{3}", mInfo.MaterialName)
                                                                    .Replace("{4}", mInfo.Intro)
                                                                    .Replace("{5}", mInfo.Url)
                                                                    .Replace("{6}", "")
                                                                    .Replace("{7}", mInfo.Media_id);
                            break;
                    }
                }
            }

            //新增
            info.ReplyContent = contentFormat;

            if (id > 0)
            {
                result = KeyWordsReplyService.Update(info);
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
                result = KeyWordsReplyService.Insert(info);
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

        public ActionResult ReplyDelete(int id)
        {
            int result = KeyWordsReplyService.Delete(id);

            if (result > 0)
            {
                return Json(UntityTool.JsonResult(true, "删除成功"));
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "删除失败"));
            }
        }

        public ActionResult ReplyContentSearch(string key, string type, int? page)
        {
            //回复图文
            if (type == "imageContent")
            {
                ArticleSearchInfo search = new ArticleSearchInfo();
                search.Title = HttpUtility.UrlDecode(key);
                search.Statu = (int)SiteEnum.ArticleState.通过;

                int pageSize = 20;
                int rowCount;
                int pageIndex = page == null ? 1 : page.Value;
                IList<Article> list = ArticleService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;

                ViewBag.list = list;
                return PartialView("ArticleContent");
            }
            else
            {
                MaterialSearchInfo search = new MaterialSearchInfo();
                search.MaterialName = HttpUtility.UrlDecode(key);
                search.MaterialType = type;

                int pageSize = 20;
                int rowCount;
                int pageIndex = page == null ? 1 : page.Value;
                IList<Material> list = MaterialService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);



                ViewBag.pageIndex = pageIndex;
                ViewBag.pageSize = pageSize;
                ViewBag.rowCount = rowCount;

                ViewBag.list = list;
                return PartialView("MaterialContent");
            }
        }

        public ActionResult CheckReply(string id, string status)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(id))
            {
                KeyWordsReply info = KeyWordsReplyService.SelectObject(int.Parse(id));
                info.Statu = int.Parse(status);
                result = KeyWordsReplyService.Update(info);
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
    }
}