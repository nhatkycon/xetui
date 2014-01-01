<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_lab_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/lib/js/jCrop/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
    <script src="/lib/js/jqueryLib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/lib/js/jCrop/jquery.Jcrop.min.js" type="text/javascript"></script>
    <script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>
</head>
<body>
    <div class="fom" id="form1" runat="server">
        <span class="btn btn-success album-upload-postBox">
            <i class="icon-plus icon-white"></i>
            <span>Chọn ảnh</span>
            <!-- The file input field used as target for the file upload widget -->
            <input type="file" multiple="" class="uploadAnhBtn" name="files[]" id="fileupload">
        </span> 
        <div id="progress" class="progress progress-success progress-striped" style="display: none;">
            <div class="bar"></div>
        </div>
        <div class="view">
            
        </div>

        
    </div>
    <script src="/lib/js/jqueryLib/jquery.tmpl.min.js" type="text/javascript"></script>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row-fluid item-anh-uploadPreview" data-id="${Id}">
        <div class="span3">
            <div class="anh-img-box">
                <img src="/lib/up/crop/${Thumbnail_url}" class="anh-img"/>
                <img src="/lib/up/crop/${Thumbnail_url}" class="anh-fix" style="display: none;"/>
            </div>
        </div>    
        <div class="span9">
            <input value="" data-id="${Id}" class="input-xxlarge Ten" type="text"/>
            <button class="btn btn-primary apply" data-id="${Id}" style="margin-bottom: 10px;">Cắt ảnh</button>
            <button class="btn btn-warning" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
        </div>
        <input name="key" value="${Thumbnail_url}" type="hidden"/>
        <input name="x" class="x" type="hidden"/>
        <input name="y"  class="y" type="hidden"/>
        <input name="x1" class="x1" type="hidden"/>
        <input name="y1" class="y1" type="hidden"/>
        <input name="w" class="w" type="hidden"/>
        <input name="h" class="h" type="hidden"/>
    </div>
    <hr/>
</script>
    <script language="Javascript">
        jQuery(function ($) {
            
            var albumUploadList = $.find('.view');

            var url = '/lib/ajax/upload/Default.aspx';
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                dropZone: albumUploadList,
                formData: {
                    'subAct': 'upload'
                },
                done: function (e, data) {
                    $('#progress').hide();
                    $.each(data.result.files, function (index, file) {
                        var anhItem = $('#anh-item').tmpl(file).prependTo(albumUploadList);
                        anhItem.find('.anh-img').Jcrop({
                            onSelect: function(c) {
                                showCoords(c, anhItem);
                            },
                            bgColor: 'black',
                            bgOpacity: .4,
                            //minSize: [480, 270],
                            setSelect: [0, 0, 480, 270],
                            aspectRatio: 16 / 9
                        });
                        var apply = anhItem.find('.apply');
                        apply.click(function() {
                            $('.anh-fix').show();
                            $('.anh-img').hide();
                            anhItem.find('.jcrop-holder').hide();
                        });
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



           
            function showCoords(c,el) {
                // variables can be accessed here as
                // c.x, c.y, c.x2, c.y2, c.w, c.h
                el.find('.x').val(Math.round(c.x));
                el.find('.y').val(Math.round(c.y));
                el.find('.x1').val(c.x2);
                el.find('.y1').val(c.y2);
                el.find('.w').val(Math.round(c.w));
                el.find('.h').val(Math.round(c.h));
                var data = url + '?' + el.find(':input').serialize();
                el.find('.anh-fix').attr('src', data + '&ref=' + Math.random());
            };
            
        });
</script>
</body>
</html>
