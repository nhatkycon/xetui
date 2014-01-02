using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;

public partial class lib_ajax_car_Default : BasedPage
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
        var dic = Server.MapPath("~/lib/up/crop/");
        var newDic = Server.MapPath("~/lib/up/car/");
        var DM_PID = Request["DM_PID"];
        var js = new JavaScriptSerializer();
        switch (subAct)
        {
            case "GetModelByHangXe":
            #region get models by car manufacture
                if(DM_PID!= null)
                {
                    var allModelInCache = Cache["HANGXE"];
                    if(allModelInCache==null)
                    {
                        var hangXeList = DanhMucDal.SelectByLDMMa("HANGXE");
                        Cache.Insert("HANGXE", hangXeList);
                        allModelInCache = hangXeList;
                    }
                    var allModel=(List<DanhMuc>)allModelInCache;
                    var filterModel = (from p in allModel
                                       where p.PID == new Guid(DM_PID)
                                       select p).OrderByDescending(m => m.ThuTu).ToList();
                    rendertext(js.Serialize(filterModel));
                }
                break;
            #endregion
            case "upload":
                #region upload image
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
                                      ID = Guid.NewGuid()
                                      ,
                                      P_ID = new Guid(Id)
                                      ,
                                      FileAnh = fileName
                                      , NgayTao = DateTime.Now                                      
                                  };
                    anh = AnhDal.Insert(anh);
                    r.Add(new ViewDataUploadFilesResult()
                    {
                        Id = anh.ID.ToString(),
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
                    Response.Write(jsonObj);
                }
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
                    img.Resize(960);
                    Response.ClearContent();
                    Response.ContentType = img.Mime;
                    img.Save(newDic + Key);
                    img.Save();
                    Response.End();
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
                    if(img.Heigth < 540)
                        img.ResizeHeight(540);
                    img.Crop(960, 540);
                    Response.ClearContent();
                    Response.ContentType = img.Mime;
                    img.Save(newDic + Key);
                    img.Save();
                    Response.End();
                }
                break;
                #endregion
        }
    }
}