

$(function () {
    importJs('/Content/Plugin/layer/layer.js');
})

//拦截表单提交
$(document).ready(function () {
    $(":submit").click(function (check) {
        var d = $('form').serializeArray();
        var u = $('form').attr("action");
        var m = $('form').attr("method");
        post(u, d, function (r) {
            layer.msg(r.ErrorMsg);
        });

        check.preventDefault();//此处阻止提交表单
    });
});

var postlock = false;
function post(url, data, callback) {
    if (!postlock) {
        postlock = true;
        $.post(url, data, function (r) {
            postlock = false;
            callback(r);
        });
    } else {
        layer.msg("操作太快啦，稍后再试吧");
    }
}

function importJs(url) {
    var newscript = document.createElement('script');
    newscript.setAttribute('type', 'text/javascript');
    newscript.setAttribute('src', url);
    var head = document.getElementsByTagName('head')[0];
    head.appendChild(newscript);
}