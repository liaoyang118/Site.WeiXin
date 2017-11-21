/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery.toast.js" />
$.extend({
    //toastmessage封装
    Info: function (text, hideAfter, position) {
        $.toast({
            heading: '提示信息',
            text: text,
            showHideTransition: 'slide',
            icon: 'info',
            hideAfter: hideAfter ? hideAfter : false,
            position: position ? position : "mid-center"
        })
    },
    ErrorInfo: function (text, hideAfter, position) {
        $.toast({
            heading: '提示信息',
            text: text,
            showHideTransition: 'fade',
            icon: 'error',
            hideAfter: hideAfter ? hideAfter : false,
            position: position ? position : "mid-center"
        })
    },
    WarningInfo: function (text, hideAfter, position) {
        $.toast({
            heading: '提示信息',
            text: text,
            showHideTransition: 'plain',
            icon: 'warning',
            hideAfter: hideAfter ? hideAfter : false,
            position: position ? position : "mid-center"
        })
    },
    SuccessInfo: function (text, hideAfter, position) {
        $.toast({
            heading: '提示信息',
            text: text,
            showHideTransition: 'slide',
            icon: 'success',
            hideAfter: hideAfter ? hideAfter : false,
            position: position ? position : "mid-center"
        })
    },

    //bootstrap loading封装
    ShowLoading: function (text) {
        if ($("#loading").length > 0) {
            //特殊处理，防止冲突，删除掉元素
            $("#loading").remove();
        }
        $("body").append("<!-- loading -->" +
            "<div class='modal fade' id='loading' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' data-backdrop='static'>" +
            "<div class='modal-dialog' role='document'>" +
            "<div class='modal-content'>" +
            "<div class='modal-header'>" +
            "<h4 class='modal-title' id='myModalLabel'>提示</h4>" +
            "</div>" +
            "<div id='loadingText' class='modal-body'>" + text +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>"
        );

        $("#loading").modal("show");
    },
    HideLoading: function () {
        $("#loading").modal("hide");
    }



})