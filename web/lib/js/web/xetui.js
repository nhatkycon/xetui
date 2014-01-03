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
    }
    , url: {
        login: '/lib/ajax/login/default.aspx'
        , account: '/lib/ajax/account/default.aspx'
        , car: '/lib/ajax/car/default.aspx'
    }
    , loginfn: {
        init: function () {
            autoFn.loginfn.loginFb();
            autoFn.loginfn.registerAc();
            autoFn.loginfn.common();
            autoFn.loginfn.loginModal();
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
                            document.location.reload();
                        }
                        finally {
                            document.location.reload();
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
                                    document.location.reload();
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
                            document.location.reload();
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
                           document.location.reload();
                       }
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
                    if (response == '400') {
                        common.fbMsg('Ảnh rộng quá 400px', 'Bạn chọn cái ảnh khác nhỏ hơn 400px bạn nhé...', 200, 'msg-portal-pop-processing', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 1000);
                        });
                    } else {
                        img.attr('src', '/lib/up/users/' + response + '?ref=' + Math.random());
                    }
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
            var RowId = pnl.find('.RowId');
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
                           document.location.href = '/my-cars/';
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
                       document.location.href = '/my-cars/';
                   }
                });
            });

            autoFn.utils.editor(GioiThieu);

            autoFn.carFn.XuLyAnh();
            autoFn.carFn.AnhFn();
        }
        , XuLyAnh: function () {
            var pnl = $('.car-add-pnl');
            if ($(pnl).length < 1) return;
            var viewLarge = pnl.find('.view-large');
            var RowId = pnl.find('.RowId');

            $('#fileupload').fileupload({
                url: autoFn.url.car,
                dataType: 'json',
                dropZone: viewLarge,
                formData: {
                    'subAct': 'upload'
                    , 'Id': RowId.val()
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
                                    autoFn.carFn.XuLyAnhCrop(c, anhItem);
                                },
                                bgColor: 'black',
                                bgOpacity: .4,
                                //minSize: [480, 270],
                                setSelect: [0, 0, 480, 270],
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
                            var url = autoFn.url.car + '?subAct=GetImageMobile&Key=' + anhFix.attr('data-key');
                            anhFix.show();
                            anhFix.addClass('img-responsive');
                            anhFix.attr('src', url);

                        }
                    });
                },
                progressall: function (e, data) {
                    $('#progress').show();
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progress .bar').css(
                    'width',
                    progress + '%'
                );
                }
            });
        }
        , AnhFn: function () {
            var pnl = $('.car-add-pnl');
            if ($(pnl).length < 1) return;

            $('.setBiaBtn').on('click', function () {
                var item = $(this);
                var id = item.attr('data-id');
                var data1 = [];
                data1.push({ name: 'subAct', value: 'SetAnhChinh' });
                data1.push({ name: 'Id', value: id });
                $.ajax({
                    url: autoFn.url.car
                    , type: 'POST'
                    , data: data1
                    , success: function (rs) {
                    }
                });
            });

            $('.removeBtn').on('click', function () {
                var item = $(this);
                var id = item.attr('data-id');
                var con = confirm('Xóa bỏ ảnh?');
                if (!con) return;
                var data1 = [];
                data1.push({ name: 'subAct', value: 'RemoveImage' });
                data1.push({ name: 'Id', value: id });
                $.ajax({
                    url: autoFn.url.car
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
            var data = autoFn.url.car + '?' + el.find(':input').serialize();
            el.find('.anh-fix').attr('src', data + '&subAct=GetImage&ref=' + Math.random());
        }
    }
};

