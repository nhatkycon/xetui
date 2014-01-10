$(function() {
    admFn.init();
});

var admFn ={
    init:function () {
        admFn.headerFn();
    }
    , headerFn:function () {
        var pnl = $('.ModuleHeader');

        if ($(pnl).length < 1) return;

        var txt = pnl.find('[name="q"]');
        var searchBtn = pnl.find('.searchBtn');

        searchBtn.click(function () {
            var data = pnl.find(':input').serialize();
            document.location.href = '?' + data;
        });
        txt.focus(function () {
            txt.unbind('keypress').bind('keypress', function (evt) {
                if (evt.keyCode == 13) {
                    evt.preventDefault();
                    var data = pnl.find(':input').serialize();
                    document.location.href = '?' + data;
                    return false;
                }
            });
        });

        var tuNgayPicker = pnl.find('#TuNgayPicker');
        if ($(tuNgayPicker).length > 0) {
            tuNgayPicker.datetimepicker({
                language: 'vi-Vn'
            });
        }
        var denNgayPicker = pnl.find('#DenNgayPicker');
        if ($(denNgayPicker).length > 0) {
            denNgayPicker.datetimepicker({
                language: 'vi-Vn'
            });
        }
    }
}