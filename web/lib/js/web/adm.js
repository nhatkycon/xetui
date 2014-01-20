$(function() {
    admFn.init();
});

var admFn ={
    init:function () {
        admFn.headerFn();
        admFn.promoteFn.init();
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
    , url: {
        promoted: '/lib/ajax/promoted/Default.aspx'
    }
    , promoteFn: {
        init: function () {
            admFn.promoteFn.add();
        }
        , add: function () {
            var pnl = $('.promoted-add-pnl');
            if ($(pnl).length < 1) return;
            var btn = pnl.find('.saveBtn');
            var xoaBtn = pnl.find('.xoaBtn');
            var adminSaveBtn = pnl.find('.adminSaveBtn');

            var txt = pnl.find('.Ten');
            var moTa = pnl.find('.MoTa');

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


            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');

            btn.click(function () {
                alertErr.hide();
                alertOk.hide();
                var val = txt.val();
                if (val == '') {
                    alertErr.show();
                    alertErr.html('Nhập nội dung bạn ơi');
                    return;
                }


                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });

                $.ajax({
                    url: admFn.url.promoted
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') {
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           setTimeout(function () {
                               document.location.href = rs + '/lib/mod/Promoted/';
                           }, 1000);
                       }
                   }
                });
            });


            adminSaveBtn.click(function () {
                alertErr.hide();
                alertOk.hide();
                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });

                $.ajax({
                    url: admFn.url.promoted
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           setTimeout(function () {
                               document.location.href = rs + '/lib/mod/Promoted/';
                           }, 1000);
                       }
                   }
                });
            });

            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa?');
                if (!con) return;

                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: admFn.url.promoted
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       document.location.href = rs + '/lib/mod/Promoted/';
                   }
                });
            });

            var nhomAvatar = pnl.find('.promoted-avatar');
            if ($(nhomAvatar).length < 1) return;
            var img = pnl.find('img');
            var imgBtn = pnl.find('.changeBtn-box');
            var anh = pnl.find('.Anh');
            var param = { 'subAct': 'changeAvatar' };
            //return false;
            new Ajax_upload(jQuery(imgBtn), {
                action: admFn.url.promoted,
                name: 'anh',
                data: param,
                onSubmit: function (file, ext) {
                    if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                        // extension is not allowed
                        alert('Lỗi:\n Kiểu File không Hợp lệ');
                        // cancel upload
                        return false;
                    };
                    return true;
                },
                onComplete: function (file, response) {
                    anh.val(response);
                    img.attr('src', '/lib/up/promoted/' + response + '?ref=' + Math.random());
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }
    }
}