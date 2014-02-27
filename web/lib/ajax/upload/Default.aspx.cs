using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using docsoft;
using docsoft.entities;
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
        var Id = Request["Id"];
        var dic = Server.MapPath("~/lib/up/car/");
        var newDic = Server.MapPath("~/lib/up/car/");
        var DM_PID = Request["DM_PID"];
        var logged = Security.IsAuthenticated();
        var js = new JavaScriptSerializer();
        
        switch (subAct)
        {
            case "upload":
                #region upload image
                if (!string.IsNullOrEmpty(Id))
                {
                    Response.ContentType = "text/plain";//"application/json";
                    var r = new List<ViewDataUploadFilesResult>();
                    foreach (string file in Request.Files)
                    {
                        var hpf = Request.Files[file] as HttpPostedFile;
                        var key = Guid.NewGuid().ToString();
                        var img = new ImageProcess(hpf.InputStream, key);
                        var fileName = key + img.Ext;
                        img.Resize(960);
                        img.Save(dic + key + "full" + img.Ext);
                        img.Save(dic + key + img.Ext);

                        var anh = new Anh()
                        {
                            Id = Guid.NewGuid()
                            ,
                            P_ID = new Guid(Id)
                            ,
                            FileAnh = fileName
                            ,
                            NgayTao = DateTime.Now
                        };
                        anh = AnhDal.Insert(anh);
                        r.Add(new ViewDataUploadFilesResult()
                        {
                            Id = anh.Id.ToString(),
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
                        rendertext(jsonObj);
                    }
                }
                rendertext("Id is missing", HttpStatusCode.BadRequest);
                break;
                #endregion
            case "GetImage":
                #region get image
                if (Key != null)
                {
                    var fileName = dic + Lib.imgSize(Key, "full");
                    var src = new Bitmap(fileName);
                    var cropRect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));
                    var cropted = Lib.CropBitmap(src, cropRect);
                    var img = new ImageProcess(cropted, Key);
                    File.Delete(dic + Key);
                    if (img.Width < 960)
                        img.Resize(960);
                    Response.ClearContent();
                    Response.ContentType = img.Mime;
                    img.Save(newDic + Key);
                    img.Save();
                    Response.End();
                }
                break;
                #endregion
            case "RemoveImage":
                #region remove image
                if (Id != null)
                {
                    var item = AnhDal.SelectById(new Guid(Id));
                    var file = newDic + item.FileAnh;
                    if (File.Exists(file))
                    {
                        File.Delete(newDic + item.FileAnh);
                    }
                    AnhDal.DeleteById(item.Id);
                }
                break;
                #endregion
            case "SetAnhChinh":
                #region Set Anh Chinh
                if (Id != null)
                {
                    var item = AnhDal.SelectById(new Guid(Id));
                    AnhDal.UpdateAnhBia(item.Id);
                    var xe = XeDal.SelectByRowId(item.P_ID);
                    if (xe.Id != 0)
                    {
                        xe.Anh = item.FileAnh;
                        XeDal.Update(xe);
                    }
                    var blog = BlogDal.SelectByRowId(item.P_ID);
                    if (blog.Id != 0)
                    {
                        blog.Anh = item.FileAnh;
                        BlogDal.Update(blog);
                    }
                }
                break;
                #endregion
            case "GetImageMobile":
                #region get image in mobile
                if (Key != null)
                {
                    var fileName = dic + Lib.imgSize(Key, "full");
                    var img = new ImageProcess(fileName, Key);
                    File.Delete(dic + Key);
                    if (img.Heigth < 540)
                        img.ResizeHeight(540);
                    img.Crop(960, 540);
                    Response.ClearContent();
                    Response.ContentType = img.Mime;
                    img.Save(newDic + Key);
                    if(!string.IsNullOrEmpty(w))
                    {
                        img.Resize(Convert.ToInt32(w));
                        if(!string.IsNullOrEmpty(h))
                        {
                            img.Crop(Convert.ToInt32(w), Convert.ToInt32(h));
                        }
                    }
                    img.Save();
                    Response.End();
                }
                break;
                #endregion
        }
       
    }
}