using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;
using linh.core.dal;

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
        var logged = Security.IsAuthenticated();
        var js = new JavaScriptSerializer();


        var DangLai = Request["DangLai"];
        var Gia = Request["Gia"];
        var GioiThieu = Request["GioiThieu"];
        var HANG_ID = Request["HANG_ID"];
        var MODEL_ID = Request["MODEL_ID"];
        var HopSo = Request["HopSo"];
        var Nam = Request["Nam"];
        var RaoBan = Request["RaoBan"];
        var RowId = Request["RowId"];
        var SubModel = Request["SubModel"];
        var Ten = Request["Ten"];
        var TinhTrang = Request["TinhTrang"];
        var XuatXu = Request["XuatXu"];
        var DONGXE_ID = Request["DONGXE_ID"];
        var MAUNGOAITHAT_ID = Request["MAUNGOAITHAT_ID"];
        var MAUNOITHAT_ID = Request["MAUNOITHAT_ID"];
        var KIEUDANDONG_ID = Request["KIEUDANDONG_ID"];
        var NHIENLIEU_ID = Request["NHIENLIEU_ID"];
        var THANHPHO_ID = Request["THANHPHO_ID"];
        var Anh = Request["Anh"];
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
            case "save":
            #region Save anh
                if (logged)
                {
                    RaoBan = !string.IsNullOrEmpty(RaoBan) ? "true" : "false";
                    DangLai = string.IsNullOrEmpty(DangLai) ? "true" : "false";
                    Gia = string.IsNullOrEmpty(Gia) ? "0" : Gia;
                    var isInserting = false;

                    if (Id == "0")
                        Id = "";

                    var idNull = string.IsNullOrEmpty(Id);
                    var car = new Xe();
                    if (idNull)
                    {
                        if (!string.IsNullOrEmpty(RowId))
                        {
                            car = XeDal.SelectByRowId(RowId);
                            if (car.ID == 0)
                            {
                                isInserting = true;
                            }
                            else
                            {
                                isInserting = true;
                            }
                        }
                    }

                    car = idNull ? (isInserting ? new Xe() : XeDal.SelectByRowId(RowId)) : XeDal.SelectById(Convert.ToInt64(Id));

                    car.Ten = Ten;
                    car.DangLai = Convert.ToBoolean(DangLai);
                    car.GioiThieu = GioiThieu;
                    car.Gia = Convert.ToInt32(Gia);
                    if(!string.IsNullOrEmpty(HANG_ID))
                    {
                        car.HANG_ID = new Guid(HANG_ID);
                    }
                    if (!string.IsNullOrEmpty(MODEL_ID))
                    {
                        car.MODEL_ID = new Guid(MODEL_ID);
                    }
                    if(!string.IsNullOrEmpty(HopSo))
                    {
                        car.HopSo = Convert.ToBoolean(HopSo);
                    }                    
                    if (!string.IsNullOrEmpty(TinhTrang))
                    {
                        car.TinhTrang = Convert.ToBoolean(TinhTrang);
                    }
                    if (!string.IsNullOrEmpty(XuatXu))
                    {
                        car.XuatXu = Convert.ToBoolean(XuatXu);
                    }
                    if (!string.IsNullOrEmpty(DONGXE_ID))
                    {
                        car.DONGXE_ID = new Guid(DONGXE_ID);
                    }
                    //
                    if (!string.IsNullOrEmpty(MAUNGOAITHAT_ID))
                    {
                        car.MAUNGOAITHAT_ID = new Guid(MAUNGOAITHAT_ID);
                    }
                    if (!string.IsNullOrEmpty(MAUNOITHAT_ID))
                    {
                        car.MAUNOITHAT_ID = new Guid(MAUNOITHAT_ID);
                    }
                    if (!string.IsNullOrEmpty(KIEUDANDONG_ID))
                    {
                        car.KIEUDANDONG_ID = new Guid(KIEUDANDONG_ID);
                    }
                    if (!string.IsNullOrEmpty(NHIENLIEU_ID))
                    {
                        car.NHIENLIEU_ID = new Guid(NHIENLIEU_ID);
                    }
                    if (!string.IsNullOrEmpty(THANHPHO_ID))
                    {
                        car.THANHPHO_ID = new Guid(THANHPHO_ID);
                    }
                    if (!string.IsNullOrEmpty(RowId))
                    {
                        car.RowId = new Guid(RowId);
                    }
                    car.RaoBan = Convert.ToBoolean(RaoBan);
                    car.Nam = Convert.ToInt32(Nam);
                    car.SubModel = SubModel;
                    car.NgayCapNhat = DateTime.Now;
                    car.NguoiCapNhat = Security.Username;
                    car.Anh = Anh;

                    if (idNull)
                    {                        
                        if (isInserting)
                        {
                            car.NgayTao = DateTime.Now;
                            car.NguoiTao = Security.Username;
                            car = XeDal.Insert(car);

                            ObjMemberDal.Insert(new ObjMember()
                            {
                                PRowId = car.RowId
                                ,
                                Username = Security.Username
                                ,
                                Owner = true
                                ,
                                NgayTao = DateTime.Now
                                ,
                                RowId = Guid.NewGuid()
                            });
                            var obj = ObjDal.Insert(new Obj()
                            {
                                ID = Guid.NewGuid()
                                ,
                                Kieu = typeof(Xe).FullName
                                ,
                                NgayTao = DateTime.Now
                                ,
                                RowId = car.RowId
                                ,
                                Url = car.XeUrl
                                ,
                                Username = Security.Username
                                ,
                                Ten = car.Ten
                            });
                        }
                        else
                        {
                            car = XeDal.Update(car);    
                        }
                    }
                    else
                    {
                        car = XeDal.Update(car);
                    }
                    MemberDal.UpdateVcard(DAL.con(), Security.Username);
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
            case "remove":
                #region remove car
                if (Id != null && logged)
                {
                    var xe = XeDal.SelectById(Convert.ToInt64(Id));
                    if(xe.NguoiTao != Security.Username)
                        return;
                    XeDal.DeleteById(xe.ID);
                    ObjDal.DeleteByRowId(xe.RowId);
                    ObjMemberDal.DeleteByPRowId(xe.RowId.ToString());
                    foreach (var item in AnhDal.SelectByPId(DAL.con(), xe.RowId.ToString(),50))
                    {
                        var file = newDic + item.FileAnh;
                        if (File.Exists(file))
                        {
                            File.Delete(newDic + item.FileAnh);
                        }
                        AnhDal.DeleteById(item.ID);    
                    }
                }
                break;
                #endregion
            case "likeXe":
                #region like car
                if (Id != null && logged)
                {
                    var xe = XeDal.SelectById(Convert.ToInt64(Id));
                    XeYeuThichDal.Insert(new XeYeuThich()
                                             {
                                                 NgayTao = DateTime.Now
                                                 , Username = Security.Username
                                                 ,
                                                 X_ID = xe.ID
                                             });
                }
                break;
                #endregion
            case "unLikeXe":
                #region lunike car
                if (Id != null && logged)
                {
                    XeYeuThichDal.DeleteByUserXid(Security.Username, Id);
                }
                break;
                #endregion
            case "RemoveImage":
                #region remove image
                if (Id != null)
                {
                    var item = AnhDal.SelectById(new Guid(Id));
                    var file = newDic + item.FileAnh;
                    if(File.Exists(file))
                    {
                        File.Delete(newDic + item.FileAnh);                        
                    }
                    AnhDal.DeleteById(item.ID);
                }
                break;
                #endregion
            case "SetAnhChinh":
                #region Set Anh Chinh
                if (Id != null)
                {
                    var item = AnhDal.SelectById(new Guid(Id));                    
                    var xe = XeDal.SelectByRowId(item.P_ID);
                    AnhDal.UpdateAnhBia(item.ID);
                    if(xe.ID!=0)
                    {
                        xe.Anh = item.FileAnh;
                        XeDal.Update(xe);    
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