using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.BT.DataAccess.Model;
using Site.BT.DataAccess.Service;
using Site.BT.Manager.Common;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;

namespace Site.BT.Filder
{
    /// <summary>
    /// 身份验证，拉取微信用户信息
    /// </summary>
    public class IdentityAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //snsapi_base 静默授权 如果用户未关注，只能获取 openid
            //snsapi_userinfo 授权页面 如果用户未关注，确认后也可以获取到openid和access_token，并通过接口拿到用户基本信息

            //判断是否是code回调
            string code = filterContext.RequestContext.HttpContext.Request["code"] ?? string.Empty;
            if (!string.IsNullOrEmpty(code))
            {
                string openid = string.Empty;
                string access_token = string.Empty;
                string scope = string.Empty;
                bool isSuccess = WeiXinCommon.GetIdentityAccessToken(code, out openid, out access_token, out scope);
                if (isSuccess)
                {
                    //snsapi_base式的网页授权流程即到此为止
                    //snsapi_userinfo 还可以继续获取用户基本信息

                    IList<User> uList = UserService.Select(string.Format(" where OpenID='{0}'", openid));
                    if (scope == "snsapi_userinfo")
                    {
                        IdentityUserInfo uInfo = null;
                        isSuccess = WeiXinCommon.GetIdentityUserInfo(openid, access_token, out uInfo);
                        if (isSuccess)
                        {
                            //1.处理用户信息
                            if (uList.Count == 0)
                            {
                                User info = new User();
                                info.OpenID = openid;
                                info.Subscribe_Time = DateTime.Now;
                                info.IsSubscribe = true;
                                info.UnSubscribe_Time = DateTime.Now;

                                info.City = uInfo.city;
                                info.Country = uInfo.country;
                                info.HeadImg = uInfo.headimgurl;
                                info.IsSubscribe = false;
                                info.Language = "CN";
                                info.NickName = uInfo.nickname;
                                info.Province = uInfo.province;
                                info.Sex = uInfo.sex;
                                info.Unionid = uInfo.unionid ?? string.Empty;
                                UserService.Insert(info);
                            }
                        }
                        else
                        {
                            //网页授权获取用户信息错误，导航到错误页面

                        }
                    }
                    else
                    {
                        //snsapi_base 处理

                        //1.判断是否有关注
                        if (uList.Count == 0)
                        {
                            //未关注，导航到关注页面，先关注
                        }
                    }

                    //判断是否有绑定账号
                    IList<BusinessAccountBinding> bList = BusinessAccountBindingService.Select(string.Format(" where OpenID='{0}'", openid));
                    if (bList.Count == 0)
                    {
                        //没有绑定信息，导航到绑定账号页面

                    }
                    else
                    {
                        //根据绑定的业务用户ID,加载用户信息
                        BusinessAccountBinding bInfo = bList.FirstOrDefault();
                        BusinessUser bUinfo = BusinessUserService.SelectObject(bInfo.BusinessUserId);
                        if (bUinfo != null)
                        {
                            HttpContextUntity.CurrentUser = bUinfo;
                        }
                        else
                        {
                            //未查询到用户信息，导航到错误页面

                        }
                    }

                }
                else
                {
                    //网页授权获取openid错误，导航到错误页面

                }
            }
            else
            {
                //发起getcode
                string urlFormat = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state=STATE#wechat_redirect";
                string targetUrl = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                string getCodeUrl = string.Format(urlFormat, UntityTool.GetConfigValue("appID"), HttpUtility.UrlEncode(targetUrl), "snsapi_userinfo");
                filterContext.Result = new RedirectResult(getCodeUrl);
            }


            //base.OnAuthorization(filterContext);
        }




    }
}