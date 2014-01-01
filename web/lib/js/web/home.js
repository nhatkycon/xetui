jQuery(function () {
    $('#__VIEWSTATE').remove();
    autoFn.ini();
});

var autoFn = {
    ini:function () {
        autoFn.trackUi();
    }
    , trackUi: function () {
        var w = $(window).width();
        var h = $(window).height();
        document.title = w + ';' + h;
        window.onresize = function() {
            autoFn.trackUi();
        };
    }
};

