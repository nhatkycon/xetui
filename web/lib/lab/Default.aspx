<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_lab_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/lib/js/jCrop/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
    <script src="/lib/js/jqueryLib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/lib/js/jCrop/jquery.Jcrop.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="fom" id="form1" runat="server">
        <img class="img" src="mercedes.jpg" />
        <hr/>
        <img id="preview"/>

        <input name="x" class="x" type="hidden"/>
        <input name="y"  class="y" type="hidden"/>
        <input name="x1" class="x1" type="hidden"/>
        <input name="y1" class="y1" type="hidden"/>
        <input name="w" class="w" type="hidden"/>
        <input name="h" class="h" type="hidden"/>
    </div>
    
    <script language="Javascript">
        jQuery(function ($) {
            $('.img').Jcrop({
                onSelect: showCoords,
                bgColor: 'black',
                bgOpacity: .4,
                minSize : [ 480 , 270],
                setSelect: [100, 100, 50, 50],
                aspectRatio: 16 / 9
            });
            function showCoords(c) {
                // variables can be accessed here as
                // c.x, c.y, c.x2, c.y2, c.w, c.h
                $('.x').val(Math.round(c.x));
                $('.y').val(Math.round(c.y));
                $('.x1').val(c.x2);
                $('.y1').val(c.y2);
                $('.w').val(Math.round(c.w));
                $('.h').val(Math.round(c.h));
                var data = 'crop.aspx?' + $('.fom').find(':input').serialize();
                $('#preview').attr('src', data);
            };
            $('a').click(function (parameters) {
                
            });
        });
</script>
</body>
</html>
