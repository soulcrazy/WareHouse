$.extend({
    error: function (msg) {
        $.confirm({
            title: '错误',
            content: msg,
            type: 'red',
            typeAnimated: true,
            buttons: {
                close: {
                    text: '关闭'
                }
            }
        });
    }
});
$.extend({
    message: function (msg) {
        $.confirm({
            title: '消息',
            content: msg,
            type: 'green',
            buttons: {
                close: {
                    text: '关闭'
                }
            }
        });
    }
});
$.extend({
    post: function (setting) {
        $.ajax({
            url: setting.url,
            type: "post",
            data: setting.data,
            dataType: "json",
            success: function (res) {
                if (res.code === 500) {
                    $.message(res.message);
                    return false;
                } if (res.code === 401) {
                    $.error("未登录");
                    return false;
                } if (res.code === 200) {
                    setting.success(res);
                    return true;
                }
                return false;
            },
            error: function (res) {
                $.error("请求失败");
            }
        });
    }
});
$.extend({
    get: function (setting) {
        $.ajax({
            url: setting.url,
            type: "get",
            data: setting.data,
            dataType: "json",
            success: function (res) {
                if (res.code === 500) {
                    $.message(res.message);
                    return false;
                } if (res.code === 401) {
                    $.error("未登录");
                    return false;
                } if (res.code === 200) {
                    setting.success(res);
                    return true;
                }
                return false;
            },
            error: function (res) {
                $.error("请求失败");
            }
        });
    }
});