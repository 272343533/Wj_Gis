function ViewToEdit(btntext) {
    if (btntext == '编辑') {

        $(".vieworedit").removeAttr("disabled");
        //$(".vieworedit").css("background-color", "#33ffcc");
        $(".vieworedit").css("background-color", "#FFFFFF");

        $(".vieworedit").css("color", "#000000");

        $('#postChange').hide();
        $('#btnSubmit').show();
    }
    else {
        $(".vieworedit").attr("disabled", false);
        //$(".vieworedit").css("background-color", "#FFFF00");
        $(".vieworedit").css("background-color", "#FFFFFF");
        $(".vieworedit").css("color", "#000000");
        $('#postChange').show();
        $('#btnSubmit').hide();
    }

}