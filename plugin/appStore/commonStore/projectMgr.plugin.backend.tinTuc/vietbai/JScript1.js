﻿var vbtinfn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=projectMgr.plugin.backend.tinTuc.vietbai.Class1, projectMgr.plugin.backend.tinTuc',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#vbtinmdl-List').jqGrid({
                    url: vbtinfn.urlDefault + '&subAct=get&Lang=' + Lang,
                    height: 'auto',
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', '_ID', 'Lang', '#', 'Ảnh', 'Tiêu đề', 'Tóm tắt', 'Mục tin', 'Nguồn', 'Lần đọc', 'Người viết', 'Ngày tạo', 'Kích hoạt', 'Hot', 'Hết hạn'],
                    colModel: [
            { name: 'TIN_ID', key: true, sortable: true, hidden: true },
             { name: 'LangBased', key: true, sortable: true, hidden: true },
            { name: '_TIN_ID', key: true, sortable: true, hidden: true },
            { name: 'TIN_Lang', width: 30, sortable: true, align: "center" },
            { name: 'TIN_ThuTu', width: 20, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TIN_Anh', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'TIN_Ten', width: 120, resizable: true, sortable: true },
            { name: 'TIN_MoTa', width: 180, resizable: true, sortable: true },
            { name: 'TIN_DM_Ten', width: 100, sortable: true },
            { name: 'TIN_Nguon', width: 50, sortable: true },
            { name: 'TIN_Views', width: 30, resizable: true, sortable: true, hidden: true },
            { name: 'TIN_NguoiTao', width: 50, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TIN_NgayCapNhat', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'TIN_Active', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_Hot', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_HetHan', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox' }
        ],
                    caption: 'Danh sách tin',
                    autowidth: true,
                    sortname: 'TIN_NgayCapNhat',
                    sortorder: 'desc',
                    rowNum: 10,
                    rowList: [10, 20, 50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    pager: jQuery('#vbtinmdl-Pagerql'),
                    onSelectRow: function (rowid) {

                    },
                    loadComplete: function () {
                        adm.loading(null);
                        $.getScript('../js/ajaxupload.js', function () { });
                        //adm.regQS(searchTxt, 'vbtinmdl-List');
                        var txtfilter = $('.mdl-head-vbfilterdanhmuc');
                        adm.watermarks(txtfilter, 'Gõ tên mục tin để lọc', function () {
                        });
                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBasedByMaDanhMuc("TIN_TUC", txtfilter, function (event, ui) {
                                //    $(txtfilter).val(ui.item.label);
                                $(txtfilter).attr('_value', ui.item.id);
                                vbtinfn.search();
                            });
                            //                        });
                            //                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            //                            danhmuc.autoCompleteByLoaiLang('TIN-DM', txtfilter, function (event, ui) {
                            //                                $(txtfilter).val(ui.item.label);
                            //                                $(txtfilter).attr('_value', ui.item.id);
                            //                                vbtinfn.search();
                            //                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });
                        });
                        adm.regQS($('.mdl-head-search-danhmuc'), 'vbtinmdl-List');

                    },

                    grouping: false,
                    groupingView: {
                        groupField: ['TIN_DM_Ten'],
                        groupColumnShow: [true],
                        groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                        groupCollapse: false,
                        groupOrder: ['asc'],
                        groupSummary: [true],
                        groupColumnShow: [false],
                        groupDataSorted: true
                    }
                });

                var filterLoaiDanhMucID = $('.mdl-head-vbfilterdanhmuc');
                var searchTxt = $('.mdl-head-search-tin');

                $('.mdl-head-vbfilterdanhmuc').keyup(function () {
                    if ($('.mdl-head-vbfilterdanhmuc').val() == '') {
                        $('.mdl-head-vbfilterdanhmuc').attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                            $(searchTxt).val('');
                        }
                        vbtinfn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin tức');
                        }
                    }
                });

                $('.mdl-head-search-tin').keyup(function () {
                    vbtinfn.search();
                });

                adm.watermark(searchTxt, 'Tìm kiếm tin tức', function () {
                    $(searchTxt).val('');
                    vbtinfn.search();
                    $(searchTxt).val('Tìm kiếm tin tức');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                        $(searchTxt).val('');
                    }
                    vbtinfn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin tức');
                    }
                });
                var changeLangBtn = $('#vbTintucdl-changeLangSlt');
                $(changeLangBtn).find('option').remove();
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                $(changeLangBtn).val(Lang);
            });
        });
    },
    add: function () {

        vbtinfn.loadHtml(function () {
            var newDlg = $('#vbtinmdl-dlgNew');

            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                position: [200, 0],
                buttons: {
                    'Lưu': function () {
                        vbtinfn.save(false, function () {
                            vbtinfn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        vbtinfn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    vbtinfn.clearform();
                    vbtinfn.addpopfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
                ,
                beforeclose: function () {
                    vbtinfn.clearform();
                }
            });
        });
    },
    addLang: function () {

        var s = '';
        if (jQuery('#vbtinmdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#vbtinmdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#vbtinmdl-List").jqGrid('getRowData', s);

                var _TIN_ID = treedata.TIN_ID;

                vbtinfn.loadHtml(function () {
                    var newDlg = $('#vbtinmdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        height: 500,
                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                vbtinfn.save(false, function () {
                                    vbtinfn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                vbtinfn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {
                            vbtinfn.clearform();
                        },
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            vbtinfn.clearform();
                            vbtinfn.addpopfn();
                            var LangBased_ID = $('.LangBased_ID', newDlg);
                            LangBased_ID.val(s);
                            var LangBased = $('.LangBased', newDlg);
                            $(LangBased).removeAttr('checked');
                            $.ajax({
                                url: vbtinfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': _TIN_ID
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#vbtinmdl-dlgNew');
                                    //file uploadTintuc
                                    var lbladm_uploadTintuc_fileLists = $('.adm-uploadTintuc-fileLists', newDlg);
                                    //                                    var txtID = $('.ID', newDlg);
                                    //                                    $(txtID).val(data.ID);
                                    //                                    $(txtID).attr('_value', data.RowId);
                                    // var LangBased = $('.LangBased', newDlg);
                                    //var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    //  var LangSlt = $('.Lang', newDlg);

                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var txtPID = $('.DMID', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);

                                    LangBased_ID.val(data.LangBased_ID);
                                    //                                    if (data.LangBased) {
                                    //                                        $(LangBased).attr('checked', 'checked');
                                    //                                    }
                                    //                                    else {
                                    //                                        $(LangBased).removeAttr('checked');
                                    //                                    }

                                    Alias.val(data.Alias);
                                    KeyWords.val(data.KeyWords);
                                    Description.val(data.Description);
                                    var txtNguon = $('.Nguon', newDlg);
                                    $(txtNguon).val(data.Nguon);

                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDungvb_tt = $('.NoiDungvb_tt', newDlg);

                                    $(txtNoiDungvb_tt).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-uploadTintuc-vbpreview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/Tintuc/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var ckbHot = $('.Hot', newDlg);
                                    if (data.Hot.toString() == 'true') {
                                        $(ckbHot).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHot).removeAttr('checked');
                                    }
                                    var ckbPublish = $('.Publish', newDlg);
                                    if (data.Active.toString() == 'true') {
                                        $(ckbPublish).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbPublish).removeAttr('checked');
                                    }

                                    var ckbHetHan = $('.HetHan', newDlg);
                                    if (data.HetHan.toString() == 'true') {
                                        $(ckbHetHan).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHetHan).removeAttr('checked');
                                    }
                                    var txtNgayHetHan = $('.NgayHetHan', newDlg)
                                    var _ngayHetHan = new Date(data.NgayHetHan);

                                    checkdate = '';
                                    checkdate = _ngayHetHan.getDate() + '/' + (_ngayHetHan.getMonth() + 1) + '/' + (_ngayHetHan.getFullYear());
                                    if ('1/1/1980' == checkdate) {
                                        $(txtNgayHetHan).val('');
                                    }
                                    else {
                                        $(txtNgayHetHan).val(checkdate);
                                    }
                                    var txtNgayCapNhat = $('.NgayCapNhat', newDlg)
                                    var _ngayCapNhat = new Date(data.NgayCapNhat);

                                    checkdates = '';
                                    checkdates = _ngayCapNhat.getDate() + '/' + (_ngayCapNhat.getMonth() + 1) + '/' + (_ngayCapNhat.getFullYear());
                                    if ('1/1/1980' == checkdates) {
                                        $(txtNgayCapNhat).val('');
                                    }
                                    else {
                                        $(txtNgayCapNhat).val(checkdates);
                                    }
                                    // file uploadTintuc
                                    $(lbladm_uploadTintuc_fileLists).html(data.FileListStr);
                                    $(lbladm_uploadTintuc_fileLists).find('a').click(function () {
                                        var _item = $(this).parent();
                                        $(_item).hide();
                                        //  alert($(_item).attr('_value'));
                                        $.ajax({
                                            url: vbtinfn.urlDefault,
                                            data: {
                                                'subAct': 'DeleteDoc',
                                                'F_ID': $(_item).attr('_value')
                                            },
                                            success: function (dt) {
                                                $(_item).remove();
                                            }
                                        });
                                        $(this).parent().remove();
                                    });


                                    LangTxt.val(data.Lang);

                                }
                            });
                        }
                    });
                });
            }
        }
    },
    edit: function () {

        var s = '';
        if (jQuery('#vbtinmdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#vbtinmdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#vbtinmdl-List").jqGrid('getRowData', s);
                var __TIN_ID = treedata._TIN_ID;
                var _TIN_ID = treedata.TIN_ID;
                var _Lang = treedata.TIN_Lang;
                if (__TIN_ID == '0') { alert('Tin này chưa tồn tại ở ngôn ngữ ' + _Lang); return false; }
                vbtinfn.loadHtml(function () {
                    var newDlg = $('#vbtinmdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        beforeclose: function () {
                            vbtinfn.clearform();
                        },
                        position: [200, 0],
                        buttons: {
                            'Lưu': function () {
                                vbtinfn.save(false, function () {
                                    vbtinfn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                vbtinfn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },

                        beforeclose: function () {
                        }
                        ,
                        bgiframe: true,
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            vbtinfn.clearform();
                            $.ajax({
                                url: vbtinfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': __TIN_ID
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#vbtinmdl-dlgNew');
                                    //file uploadTintuc
                                    var lbladm_uploadTintuc_fileLists = $('.adm-uploadTintuc-fileLists', newDlg);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    $(txtID).attr('_value', data.RowId);
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    //  var LangSlt = $('.Lang', newDlg);

                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var txtPID = $('.DMID', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);

                                    LangBased_ID.val(data.LangBased_ID);
                                    if (data.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }

                                    Alias.val(data.Alias);
                                    KeyWords.val(data.KeyWords);
                                    Description.val(data.Description);
                                    var txtNguon = $('.Nguon', newDlg);
                                    $(txtNguon).val(data.Nguon);

                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDungvb_tt = $('.NoiDungvb_tt', newDlg);

                                    $(txtNoiDungvb_tt).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-uploadTintuc-vbpreview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/Tintuc/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var ckbHot = $('.Hot', newDlg);
                                    if (data.Hot.toString() == 'true') {
                                        $(ckbHot).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHot).removeAttr('checked');
                                    }
                                    var ckbPublish = $('.Publish', newDlg);
                                    if (data.Active.toString() == 'true') {
                                        $(ckbPublish).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbPublish).removeAttr('checked');
                                    }

                                    var ckbHetHan = $('.HetHan', newDlg);
                                    if (data.HetHan.toString() == 'true') {
                                        $(ckbHetHan).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHetHan).removeAttr('checked');
                                    }
                                    var txtNgayHetHan = $('.NgayHetHan', newDlg)
                                    var _ngayHetHan = new Date(data.NgayHetHan);

                                    checkdate = '';
                                    checkdate = _ngayHetHan.getDate() + '/' + (_ngayHetHan.getMonth() + 1) + '/' + (_ngayHetHan.getFullYear());
                                    if ('1/1/1980' == checkdate) {
                                        $(txtNgayHetHan).val('');
                                    }
                                    else {
                                        $(txtNgayHetHan).val(checkdate);
                                    }
                                    var txtNgayCapNhat = $('.NgayCapNhat', newDlg)
                                    var _ngayCapNhat = new Date(data.NgayCapNhat);

                                    checkdates = '';
                                    checkdates = _ngayCapNhat.getDate() + '/' + (_ngayCapNhat.getMonth() + 1) + '/' + (_ngayCapNhat.getFullYear());
                                    if ('1/1/1980' == checkdates) {
                                        $(txtNgayCapNhat).val('');
                                    }
                                    else {
                                        $(txtNgayCapNhat).val(checkdates);
                                    }
                                    // file uploadTintuc
                                    $(lbladm_uploadTintuc_fileLists).html(data.FileListStr);
                                    $(lbladm_uploadTintuc_fileLists).find('a').click(function () {
                                        var _item = $(this).parent();
                                        $(_item).hide();
                                        //  alert($(_item).attr('_value'));
                                        $.ajax({
                                            url: vbtinfn.urlDefault,
                                            data: {
                                                'subAct': 'DeleteDoc',
                                                'F_ID': $(_item).attr('_value')
                                            },
                                            success: function (dt) {
                                                $(_item).remove();
                                            }
                                        });
                                        $(this).parent().remove();
                                    });

                                    vbtinfn.addpopfn();
                                    LangTxt.val(data.Lang);
                                    //                                    if ($(LangTxt).children().length > 0) { return false; }
                                    //                                    $(LangTxt).find('option').remove();
                                    //                                    $.each(LangArr, function (i, item) {
                                    //                                        if (item.Active) {
                                    //                                            Lang = item.Ma;
                                    //                                        }
                                    //                                        $(LangTxt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                                    //                                    });
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (fn) {
        var s = '';
        s = jQuery("#vbtinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#vbtinmdl-List").jqGrid('getRowData', ss[j]);
                    ll += treedata._TIN_ID + ',';
                }
            }
            $.ajax({
                url: vbtinfn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#vbtinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#vbtinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#vbtinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: vbtinfn.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#vbtinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    tinhot: function (st) {
        var s = '';
        s = jQuery("#vbtinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#vbtinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: vbtinfn.urlDefault + '&subAct=hot&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#vbtinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    hethan: function (st) {
        var s = '';
        s = jQuery("#vbtinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#vbtinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: vbtinfn.urlDefault + '&subAct=hethan&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#vbtinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-tin');
        var searchTxt = $('.mdl-head-vbfilterdanhmuc');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var _Lang = $('#vbTintucdl-changeLangSlt').val();
        var dm = $(searchTxt).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#vbtinmdl-List').jqGrid('setGridParam', { url: vbtinfn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm + '&Lang=' + _Lang }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#vbtinmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var Alias = $('.Alias', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var _LangBased_ID = LangBased_ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _Lang = LangTxt.val();
        var _Alias = Alias.val();
        var _Keywords = $(KeyWords).val();
        var _Description = Description.val();

        var txtPID = $('.DMID', newDlg);
        var pid = $(txtPID).attr('_value');
        var pten = $(txtPID).val();

        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();

        var txtNguon = $('.Nguon', newDlg);
        var Nguon = $(txtNguon).val();

        var txtMa = $('.Ma', newDlg);
        var ma = $(txtMa).val();

        var txtThuTu = $('.ThuTu', newDlg);
        var ThuTu = $(txtThuTu).val();

        var txtMoTa = $('.MoTa', newDlg);
        var MoTa = $(txtMoTa).val();

        var txtNoiDungvb_tt = $('.NoiDungvb_tt', newDlg);
        var NoiDungvb_tt = $(txtNoiDungvb_tt).val();

        var txtNgayHetHan = $('.NgayHetHan', newDlg);
        var NgayHetHan = $(txtNgayHetHan).val();

        var txtNgayCapNhat = $('.NgayCapNhat', newDlg);
        var NgayCapNhat = $(txtNgayCapNhat).val();

        var ckbPublish = $('.Publish', newDlg);
        var Publish = $(ckbPublish).val();

        var lblAnh = $('.Anh', newDlg);
        var anh = $(lblAnh).attr('ref');

        var ckbHot = $('.Hot', newDlg);
        var Hot = $(ckbHot).is(':checked');

        var ckbHetHan = $('.HetHan', newDlg);
        var HetHan = $(ckbHetHan).is(':checked');

        var txtNguoiTao = $('.NguoiTao', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ThuTu == '') { ThuTu = '0'; } else { if (!adm.isInt(ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (pid == '') {
            err += 'Nhập mục tin<br/>';
        }

        if (ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (MoTa == '') {
            err += 'Nhập mô tả<br/>';
        }

        if (NoiDungvb_tt == '') {
            err += 'Nhập nội dung<br/>';
        }

        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: vbtinfn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'Alias': _Alias,
                'Lang': _Lang,
                'DMID': pid,
                'DMTen': pten,
                'ThuTu': ThuTu,
                'Ten': ten,
                'Mota': MoTa,
                'NoiDungvb_tt': NoiDungvb_tt,
                'Public': Publish,
                'Hot': Hot,
                'Anh': anh,
                'HetHan': HetHan,
                'NgayHetHan': NgayHetHan,
                'NgayCapNhat': NgayCapNhat,
                'Nguon': Nguon,
                'KeyWords': _Keywords,
                'Description': _Description
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#vbtinmdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    clearform: function () {
        var newDlg = $('#vbtinmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        var txtPID = $('.DMID', newDlg);
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        var txtTen = $('.Ten', newDlg);
        $(txtTen).val('');
        var txtNguon = $('.Nguon', newDlg);
        $(txtNguon).val('');
        var txtNguoiTao = $('.NguoiTao', newDlg);
        $(txtNguoiTao).val('');
        var txtSTT = $('.ThuTu', newDlg);
        $(txtSTT).val('');
        var txtMoTa = $('.MoTa', newDlg);
        $(txtMoTa).val('');
        var txtNoiDungvb_tt = $('.NoiDungvb_tt', newDlg);
        $(txtNoiDungvb_tt).val('');
        var ckbHot = $('.Hot', newDlg);
        $(ckbHot).removeAttr('checked');
        var ckbPublish = $('.Publish', newDlg);
        $(ckbPublish).removeAttr('checked');
        var ckbHetHan = $('.HetHan', newDlg);
        $(ckbHetHan).removeAttr('checked');

        var lblAnh = $('.Anh', newDlg);
        lblAnh.attr('ref', '');
        $('.adm-uploadTintuc-vbpreview-img', newDlg).attr('src', '');

        var LangTxt = $('.Lang', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        LangBased_ID.val('');
        KeyWords.val('');
        var Alias = $('.Alias', newDlg);
        Alias.val('');
        Description.val('');
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#vbtinmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.tinTuc.vietbai.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },
    addpopfn: function () {
        var txttextarea = $('.NoiDungvb_tt', newDlg);
        adm.createTinyMce(txttextarea);

        var newDlg = $('#vbtinmdl-dlgNew');
        var txtNoiDungvb_tt = $('.NoiDungvb_tt', newDlg);
        var txtID = $('.ID', newDlg);
        var txtDMID = $('.DMID', newDlg);

        var lblAnh = $('.Anh', newDlg);
        var fileList = $('.adm-uploadTintuc-fileLists', newDlg);
        var ulpFn = function () {
            var uploadTintucBtn = $('.adm-uploadTintuc-btn', newDlg);
            var uploadTintucView = $('.adm-uploadTintuc-vbpreview-img', newDlg);
            var _params = { 'oldFile': $(uploadTintucBtn).attr('ref') };
            adm.uploadTintuc(uploadTintucBtn, 'anh', _params, function (rs) {
                $(uploadTintucBtn).attr('ref', rs)
                $(uploadTintucView).attr('src', '../up/Tintuc/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });           
        }
        ulpFn();
        var ID = $('.ID', newDlg);
        var _ID = ID.val();
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBasedByDM(_ID, "TIN-TUC-ROOT", txtDMID, function (event, ui) {
                $(txtDMID).attr('_value', ui.item.id);
            });
        });
        $(txtDMID).unbind('click').click(function () { $(txtDMID).autocomplete('search', ''); });

        var LangSlt = $('.Lang', newDlg);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });

        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayCapNhat', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        var _today = new Date();
        var _todayDate = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + _today.getFullYear();
        var Ngaycapnhat = $('.NgayCapNhat', newDlg); //.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        Ngaycapnhat.val(_todayDate)
    }
}
