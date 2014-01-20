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

        var adminKey = Request["AdminKey"];

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
        var Duyet = Request["Duyet"];

        switch (subAct)
        {
            case "GetModelByHangXe":
            #region get models by car manufacture
                if(DM_PID!= null)
                {
                    var allModel = DanhMucDal.SelectByLdmMaFromCache("HANGXE");
                    var filterModel = (from p in allModel
                                       where p.PID == new Guid(DM_PID)
                                       select p).OrderByDescending(m => m.ThuTu).ToList();
                    rendertext(js.Serialize(filterModel));
                }
                break;
            #endregion
            case "save":
            #region Save
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
                    if (!string.IsNullOrEmpty(Duyet))
                    {
                        Duyet = !string.IsNullOrEmpty(Duyet) ? "true" : "false";
                        car.Duyet = Convert.ToBoolean(Duyet);
                        car.NguoiDuyet = Security.Username;
                        car.NgayDuyet = DateTime.Now;
                    }
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
                        SearchManager.Add(car.Ten, string.Format("{0} {1}", car.Ten, car.GioiThieu), string.Empty, car.RowId.ToString(),
                                              car.XeUrl, typeof(Xe).Name);
                    }
                    MemberDal.UpdateVcard(DAL.con(), Security.Username);
                }
                break;
            #endregion
            case "remove":
                #region remove car
                if (Id != null && logged)
                {
                    var xe = XeDal.SelectById(Convert.ToInt64(Id));
                    if (xe.NguoiTao != Security.Username && string.IsNullOrEmpty(adminKey))
                        return;
                    XeDal.DeleteById(xe.ID);
                    ObjDal.DeleteByRowId(xe.RowId);
                    SearchManager.Remove(xe.RowId);
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
            
            
        }
    }
}