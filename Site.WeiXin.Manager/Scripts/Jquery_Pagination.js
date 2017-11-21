/*
//pageBar--页码容器
//参考样式
 #page span
{
    border: 1px solid #808080;
    padding: 3px 5px;
    margin-left: 3px;
    cursor: pointer;
    width: 27px;
}
 
#page span:hover
{
    border: 1px solid #808080;
    padding: 3px 5px;
    margin-left: 3px;
    background: #ffd800;
    cursor: pointer;
    width: 27px;
}
 
.cur
{
    background: #ffd800;
}
*/

///调用方法：UserPage.MakePageBar("pageBar", 60, 10, function () {
///         loadList(UserPage.currentPage);
///         });
///
///
///
var UserPage = {
    currentPage: 1,//默认为 首页
    callback: null,//回调函数
    barInteval: 5,//页码条间隔页
    defaulStart: 1,//开始页码
    defaultEnd: function () {
        return this.barInteval;//默认结束页码
    },
    previousText: "前一页",
    nextText: "下一页",
    firstText: "首页",
    endText: "尾页",
    //创建页码条
    //id:页码条容器；rowCount:总条数：pageSize:页容量；userCallBack:用户回调函数固定参数（UserPage.currentPage）
    MakePageBar: function (id, rowCount, pageSize, userCallBack) {

        //将回调函数赋值
        if (userCallBack) {
            this.callback = userCallBack;
        }
        //重绘之前先清掉内容
        $("#" + id).html("");

        //页码容器
        var page = $("#" + id);
        //总页数
        var pageCount = Math.ceil(rowCount / pageSize);
        if (pageCount > 1) {


            //前一页 按钮
            var pre = $("<li><a href='javascript:void(0);'></a></li>").find("a").html(UserPage.previousText).bind("click", function () {
                if (UserPage.currentPage > 1) {
                    UserPage.currentPage -= 1;
                    UserPage.MakePageBar(id, rowCount, pageSize);
                    UserPage.callback();
                }
                else {
                    return false;
                }
            });
            //首页 按钮
            var first = $("<li><a href='javascript:void(0);'></a></li>").find("a").html(UserPage.firstText).bind("click", function () {
                UserPage.currentPage = 1;
                UserPage.MakePageBar(id, rowCount, pageSize);
                UserPage.callback();
            });

            //第一页时，前一页不可用
            if (this.currentPage == 1) {
                pre.css({
                    background: "#cbd1d1",
                    border: "1px solid #808080",
                    padding: "3px 5px",
                    "margin-left": "3px"
                });
            }
            //var totalText = $('<strong style="font-size:14px;">共<a style="color:red;font-family:微软雅黑;">' + rowCount + '</a>条</strong>');
            //添加总数和前一页 按钮
            //page.append(totalText);
            page.append(pre);
            //添加首页 按钮
            if (UserPage.currentPage > 1) {
                page.append(first);
            }

            if (this.callback == null) {
                throw "必须设置回调函数";
                return false;
            }
            if (!this.callback instanceof Object) {
                throw "确定函数格式";
                return false;
            }
            //-----------------------------------------
            //生成页码条的 起始位置---间隔页位置
            if (this.currentPage % this.barInteval == 0) {
                this.defaulStart = this.currentPage - this.barInteval + 1;
                this.defaultEnd = parseInt(this.currentPage) + parseInt(this.barInteval);

                if (this.defaultEnd > pageCount) {
                    this.defaultEnd = pageCount;
                }
            }
                //首页时
            else if (this.currentPage == 1) {
                //判断总页数是否 大于 页码间隔
                if (pageCount > this.barInteval) {
                    this.defaulStart = this.currentPage;
                    this.defaultEnd = parseInt(this.currentPage) + parseInt(this.barInteval) - 1;
                }
                else {
                    this.defaultEnd = pageCount;
                }
            }
                //尾页时
            else if (this.currentPage == pageCount) {

                //判断总页数是否 大于 页码间隔
                if (pageCount > this.barInteval) {
                    this.defaulStart = this.currentPage - this.barInteval;
                    this.defaultEnd = pageCount;
                }
                else {
                    this.defaulStart = 1;
                    this.defaultEnd = pageCount;
                }
            }
            //生成页码条
            for (var i = this.defaulStart; i <= this.defaultEnd; i++) {
                var a = $("<li><a href='javascript:void(0);'></a></li>").find("a").html(i).bind("click", function () {
                    //绑定点击方法
                    UserPage.currentPage = $(this).html();//当前页值
                    UserPage.MakePageBar(id, rowCount, pageSize);//更具当前页值重绘 页码条
                    UserPage.callback();//调用用户 传入的 回调函数（一般为分页Ajax查询）
                });
                if (i == this.currentPage) {
                    a.addClass("cur");
                    a.unbind("click");
                }
                page.append(a);
            }

            //-----------------------------------------
            //尾页 按钮
            var end = $("<li><a href='javascript:void(0);'></a></li>").find("a").html(UserPage.endText).bind("click", function () {
                UserPage.currentPage = pageCount;
                UserPage.MakePageBar(id, rowCount, pageSize);
                UserPage.callback();
            });

            if (this.currentPage != pageCount) {
                page.append(end);
            }

            //----------------------------------
            //下一页 按钮
            var next = $("<li><a href='javascript:void(0);'></a></li>").find("a").html(UserPage.nextText).bind("click", function () {
                if (UserPage.currentPage < pageCount) {
                    UserPage.currentPage = parseInt(UserPage.currentPage) + 1;
                    UserPage.MakePageBar(id, rowCount, pageSize);
                    UserPage.callback();
                }
                else {
                    return false;
                }
            });
            //最后一页时，下一页不可用
            if (this.currentPage == pageCount) {
                next.css({
                    background: "#cbd1d1",
                    border: "1px solid #808080",
                    padding: "3px 5px",
                    "margin-left": "3px"
                });
            }
            //添加下一页 按钮
            page.append(next);
        }
            //只显示文本
        //else {
        //    var totalText = $('<strong style="font-size:14px;">共<a style="color:red;font-family:微软雅黑;">' + rowCount + '</a>条</strong>');
        //    page.append(totalText);
        //}
    }
};