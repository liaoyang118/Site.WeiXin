//扩展jquery ajax 表单异步上传文件 --yang.liao 没有和ajax 做合并
(function ($) {
    $.extend({
        //自定义扩展异步表单上传图片，限制返回Json,可以不用指定表单属性
        //fromeId:表单ID, url:提交地址, type：post/get, success:回调函数
        ajaxFile: function (fromeId, url, type, success) {
            //创建一个隐藏的Iframe
            var _iframe = $('<iframe style="display:none;" name="ajaxIframe" id="ajaxIframe"></iframe>');

            //添加到页面上
            $("body").append(_iframe);
            //将表单放到 隐藏的Iframe 里面提交
            var _from = $("#" + fromeId);
            _from.attr("enctype", "multipart/form-data");
            _from.attr("action", url);
            _from.attr("method", type);
            _from.attr("target", "ajaxIframe");
            //提交表单
            _from.submit();

            //加载完Iframe后在 load 事件中获取返回值
            var xml = {}, io = _iframe.get(0);
            var json = "";
            if (window.attachEvent) {
                io.attachEvent('onload', function () {
                    json = getJson(xml, "ajaxIframe");
                    success(json);
                });//IE
            }
            else {
                io.addEventListener('load', function () {
                    json = getJson(xml, "ajaxIframe");
                    success(json);
                }, false);//非IE
            }

            //注意：iframe,获取内容，用原生JS 
            function getJson(xml, iframeId) {
                var io2 = $("#" + iframeId).get(0);
                if (io2.contentWindow) {
                    xml.responseText = io2.contentWindow.document.body ? io2.contentWindow.document.body.innerHTML : null;
                    xml.responseXML = io2.contentWindow.document.XMLDocument ? io2.contentWindow.document.XMLDocument : io2.contentWindow.document;

                } else if (io2.contentDocument) {
                    xml.responseText = io2.contentDocument.document.body ? io2.contentDocument.document.body.innerHTML : null;
                    xml.responseXML = io2.contentDocument.document.XMLDocument ? io2.contentDocument.document.XMLDocument : io2.contentDocument.document;
                }

                var data = xml.responseText;
                var json = eval("(" + $(data).text() + ")");
                return json;
            };

        }
        ////formData
        //ajaxFormData: function (options) {
        //    if (options.formId) {
        //        var formdata = new FormData($("#" + options.formId));
        //        options.data = formdata;
        //    }
        //    else {
        //        throw "请指定表单ID 参数formId";
        //        return false;
        //    }
        //    var _option = $.extend({}, $.ajaxSettings, options);
        //    $.ajax(_option);
        //}
    });


})(jQuery)