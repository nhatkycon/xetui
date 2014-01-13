var pmLatestLoadedTimer;
var pmLatestLoadedTimeOut = 10000;
jQuery(function () {
    $('#__VIEWSTATE').remove();
    autoFn.ini();
});

var autoFn = {
    ini: function () {
        autoFn.trackUi();
        autoFn.loginfn.init();
        autoFn.accFn.init();
        autoFn.carFn.init();
        autoFn.binhLuanFn.init();
        autoFn.connect.init();
        autoFn.pmFn.init();
        autoFn.likeFn.init();
        autoFn.XuLyAnhFn.init();
        autoFn.blogFn.init();
        autoFn.nhomFn.init();
    }
    , trackUi: function () {
        var w = $(window).width();
        var h = $(window).height();
        document.title = w + ';' + h;
        window.onresize = function () {
            autoFn.trackUi();
        };
    }
    , utils: {
        editor: function (el) {
            var config = {
                toolbar:
		        [
			        ['Image', 'Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat', 'NumberedList', 'BulletedList'],
		            ['Styles', 'Format', 'Font', 'FontSize', 'TextColor', 'BGColor', 'Link', 'Unlink']
		        ], height: '100px'
            };
            var editor = jQuery(el).ckeditor(config, function () {
                //CKFinder.setupCKEditor(this, '../js/ckfinder/');
            });
        }
        , editorLarge: function (el) {
            var config = {
                toolbar:
		        [
			        ['Image', 'Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat', 'NumberedList', 'BulletedList'],
		            ['Styles', 'Format', 'Font', 'FontSize', 'TextColor', 'BGColor', 'Link', 'Unlink']
		        ], height: '400px'
            };
            var editor = jQuery(el).ckeditor(config, function () {
                //CKFinder.setupCKEditor(this, '../js/ckfinder/');
            });
        }
        , msg: function (tit, txt, fn, time) {
            var body = $('#AlertModal').find('.modal-body');
            var title = $('#AlertModal').find('.modal-title');
            body.html('');
            title.html('');
            if (tit == '') tit = 'Thông báo';
            title.html(tit);
            body.html(txt);
            $('#AlertModal').modal('show');
            if (time == null) time = 2000;
            setTimeout(function () {
                $('#AlertModal').modal('hide');
            }, time);
        }
    }
    , url: {
        login: '/lib/ajax/login/default.aspx'
        , account: '/lib/ajax/account/default.aspx'
        , car: '/lib/ajax/car/default.aspx'
        , binhLuan: '/lib/ajax/binhLuan/default.aspx'
        , thongBao: '/lib/ajax/thongBao/default.aspx'
        , pm: '/lib/ajax/Pm/default.aspx'
        , thich: '/lib/ajax/thich/default.aspx'
        , upload: '/lib/ajax/upload/default.aspx'
        , blog: '/lib/ajax/blog/default.aspx'
        , nhom: '/lib/ajax/nhom/default.aspx'
    }
    , loginfn: {
        init: function () {
            autoFn.loginfn.loginFb();
            autoFn.loginfn.registerAc();
            autoFn.loginfn.common();
            autoFn.loginfn.loginModal();
            autoFn.loginfn.resendActive();
            autoFn.loginfn.recoverFn();
            autoFn.loginfn.recreatingPasswordFn();
        }
        , common: function () {

            var logoutBtn = $('.logoutBtn');
            if ($(logoutBtn).length < 1) return;

            logoutBtn.click(function () {
                var data = { subAct: 'logout' };
                $.ajax({
                    url: autoFn.url.login
                    , data: data
                    , success: function () {
                        try {
                            FB.logout(function () { document.location.reload(); });
                        }
                        catch (err) {
                            //document.location.reload();
                        }
                        finally {
                            setTimeout(function () {
                                document.location.reload();
                            }, 1000);
                        }
                        setTimeout(function () {
                            document.location.reload();
                        }, 2000);
                    }
                });
            });
        }
        , loginModal: function () {
            var pnl = $('.login-form');
            if ($(pnl).length < 1) return;


            var btn = pnl.find('.loginBtn');
            pnl.find(':input').focus(function () {
                var item = $(this);
                item.unbind('keypress').bind('keypress', function (evt) {
                    if (evt.keyCode == 13) {
                        evt.preventDefault();
                        autoFn.loginfn.doLogin();
                        return false;
                    }
                });
            });
            btn.click(function () {
                autoFn.loginfn.doLogin();
            });

            var loginFbbtn = $('.loginFacebook');
            if ($(loginFbbtn).length < 1) return;
            loginFbbtn.click(function () {
                FB.login(function (response) {
                    FB.api('/me', function (res) {
                        var data = {
                            id: res.id
                            , subAct: 'checkFbId'
                        };
                        $.ajax({
                            url: autoFn.url.login
                            , data: data
                            , type: 'POST'
                            , success: function (rs) {
                                if (rs == "0") {
                                    document.location.href = '/Register/';
                                } else {
                                    document.location.reload();
                                }
                            }
                        });

                    });
                }, { scope: 'email' });
            });

        }
        , doLogin: function () {
            var pnl = $('.login-form');
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'subAct', value: 'login' });
            var alertMsg = pnl.find('.alert-danger');
            alertMsg.hide();
            $.ajax({
                url: autoFn.url.login
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // Wrong password, username, e-mail
                           alertMsg.fadeIn();
                           alertMsg.html('Tài khoản sai');
                       } else if (rs == '2') { // Account not actived
                           alertMsg.fadeIn();
                           alertMsg.html('Bạn bị thu bằng lái, có nhẽ chờ một thời gian');
                       } else {
                           document.location.reload();
                       }
                   }
            });
        }
        , loginFb: function () {
            var btn = $('.singupFacebook');
            if ($(btn).length < 1) return;
            btn.click(function () {
                FB.login(function (response) {
                    FB.api('/me', function (res) {
                        autoFn.loginfn.registerFbAc(res);
                    });
                }, { scope: 'email' });
            });

            if (logged) return;

            FB.Event.subscribe('auth.authResponseChange', function (response) {
                if (response.status === 'connected') {
                    FB.api('/me', function (res) {
                        var data = {
                            id: res.id
                            , subAct: 'checkFbId'
                        };
                        $.ajax({
                            url: autoFn.url.login
                            , data: data
                            , type: 'POST'
                            , success: function (rs) {
                                if (rs == "0") {
                                    autoFn.loginfn.registerFbAc(res);
                                } else {
                                    document.location.href = '/acc/';
                                }
                            }
                        });

                    });
                }
                else {
                    //UNKNOWN ERROR. Logged Out
                }
            });
        }
        , registerFbAc: function (res) {
            var pnl = $('.register-pnl');
            var step2 = pnl.find('.step-2');
            var step1 = pnl.find('.step-1');

            step1.hide();
            step2.fadeIn();

            var email = res.email;
            var name = res.name;
            var id = res.id;
            var username = res.username;
            var verified = res.verified;


            var Ten = step2.find('#Ten1');
            var imgEl = step2.find('img');
            var emailEl = step2.find('#Email2');
            var btn = step2.find('.signup-done-btn');
            var alertMsg = step2.find('.alert-danger');
            emailEl.val(email);
            Ten.val(name);
            imgEl.attr('src', 'http://graph.facebook.com/' + id + '/picture');


            btn.click(function () {
                var dongY = step2.find('#dongY').is(':checked');
                if (!dongY) {
                    alertMsg.fadeIn();
                    alertMsg.html('Bạn vui lòng đồng ý với các điều khoản trước khi nhận bằng lái');
                    return;
                }

                alertMsg.hide();
                name = Ten.val();
                var data = {
                    email: email
                    , name: name
                    , id: id
                    , username: username
                    , subAct: 'signupFb'
                };
                $.ajax({
                    url: autoFn.url.login
                    , data: data
                    , type: 'POST'
                    , success: function (rs) {
                        if (rs == '2') { // E-mail or username is not avaiable
                            alertMsg.fadeIn();
                            alertMsg.html('E-mail: <strong>' + email + '</strong> đã dùng bởi tài xế khác');
                        } else if (rs == '0') { // Facebook account already created
                            alertMsg.fadeIn();
                            alertMsg.html('Facebook này đã tạo tài khoản rồi');
                        } else {
                            document.location.href = '/Register-Success/';
                        }
                    }
                });
            });

        }
        , registerAc: function () {
            var pnl = $('.register-pnl');
            if ($(pnl).length < 1) return;
            var step1 = pnl.find('.step-1');
            step1.find(':input').val('');
            var alertMsg = step1.find('.alert-danger');

            var btn = step1.find('.dangKyBtn');
            btn.click(function () {
                var dongY = step1.find('#dongY').is(':checked');
                if (!dongY) {
                    alertMsg.fadeIn();
                    alertMsg.html('Bạn vui lòng đồng ý với các điều khoản trước khi nhận bằng lái');
                    return;
                }
                alertMsg.hide();

                var data = step1.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'signup' });
                $.ajax({
                    url: autoFn.url.login
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '2') { // E-mail or username is not avaiable
                           alertMsg.fadeIn();
                           alertMsg.html('E-mail đã dùng bởi tài xế khác');
                       } else if (rs == '0') { // Captcha wrong
                           alertMsg.fadeIn();
                           alertMsg.html('Mã xác nhận sai');
                       } else if (rs == '3') { // Thiếu các trường cơ bản
                           alertMsg.fadeIn();
                           alertMsg.html('Nhập đủ tên, e-mail xịn và mật khẩu nhé');
                       } else {
                           document.location.href = '/Register-Success/';
                       }
                   }
                   , error: function () {
                       alertMsg.fadeIn();
                       alertMsg.html('Có lỗi, vui lòng thử lại sau nhé');
                   }
                });

            });


        }
        , resendActive: function () {
            var btn = $('.btnResendEmail');
            if ($(btn).length < 1) return;

            btn.click(function () {
                var data = {
                    subAct: 'reSendActive'
                };
                $.ajax({
                    url: autoFn.url.login
                    , data: data
                    , type: 'POST'
                    , success: function (rs) {
                        autoFn.utils.msg('Gửi xác nhận thành công', 'Bạn vui lòng kiểm tra lại hòm thư sau vài phút', null, 3000);
                    }
                });
            });
        }
        , recoverFn: function () {
            var pnl = $('.recoverPasswordPnl');
            if ($(pnl).length < 1) return;

            var btn = pnl.find('.saveBtn');
            var txt = pnl.find('.Email');

            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');
            btn.click(function () {
                alertErr.hide();
                alertOk.hide();
                var val = txt.val();
                if (val == '') {
                    alertErr.show();
                    alertErr.html('Nhập E-mail');
                    return;
                }
                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'recover-sendEmail' });
                data.push({ name: 'cUrl', value: document.location.href });
                btn.hide();
                $.ajax({
                    url: autoFn.url.login
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       btn.show();
                       if (rs == '0') {
                           alertErr.show();
                           alertErr.html('E-mail không tồn tại trên Xetui.vn');
                       } else if (rs == '2') {
                           alertErr.show();
                           alertErr.html('Tài khoản này chưa xác nhận E-mail nên chúng tôi không thể giúp bạn khôi phục mật khẩu');
                       }
                       else {
                           alertOk.show();
                           alertOk.html('Kiểm tra E-mail của bạn để khôi phục lại mật khẩu');
                       }
                       txt.val('');
                   }
                   , error: function () {
                       btn.show();
                       alertErr.show();
                       alertErr.html('Lỗi gì đó, thử lại sau bạn nhé');
                   }
                });
            });
        }, recreatingPasswordFn: function () {
            var pnl = $('.recoverSavePasswordPnl');
            if ($(pnl).length < 1) return;

            var btn = pnl.find('.savePwdBtn');
            var txt = pnl.find('.Pwd');
            var id = btn.attr('data-id');

            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');
            btn.click(function () {
                alertErr.hide();
                alertOk.hide();
                var val = txt.val();
                if (val == '') {
                    alertErr.show();
                    alertErr.html('Nhập E-mail');
                    return;
                }
                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'recover-newPassword' });
                data.push({ name: 'id', value: id });
                data.push({ name: 'cUrl', value: document.location.href });
                btn.hide();
                $.ajax({
                    url: autoFn.url.login
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       btn.show();
                       if (rs == '0') {
                           alertErr.show();
                           alertErr.html('E-mail không tồn tại trên Xetui.vn');
                       } else if (rs == '2') {
                           alertErr.show();
                           alertErr.html('Tài khoản này chưa xác nhận E-mail nên chúng tôi không thể giúp bạn khôi phục mật khẩu');
                       }
                       else {
                           alertOk.show();
                           alertOk.html('Khôi phục mật khẩu thành công');
                           setTimeout(function () {
                               document.location.href = '/acc/';
                           }, 2000);
                       }
                       txt.val('');
                   }
                   , error: function () {
                       btn.show();
                       alertErr.show();
                       alertErr.html('Lỗi gì đó, thử lại sau bạn nhé');
                   }
                });
            });
        }
    }
    , accFn: {
        init: function () {
            autoFn.accFn.changeAvatar();
            autoFn.accFn.saveInformation();
        }
        , changeAvatar: function () {
            var pnl = $('.myAccount-avatar');
            if ($(pnl).length < 1) return;
            var img = pnl.find('img');
            var btn = pnl.find('.changeBtn-box');
            var param = { 'subAct': 'changeAvatar' };
            //return false;
            new Ajax_upload(jQuery(btn), {
                action: autoFn.url.account,
                name: 'anh',
                data: param,
                onSubmit: function (file, ext) {
                    if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                        // extension is not allowed
                        alert('Lỗi:\n Kiểu File không Hợp lệ');
                        // cancel upload
                        return false;
                    }
                    ;
                },
                onComplete: function (file, response) {
                    img.attr('src', '/lib/up/users/' + response + '?ref=' + Math.random());
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
        , saveInformation: function () {
            var pnl = $('.myAccount-form');
            if ($(pnl).length < 1) return;
            var btn = pnl.find('.saveBtn');
            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');

            btn.click(function () {
                alertErr.hide();
                alertOk.hide();

                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'saveInformation' });
                $.ajax({
                    url: autoFn.url.account
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                       }
                   }
                });
            });
        }
    }
    , carFn: {
        init: function () {
            autoFn.carFn.AddCar();
        }
        , AddCar: function () {
            var pnl = $('.car-add-pnl');
            if ($(pnl).length < 1) return;

            var HANG_ID = pnl.find('.HANG_ID');
            var MODEL_ID = pnl.find('.MODEL_ID');
            var GioiThieu = pnl.find('.GioiThieu');

            var btn = pnl.find('.saveBtn');
            var xoaBtn = pnl.find('.xoaBtn');

            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');

            //GetModelByHangXe
            HANG_ID.bind('click', function () {
                var id = $(this).val();
                var data = [];
                data.push({ name: 'subAct', value: 'GetModelByHangXe' });
                data.push({ name: 'DM_PID', value: id });
                MODEL_ID.find('option').remove();
                MODEL_ID.html('<option>...</option>');
                $.ajax({
                    url: autoFn.url.car
                    , type: 'POST'
                    , data: data
                    , dataType: 'SCRIPT'
                   , success: function (rs) {
                       MODEL_ID.find('option').remove();
                       var models = JSON.parse(rs);
                       MODEL_ID.find('option').remove();
                       $.each(models, function (i, item) {
                           var modelItem = $('#model-item').tmpl(item).prependTo(MODEL_ID);
                       });
                   }
                });
            });

            btn.click(function () {
                var data = pnl.find('.car-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });
                var anh = $("input:radio[name ='AnhBia']:checked").attr('data-src');
                if (anh != '') {
                    data.push({ name: 'Anh', value: anh });
                }
                $.ajax({
                    url: autoFn.url.car
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           if (admMode) {
                           } else {
                               document.location.href = '/my-cars/';
                               
                           }
                       }
                   }
                });
            });

            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa xe?');
                if (!con) return;

                var data = pnl.find('.car-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: autoFn.url.car
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (admMode) {
                           document.location.href = '/lib/mod/cars/';
                       } else {
                           document.location.href = '/my-cars/';                           
                       }
                   }
                });
            });

            autoFn.utils.editor(GioiThieu);

        }        
    }
    , blogFn: {
        init: function () {
            autoFn.blogFn.Add();
            autoFn.blogFn.CommonFn();
        }
        , Add: function () {
            var pnl = $('.blog-add-pnl');
            if ($(pnl).length < 1) return;
            var btn = pnl.find('.saveBtn');
            var xoaBtn = pnl.find('.xoaBtn');
            var txt = pnl.find('.Ten');
            var noiDung = pnl.find('.NoiDung');

            autoFn.utils.editorLarge(noiDung);

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
                var data = pnl.find('.blog-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });
                var anh = $("input:radio[name ='AnhBia']:checked").attr('data-src');
                if (anh != '') {
                    data.push({ name: 'Anh', value: anh });
                }
                $.ajax({
                    url: autoFn.url.blog
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           setTimeout(function() {
                               //document.location.href = rs;
                           }, 1000);
                       }
                   }
                });
            });

            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa xe?');
                if (!con) return;

                var data = pnl.find('.blog-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: autoFn.url.blog
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       document.location.href = '/my-cars/';
                   }
                });
            });
        }
        , CommonFn: function () {
            var ref = document.referrer;
            console.log(ref);
        }
    }
    , nhomFn: {
        init:function () {
            autoFn.nhomFn.addFn();
            autoFn.nhomFn.CommonFn();
        }
        ,addFn:function() {
            var pnl = $('.nhom-add-pnl');
            if ($(pnl).length < 1) return;
            var btn = pnl.find('.saveBtn');
            var xoaBtn = pnl.find('.xoaBtn');
            var txt = pnl.find('.Ten');
            var moTa = pnl.find('.MoTa');
            var gioiThieu = pnl.find('.GioiThieu');

            autoFn.utils.editorLarge(gioiThieu);

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
                
                var dongY = pnl.find('#dongY').is(':checked');
                if (!dongY) {
                    alertErr.fadeIn();
                    alertErr.html('Bạn vui lòng đồng ý với các điều khoản trước khi tạo nhóm');
                    return;
                }


                var data = pnl.find('.nhom-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });
                
                $.ajax({
                    url: autoFn.url.nhom
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Nhập tên cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           if (admMode) {
                           } else {
                               setTimeout(function () {
                                   //document.location.href = rs;
                               }, 1000);
                           }
                       }
                   }
                });
            });
            
            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa nhóm?');
                if (!con) return;

                var data = pnl.find('.nhom-add-form').find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: autoFn.url.nhom
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       //document.location.href = '/my-cars/';
                       if (admMode) {
                       } else {
                           setTimeout(function () {
                               //document.location.href = rs;
                           }, 1000);
                       }
                   }
                });
            });

            var nhomAvatar = pnl.find('.nhom-avatar');
            if ($(nhomAvatar).length < 1) return;
            var img = pnl.find('img');
            var imgBtn = pnl.find('.changeBtn-box');
            var anh = pnl.find('.Anh');
            var param = { 'subAct': 'changeAvatar' };
            //return false;
            new Ajax_upload(jQuery(imgBtn), {
                action: autoFn.url.nhom,
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
                    img.attr('src', '/lib/up/nhom/' + response + '?ref=' + Math.random());
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
        ,CommonFn:function() {
            var pnl = $('.nhomList-box');
            if ($(pnl).length < 1) return;
            var header = $('.nhomList-header');
            var tbl = pnl.find('table');
            tbl.tablesorter();
            header.find('.btn-sort').click(function () {
                var item = $(this);
                console.log(item);
                var index = parseInt(item.attr('data-sort'));
                console.log(index);
                var sorting = [[1, 1]];
                // sort on the first column
                tbl.trigger("sorton", [sorting]);
                // return false to stop default link action
            });
        }
    }
    , XuLyAnhFn: {
        init: function name() {
            autoFn.XuLyAnhFn.XuLyAnh();
            autoFn.XuLyAnhFn.AnhFn();
        }
        , XuLyAnh: function () {
            var pnl = $('.upload-anh-box');
            if ($(pnl).length < 1) return;
            var viewLarge = pnl.find('.view-large');
            var rowId = pnl.attr('data-id');

            $('#fileupload').fileupload({
                url: autoFn.url.upload,
                dataType: 'json',
                dropZone: viewLarge,
                formData: {
                    'subAct': 'upload'
                    , 'Id': rowId
                },
                done: function (e, data) {
                    $('#progress').hide();
                    $.each(data.result.files, function (index, file) {
                        var anhItem = $('#anh-item').tmpl(file).prependTo(viewLarge);
                        var apply = anhItem.find('.apply');

                        var windowWidth = $(window).width();
                        if (windowWidth > 1024) {
                            anhItem.find('.anh-img').Jcrop({
                                onSelect: function (c) {
                                    autoFn.XuLyAnhFn.XuLyAnhCrop(c, anhItem);
                                },
                                bgColor: 'black',
                                bgOpacity: .4,
                                //minSize: [480, 270],
                                setSelect: [0, 0, 960, 540],
                                aspectRatio: 16 / 9
                            });
                            apply.click(function () {
                                anhItem.find('.anh-fix').show();
                                anhItem.find('.anh-img').hide();
                                anhItem.find('.jcrop-holder').hide();
                                apply.hide();
                            });
                        } else {
                            apply.hide();
                            anhItem.find('.anh-img').hide();
                            var anhFix = anhItem.find('.anh-fix');
                            var url = autoFn.url.upload + '?subAct=GetImageMobile&Key=' + anhFix.attr('data-key');
                            anhFix.show();
                            anhFix.addClass('img-responsive');
                            anhFix.attr('src', url);

                        }
                    });
                },
                progressall: function (e, data) {
                    $('#progress').show();
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progress').find('.progress-bar').css(
                    'width',
                    progress + '%'
                );
                }
            });
        }
        , AnhFn: function () {
            var pnl = $('.upload-anh-box');
            if ($(pnl).length < 1) return;

            pnl.on('click', '.setBiaBtn', function () {
                var item = $(this);
                var id = item.attr('data-id');
                var data1 = [];
                data1.push({ name: 'subAct', value: 'SetAnhChinh' });
                data1.push({ name: 'Id', value: id });
                $.ajax({
                    url: autoFn.url.upload
                    , type: 'POST'
                    , data: data1
                    , success: function (rs) {
                    }
                });
            });

            pnl.on('click', '.removeBtn', function () {
                var item = $(this);
                var id = item.attr('data-id');
                var con = confirm('Xóa bỏ ảnh?');
                if (!con) return;
                var data1 = [];
                data1.push({ name: 'subAct', value: 'RemoveImage' });
                data1.push({ name: 'Id', value: id });
                $.ajax({
                    url: autoFn.url.upload
                    , type: 'POST'
                    , data: data1
                    , success: function (rs) {
                        item.parent().parent().remove();
                    }
                });
            });
        }
        , XuLyAnhCrop: function (c, el) {
            el.find('.x').val(Math.round(c.x));
            el.find('.y').val(Math.round(c.y));
            el.find('.x1').val(c.x2);
            el.find('.y1').val(c.y2);
            el.find('.w').val(Math.round(c.w));
            el.find('.h').val(Math.round(c.h));
            var data = autoFn.url.upload + '?' + el.find(':input').serialize();
            el.find('.anh-fix').attr('src', data + '&subAct=GetImage&ref=' + Math.random());
        }
    }
    , binhLuanFn: {
        init: function () {
            autoFn.binhLuanFn.postFn();
            autoFn.binhLuanFn.replyFn();
        }
        , postFn: function () {
            var pnl = $('.binhLuanPostBox');
            if ($(pnl).length < 1) return;
            var binhLuanItems = $('.binhLuan-Items');
            var btn = pnl.find('.saveBtn');
            var txt = pnl.find('.txt');

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
                data.push({ name: 'cUrl', value: document.location.href });
                btn.hide();
                $.ajax({
                    url: autoFn.url.binhLuan
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       btn.show();
                       txt.val('');
                       var newItem = $(rs).prependTo(binhLuanItems);
                       newItem.addClass('animated bounceInDown');
                       setTimeout(function () {
                           newItem.removeClass('animated bounceInDown');
                       }, 1000);
                   }
                   , error: function () {
                       btn.show();
                       alertErr.show();
                       alertErr.html('Lỗi gì đó, thử lại sau bạn nhé');
                   }
                });
            });

        }
        , replyFn: function () {
            var pnl = $('.binhLuan-ListBox');
            if ($(pnl).length < 1) return;
            var replyPnl = $('.binhLuanReplyBox');

            pnl.on('click', '.replyBtn', function () {
                var item = $(this);
                var footer = item.parent().parent();
                var binhLuanItem = footer.parent();

                var pRowId = item.attr('data-pRowId');
                var pid = item.attr('data-pid');
                var newReplyPnl = binhLuanItem.find('.binhLuanReplyBox');
                if ($(newReplyPnl).length < 1) {
                    newReplyPnl = replyPnl.clone().insertAfter(footer);
                }
                newReplyPnl.show();
                newReplyPnl.find('.PBL_ID').val(pid);

                var txt = newReplyPnl.find('.txt');
                var btn = newReplyPnl.find('.replySaveBtn');
                btn.click(function () {
                    var val = txt.val();
                    if (val == '') {
                        autoFn.utils.msg('Thông báo', 'Nhập nội dung bình luận nhé');
                        return;
                    }

                    var data = newReplyPnl.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'save' });
                    data.push({ name: 'cUrl', value: document.location.href });
                    btn.hide();
                    $.ajax({
                        url: autoFn.url.binhLuan
                        , type: 'POST'
                        , data: data
                       , success: function (rs) {
                           btn.show();
                           //autoFn.utils.msg('Thành công', 'Bình luận đã được gửi thành công',null,100);
                           txt.val('');
                           var newItem = $(rs).insertAfter(newReplyPnl);
                           newItem.addClass('animated bounceInDown');
                           setTimeout(function () {
                               newItem.removeClass('animated bounceInDown');
                           }, 1000);
                           newReplyPnl.remove();
                       }
                       , error: function () {
                           btn.show();
                           autoFn.utils.msg('Thông báo', 'Đang lỗi, vui lòng thử lại sau ít phút');
                       }
                    });
                });

            });

            pnl.on('click', '.removeBlBtn', function () {
                var item = $(this);
                var id = item.attr('data-id');
                var con = confirm('Bạn muốn xóa bỏ bình luận này?');
                if (!con) return;

                var data = [];
                data.push({ name: 'subAct', value: 'remove' });
                data.push({ name: 'Id', value: id });
                $.ajax({
                    url: autoFn.url.binhLuan
                        , type: 'POST'
                        , data: data
                       , success: function (rs) {
                           var binhLuanItem = item.parent().parent().parent();
                           binhLuanItem.addClass('animated bounceOutRight');
                           setTimeout(function () {
                               binhLuanItem.remove();
                           }, 500);
                       }
                       , error: function () {
                           autoFn.utils.msg('Thông báo', 'Đang lỗi, vui lòng thử lại sau ít phút');
                       }
                });


            });
        }
    }
    , pmFn: {
        init: function () {
            autoFn.pmFn.addFn();
            autoFn.pmFn.manageFn();
        }
        , addFn: function () {
            $(document).on('click', '.pmBtn', function () {
                var item = $(this);
                var toUser = item.attr('data-user');
                var pnl = $('#pmPostBoxModal');
                if ($(pnl).length < 1) return;

                var btn = pnl.find('.saveBtn');
                var txt = pnl.find('.txt');
                var toUserEl = pnl.find('.toUser');
                toUserEl.val(toUser);

                $('#pmPostBoxModal').modal('show');

                var alertErr = pnl.find('.alert-danger');
                var alertOk = pnl.find('.alert-success');

                btn.unbind('click').click(function () {
                    alertErr.hide();
                    alertOk.hide();
                    var val = txt.val();
                    if (val == '') {
                        alertErr.show();
                        alertErr.html('Nhập nội dung bạn ơi');
                        return;
                    }
                    var data = pnl.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'add' });
                    data.push({ name: 'cUrl', value: document.location.href });
                    btn.hide();
                    $.ajax({
                        url: autoFn.url.pm
                        , type: 'POST'
                        , data: data
                       , success: function (rs) {
                           btn.show();
                           txt.val('');
                           $('#pmPostBoxModal').modal('hide');
                           autoFn.utils.msg('Thành công', 'Bạn đã gửi tin nhắn thành công', null, 1000);
                       }
                       , error: function () {
                           btn.show();
                           alertErr.show();
                           alertErr.html('Lỗi gì đó, thử lại sau bạn nhé');
                       }
                    });

                });

            });

        }
        , manageFn: function () {
            var pnl = $('.PmRooms');
            if ($(pnl).length < 1) return;
            var pmContainer = $('.PmContainer');
            pnl.find('.PmRoom-Item').click(function () {
                var item = $(this);
                var id = item.attr('data-id');
                var data = [];
                data.push({ name: 'subAct', value: 'getPmBox' });
                data.push({ name: 'Id', value: id });
                pmContainer.html('Nạp...');
                $.ajax({
                    url: autoFn.url.pm
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       pmContainer.html(rs);
                       var pmList = pmContainer.find('.PmList');
                       var bottom = pmList.find('.PmList-bottom');
                       pmList.scrollTo(bottom);
                   }
                });
                autoFn.pmFn.getNewest();
            });

            $(pmContainer).on('click', '.btnSendPm', function () {
                var item = $(this);
                var pmPost = item.parent().parent().parent();
                var toUser = item.attr('data-toUser');
                var id = item.attr('data-id');
                var txt = pmPost.find('.txt');

                var val = txt.val();
                if (val == '') {
                    return;
                }
                var data = pmPost.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'add' });
                data.push({ name: 'toUser', value: toUser });
                data.push({ name: 'cUrl', value: document.location.href });
                item.hide();
                $.ajax({
                    url: autoFn.url.pm
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       item.show();
                       txt.val('');
                       if (pmLatestLoadedTimer) clearTimeout(pmLatestLoadedTimer);
                       autoFn.pmFn.getNewest();
                   }
                   , error: function () {
                       if (pmLatestLoadedTimer) clearTimeout(pmLatestLoadedTimer);
                       autoFn.pmFn.getNewest();
                       item.show();
                       autoFn.utils.msg('Lỗi gì đó', 'Lỗi gì đó, thử lại sau bạn nhé', null, 1000);
                   }
                });
            });


            $(pmContainer).on('click', '.pm-item-more', function () {
                var item = $(this);
                var roomId = item.attr('data-roomId');
                var id = item.attr('data-id');
                item.remove();
                var data = [];
                data.push({ name: 'subAct', value: 'getPmList-More' });
                data.push({ name: 'Id', value: roomId });
                data.push({ name: 'fromId', value: id });
                $.ajax({
                    url: autoFn.url.pm
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       var pmList = pmContainer.find('.PmList');
                       $(rs).prependTo(pmList);
                       pmList.scrollTo(0);
                   }
                   , error: function () {

                   }
                });
            });

        }
        , getNewest: function () {
            var item = $('.pm-item-lastest');
            if ($(item).length < 1) {
                if (pmLatestLoadedTimer) clearTimeout(pmLatestLoadedTimer);
                pmLatestLoadedTimer = setTimeout(function () {
                    autoFn.pmFn.getNewest();
                }, pmLatestLoadedTimeOut);
                return;
            };

            var roomId = item.attr('data-roomId');
            var id = item.attr('data-id');
            item.remove();
            var pmList = $('.PmList');
            var data = [];
            data.push({ name: 'subAct', value: 'getPmList-Latest' });
            data.push({ name: 'Id', value: roomId });
            data.push({ name: 'fromId', value: id });
            $.ajax({
                url: autoFn.url.pm
                , type: 'POST'
                , data: data
               , success: function (rs) {
                   $(rs).appendTo(pmList);
                   var bottom = pmList.find('.PmList-bottom');
                   pmList.scrollTo(bottom);
                   if (pmLatestLoadedTimer) clearTimeout(pmLatestLoadedTimer);
                   pmLatestLoadedTimer = setTimeout(function () {
                       autoFn.pmFn.getNewest();
                   }, pmLatestLoadedTimeOut);
               }
               , error: function () {
                   if (pmLatestLoadedTimer) clearTimeout(pmLatestLoadedTimer);
                   pmLatestLoadedTimer = setTimeout(function () {
                       autoFn.pmFn.getNewest();
                   }, pmLatestLoadedTimeOut);
               }
            });
        }
    }
    , connect: {
        init: function () {
            if (!logged || admMode) return;
            autoFn.connect.notifications();
            autoFn.connect.messages();
        }
        , notifications: function () {
            var notibox = $('.notibox');
            var msgbox = $('.msgbox');
            if (!logged)
                return;
            var data = [];
            data.push({ name: 'subAct', value: 'notifications' });
            $.ajax({
                url: autoFn.url.thongBao
                , type: 'POST'
                , data: data
                , dataType: 'SCRIPT'
               , success: function (rs) {
                   var counts = eval(rs);
                   var totalNoti = parseInt(counts[0]);
                   var totalMsg = parseInt(counts[1]);

                   if (totalNoti > 0) {
                       var bubble = notibox.find('.notificationBubble');
                       notibox.addClass('notification-active');
                       bubble.html(totalNoti);
                       var oldTotal = parseInt(bubble.attr('data-total'));

                       bubble.attr('data-total', totalNoti);
                       if (totalNoti != oldTotal) {
                           bubble.addClass('animated bounceInDown');
                           setTimeout(function () {
                               bubble.removeClass('animated bounceInDown');
                           }, 10000);
                       }

                   } else {
                       notibox.removeClass('notification-active');
                   }


                   if (totalMsg > 0) {
                       var bubbleMsg = msgbox.find('.notificationBubble');
                       msgbox.addClass('notification-active');
                       bubbleMsg.html(totalMsg);
                       var oldTotalMsg = parseInt(bubbleMsg.attr('data-total'));

                       bubbleMsg.attr('data-total', totalMsg);
                       if (totalMsg != oldTotalMsg) {
                           bubbleMsg.addClass('animated bounceInDown');
                           setTimeout(function () {
                               bubbleMsg.removeClass('animated bounceInDown');
                           }, 10000);
                       }

                   } else {
                       msgbox.removeClass('notification-active');
                   }

                   setTimeout(function () {
                       autoFn.connect.notifications();
                   }, 10000);
               }
               , error: function () {
                   setTimeout(function () {
                       autoFn.connect.notifications();
                   }, 10000);
               }
            });

            notibox.find('a.dropdown-toggle').unbind('click').click(function () {
                var items = notibox.find('.dropdown-menu');
                items.html('Đang nạp');
                var data1 = [];
                data1.push({ name: 'subAct', value: 'notifications-get' });
                $.ajax({
                    url: autoFn.url.thongBao
                    , type: 'POST'
                    , data: data1
                   , success: function (rs) {
                       items.html(rs);
                   }
                   , error: function () {

                   }
                });
            });

        }
        , messages: function () {
        }
    }
    , likeFn: {
        init: function () {
            autoFn.likeFn.likeXeFn();
            autoFn.likeFn.likeOtherFn();
        }
        , likeXeFn: function () {

            $(document).on('click', '.likeBtn', function () {
                if (!logged)
                    return;
                var item = $(this);
                var id = item.attr('data-id');
                var loai = item.attr('data-loai');
                var liked = item.hasClass('liked');

                if (liked) {
                    item.removeClass('liked');
                    item.removeClass('btn-default');
                    item.addClass('btn-primary');
                    item.find('i').removeClass('glyphicon-star');
                    item.find('i').addClass('glyphicon-star-empty');
                    item.find('span').html('Thích');

                } else {
                    item.addClass('liked');
                    item.removeClass('btn-primary');
                    item.addClass('btn-default');
                    item.find('i').removeClass('glyphicon-star-empty');
                    item.find('i').addClass('glyphicon-star');
                    item.find('span').html('Đã thích');
                }
                $.ajax({
                    url: autoFn.url.thich
                    , data: {
                        subAct: 'like',
                        ID: id,
                        Liked: liked,
                        Loai: loai
                    },
                    success: function () {

                    }
                });
            });
        }
        , likeOtherFn: function () {
        }
    }
};

