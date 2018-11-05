$(":submit").click(function (check) {
    var val = $(":text[id=test]").val();
    if (val == "") {
        alert("文本框输入为空，不能提交表单！");
        $(":text[id=test]").focus();
        check.preventDefault();//此处阻止提交表单  
    }
});