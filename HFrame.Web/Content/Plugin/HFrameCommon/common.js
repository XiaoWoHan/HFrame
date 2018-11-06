$(function () {
    common.ready();
})

var common = {}

common = {
    _Data: {
    },
    ready: function () {
        common.importJs('/Content/Plugin/layer/layer.js');//默认引入Layer
        common.interceptform();//默认拦截表单
    },
    interceptform: function (callback) {//拦截表单
        $(":submit").click(function (check) {
            var d = $('form').serializeArray();
            var u = $('form').attr("action");
            var m = $('form').attr("method");
            common.Http.ajax(u, d, m,function (r) {
                layer.msg(r.ErrorMsg, { anim:0 }, function () {
                    if (callback) {
                        callback(r);
                    }
                });
            });
            check.preventDefault();//此处阻止提交表单
        });
    },
    importJs: function importJs(url) {//封装引入JS
        var newscript = document.createElement('script');
        newscript.setAttribute('type', 'text/javascript');
        newscript.setAttribute('src', url);
        var head = document.getElementsByTagName('head')[0];
        head.appendChild(newscript);
    }
}


common.Http = {
    ///内部参数
    _Data: {
        postlocker: false,//post锁
        getlocker: false,
        ajaxlocker: false,//Ajax锁
    },
    ///发送post请求
    get: function (url, data, callback) {
        if (!common.Http._Data.getlocker) {
            common.Http._Data.getlocker = true;
            $.get(url, data, function (r) {
                common.Http._Data.getlocker = false;
                if (callback) {
                    callback(r);
                }
            });
        } else {
            layer.msg("操作太快啦，稍后再试吧");
        }
    },
    ///发送post请求
    post: function (url, data, callback) {
        if (!common.Http._Data.postlocker) {
            postlocker = true;
            $.post(url, data, function (r) {
                common.Http._Data.postlocker = false;
                if (callback) {
                    callback(r);
                }
            });
        } else {
            layer.msg("操作太快啦，稍后再试吧");
        }
    },
    ///发送Ajax请求
    ajax: function (url, data, method, callback) {
        var lod;
        if (!common.Http._Data.ajaxlocker) {
            $.ajax({
                url: url,
                data: data,
                type: method,
                async: true,
                beforeSend: function () {
                    common.Http._Data.ajaxlocker = true;
                    lod=layer.load();
                },
                success: function (r) {
                    callback(r);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    layer.msg("请求出错");
                },
                complete: function () {
                    common.Http._Data.ajaxlocker = false;
                    layer.close(lod);
                },
                timeout: 20000
            })

        } else {
            layer.msg("操作太快啦，稍后再试吧");
        }
    }
}
