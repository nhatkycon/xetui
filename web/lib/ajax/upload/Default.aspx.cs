using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using linh.common;
using linh.core;
using linh.controls;
public partial class lib_ajax_upload_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var x = Request["x"];
        var y = Request["y"];
        var x1 = Request["x1"];
        var y1 = Request["y1"];
        var w = Request["w"];
        var h = Request["h"];
        var Key = Request["key"];
        var dic = Server.MapPath("~/lib/up/crop/");
        

        switch (subAct)
        {
            case "upload":
                #region upload anh
                Response.ContentType = "text/plain";//"application/json";
                var r = new List<ViewDataUploadFilesResult>();
                var js = new JavaScriptSerializer();
                foreach (string file in Request.Files)
                {
                    
                    var hpf = Request.Files[file] as HttpPostedFile;
                    var key = Guid.NewGuid().ToString();
                    var img = new ImageProcess(hpf.InputStream, key);
                    var fileName = key + img.Ext;
                    img.Resize(480);
                    img.Save(dic + key + "full" + img.Ext);
                    img.Save(dic + key + img.Ext);
                    r.Add(new ViewDataUploadFilesResult()
                    {
                        Id = fileName,
                        Thumbnail_url = key + img.Ext,
                        Name = key + "full" + img.Ext,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                    var uploadedFiles = new
                    {
                        files = r.ToArray()
                    };
                    var jsonObj = js.Serialize(uploadedFiles);
                    Response.Write( jsonObj);
                }
                break;
                #endregion
            default:
                #region noral
                if (Key != null)
                {
                    var fileName = dic + Lib.imgSize(Key, "full");
                    var file = Request.Files;
                    var src = new Bitmap(fileName);
                    var format = src.RawFormat;
                    var codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
                    var mimeType = codec.MimeType;
                    new ImageFormat(codec.FormatID);
                    var cropRect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));

                    var cropted = Lib.CropBitmap(src, cropRect);
                    //var img = new ImageProcess(cropted, Key);
                    //if (img.Width > 480)
                    //    img.Resize(480);
                    //Response.ClearContent();
                    //Response.ContentType = mimeType;
                    //src.Dispose();
                    File.Delete(dic + Key);
                    //img.Save(dic + Key);
                    //img.Save();
                    //Response.End();
                    Response.ClearContent();
                    Response.ContentType = mimeType;
                    cropted.Save(dic + Key);
                    cropted.Save(Response.OutputStream, ImageFormat.Jpeg);
                    Response.End();
                }
                break;
                #endregion
        }
       
    }
}