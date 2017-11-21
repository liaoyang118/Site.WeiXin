using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Site.WeiXin.Manager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //防止发布后样式只加载 min,样式丢失
            BundleTable.EnableOptimizations = false;

            //jquery 基础版本和 bootstrap,message
            bundles.Add(new ScriptBundle("~/bundles/js/base").Include(
                        "~/Scripts/jquery-1.10.2.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.toast.js",
                        "~/Scripts/Jquery.toast.customer.js",
                        "~/Scripts/jquery.form.js",
                        "~/Scripts/Jquery_Pagination.js"
                        ));

            //bootstrap 模板脚本
            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap/template").Include(
                        "~/PageTemplate/js/jquery-ui-1.9.2.custom.min.js",//jQuery UI
                        "~/PageTemplate/js/fullcalendar.min.js",//jQuery UI
                        "~/PageTemplate/js/jquery.rateit.min.js",//jQuery UI
                        "~/PageTemplate/js/jquery.prettyPhoto.js",//jQuery UI

                        //jQuery Flot
                        "~/PageTemplate/js/excanvas.min.js",
                        "~/PageTemplate/js/jquery.flot.js",
                        "~/PageTemplate/js/jquery.flot.resize.js",
                        "~/PageTemplate/js/jquery.flot.pie.js",
                        "~/PageTemplate/js/jquery.flot.stack.js",

                        //jQuery Notification - Noty
                        "~/PageTemplate/js/jquery.noty.js",
                        "~/PageTemplate/js/themes/default.js",
                        "~/PageTemplate/js/layouts/bottom.js",
                        "~/PageTemplate/js/layouts/topRight.js",
                        "~/PageTemplate/js/layouts/top.js",


                        "~/PageTemplate/js/sparklines.js",//Sparklines
                        "~/PageTemplate/js/jquery.cleditor.min.js",//CLEditor
                        "~/PageTemplate/js/bootstrap-datetimepicker.min.js",//Date picker
                        "~/PageTemplate/js/bootstrap-switch.min.js",//Bootstrap Toggle
                        "~/PageTemplate/js/filter.js",//Filter for support page
                        "~/PageTemplate/js/custom.js",//Custom codes
                        "~/PageTemplate/js/charts.js"//Charts & Graphs


                        ));



            //bootstrap 基础样式和模板样式
            bundles.Add(new StyleBundle("~/Content/css/base").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/jquery.toast.css",
                "~/PageTemplate/style/font-awesome.css",
                "~/PageTemplate/style/style.css"
                ));

            //bootstrap 模板样式
            bundles.Add(new StyleBundle("~/bundles/css/bootstrap/template").Include(
                        "~/PageTemplate/style/jquery-ui.css",//jQuery UI
                        "~/PageTemplate/style/fullcalendar.css",//Calendar
                        "~/PageTemplate/style/prettyPhoto.css",//prettyPhoto
                        "~/PageTemplate/style/rateit.css",// Star rating
                        "~/PageTemplate/style/bootstrap-datetimepicker.min.css",//Date picker
                        "~/PageTemplate/style/jquery.cleditor.css",//CLEditor
                        "~/PageTemplate/style/bootstrap-switch.css",//Bootstrap toggle
                        "~/PageTemplate/style/widgets.css"//Widgets stylesheet
                        ));

        }
    }
}