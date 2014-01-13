using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.core;

public partial class lib_ajax_nhom_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ten = Request["Ten"];
        var moTa = Request["MoTa"];
        var id = Request["Id"];
        var cUrl = Request["cUrl"];
        var gioiThieu = Request["GioiThieu"];
        var anh = Request["Anh"];
        var duyet = Request["Duyet"];
        var active = Request["Active"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(id) || id == "0";
        var adminKey = Request["AdminKey"];
        var dic = Server.MapPath("~/lib/up/nhom/");
        switch (subAct)
        {
            case "save":
                #region save Nhom
                if (logged && !string.IsNullOrEmpty(ten))
                {
                    var item = idNull ? new Nhom() : NhomDal.SelectById(Convert.ToInt32(id));
                    item.Ten = ten;
                    item.MoTa = moTa;
                    item.GioiThieu = gioiThieu;
                    item.Anh = anh;
                    item.NgayCapNhat = DateTime.Now;
                    if (!string.IsNullOrEmpty(duyet))
                    {
                        duyet = !string.IsNullOrEmpty(duyet) ? "true" : "false";
                        item.Duyet = Convert.ToBoolean(duyet);
                        item.NguoiDuyet = Security.Username;
                        item.NgayDuyet = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(active))
                    {
                        active = !string.IsNullOrEmpty(active) ? "true" : "false";
                        item.Active = Convert.ToBoolean(active);
                    }
                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        
                        item.RowId = Guid.NewGuid();
                        item = NhomDal.Insert(item);


                        NhomThanhVienDal.Insert(new NhomThanhVien()
                                                    {
                                                        NHOM_ID = item.ID
                                                        , Accepted = true
                                                        ,AcceptedDate = DateTime.Now
                                                        , Admin = true
                                                        , Approved = true
                                                        , ApprovedDate = DateTime.Now
                                                        , ID = Guid.NewGuid()
                                                        , NgayTao = DateTime.Now
                                                        , NguoiTao = Security.Username
                                                        , Username = Security.Username
                                                    });

                        ObjMemberDal.Insert(new ObjMember()
                        {
                            PRowId = item.RowId
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
                            Kieu = typeof(Nhom).FullName
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = item.RowId
                            ,
                            Ten = item.Ten
                            ,
                            Url = string.Format("{0}", item.Url)
                            ,
                            Username = Security.Username
                        });
                    }
                    else
                    {
                        item.NguoiCapNhat = Security.Username;
                        item = NhomDal.Update(item);
                    }
                    rendertext(item.Url);
                }
                rendertext("0");
                break;
                #endregion
            case "remove":
                #region remove Nhom
                if (!string.IsNullOrEmpty(id) && logged)
                {
                    var item = NhomDal.SelectById(Convert.ToInt32(id));
                    if (item.NguoiTao == Security.Username || !string.IsNullOrEmpty(adminKey))
                    {
                        ObjDal.DeleteByRowId(item.RowId);
                        ObjMemberDal.DeleteByPRowId(item.RowId.ToString());
                        ThichDal.DeleteByPId(item.RowId);
                        NhomDal.DeleteById(item.ID);
                    }
                }
                break;
                #endregion
            case "changeAvatar":
                #region change avatar
                if (logged)
                {
                    if (Request.Files.Count > 0)
                    {
                        var img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        if (img.Width > img.Heigth)
                        {
                            img.ResizeHeight(180);
                        }
                        else
                        {
                            img.Resize(180);
                        }
                        img.Crop(180, 180);
                        var anhNew = string.Format("{0}{1}", Guid.NewGuid().ToString(), img.Ext);
                        img.Save(dic + anhNew);
                        rendertext(anhNew);
                    }
                }
                rendertext("0");
                break;
                #endregion
        }

    }
}