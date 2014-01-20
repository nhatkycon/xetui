using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_promoted_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ten = Request["Ten"];
        var moTa = Request["MoTa"];
        var keywords = Request["Keywords"];
        var id = Request["Id"];
        var xurl = Request["Url"];
        var refId = Request["refId"];
        var ngayBatDau = Request["NgayBatDau"];
        var ngayKetThuc = Request["NgayKetThuc"];
        var anh = Request["Anh"];
        var clicked = Request["Clicked"];
        var views = Request["Views"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(id) || id == "0";
        var adminKey = Request["AdminKey"];
        var dic = Server.MapPath("~/lib/up/promoted/");
        var joined = Request["Joined"];
        var approved = Request["approved"];
        var loai = Request["Loai"];
        var pRowId = Request["PRowId"];

        switch (subAct)
        {
            case "save":
                #region save Nhom
                if (logged && !string.IsNullOrEmpty(ten))
                {
                    var item = idNull ? new Promoted() : PromotedDal.SelectById(Convert.ToInt32(id));
                    item.Ten = ten;
                    item.MoTa = moTa;
                    item.Keywords = keywords;
                    item.Anh = anh;
                    item.Url = xurl;
                    item.refId = refId;
                    if (!string.IsNullOrEmpty(pRowId))
                    {
                        item.PRowId = new Guid(pRowId);
                    }

                    if(!string.IsNullOrEmpty(ngayBatDau))
                    {
                        item.NgayBatDau = Convert.ToDateTime(ngayBatDau, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(ngayKetThuc))
                    {
                        item.NgayKetThuc = Convert.ToDateTime(ngayKetThuc, new CultureInfo("vi-Vn"));
                    }
                    if(!string.IsNullOrEmpty(loai))
                    {
                        item.Loai = Convert.ToInt32(loai);
                    }
                    if (!string.IsNullOrEmpty(approved))
                    {
                        approved = !string.IsNullOrEmpty(approved) ? "true" : "false";
                        item.Approved = Convert.ToBoolean(approved);
                        item.ApprovedBy = Security.Username;
                        item.ApprovedDate = DateTime.Now;
                    }
                    else
                    {
                        item.Approved = false;
                        item.ApprovedDate = DateTime.Now;
                    }
                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        item.RowId = Guid.NewGuid();
                        item = PromotedDal.Insert(item);
                    }
                    else
                    {
                        item = PromotedDal.Update(item);
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
            case "join":
                #region Tham gia nhom
                if (!string.IsNullOrEmpty(id) && logged)
                {
                    var item = NhomDal.SelectById(DAL.con(), Convert.ToInt32(id), Security.Username);
                    var isJoined = joined == "1";
                    var itemTv = NhomThanhVienDal.SelectByNhomIdUsername(id, Security.Username);
                    if (isJoined && itemTv.ID != Guid.Empty && !itemTv.Admin) // remove 
                    {
                        NhomThanhVienDal.DeleteById(itemTv.ID);
                    }
                    else // add
                    {
                        NhomThanhVienDal.Insert(new NhomThanhVien()
                        {
                            Accepted = true
                            ,
                            AcceptedDate = DateTime.Now
                            ,
                            Admin = false
                            ,
                            Approved = false
                            ,
                            ID = Guid.NewGuid()
                            ,
                            NgayTao = DateTime.Now
                            ,
                            NguoiTao = Security.Username
                            ,
                            NHOM_ID = item.ID
                            ,
                            Username = Security.Username
                            ,
                            IsMod = false
                            ,
                            ModLoai = 0
                        });
                    }
                }
                break;
                #endregion
            case "duyetThanhVien":
                #region Duyệt thành viên tham gia nhóm
                if (!string.IsNullOrEmpty(id) && logged)
                {
                    var nhomTv = NhomThanhVienDal.SelectById(new Guid(id));
                    var mem = Security.Username;
                    var memTv = NhomThanhVienDal.SelectByNhomIdUsername(nhomTv.NHOM_ID.ToString(), mem);
                    var nhom = NhomDal.SelectById(nhomTv.NHOM_ID);
                    var Approved = approved == "1";
                    if (memTv.ModLoai == 5)
                    {
                        if (Approved)
                        {
                            nhomTv.Approved = true;
                            nhomTv.ApprovedDate = DateTime.Now;
                            NhomThanhVienDal.Update(nhomTv);

                            ObjMemberDal.Insert(new ObjMember()
                            {
                                PRowId = nhom.RowId
                                ,
                                Username = nhomTv.Username
                                ,
                                Owner = false
                                ,
                                NgayTao = DateTime.Now
                                ,
                                RowId = Guid.NewGuid()
                            });
                        }
                        else
                        {
                            NhomThanhVienDal.DeleteById(nhomTv.ID);
                            ObjMemberDal.DeleteByPRowIdUsername(nhom.RowId.ToString(), nhomTv.Username);
                        }
                        rendertext("1");
                    }
                    rendertext("0");
                }
                break;
                #endregion
            case "phanQuyenThanhVien":
                #region Phân quyền thành viên
                if (!string.IsNullOrEmpty(id) && logged)
                {
                    var nhomTv = NhomThanhVienDal.SelectById(new Guid(id));
                    var mem = Security.Username;
                    var memTv = NhomThanhVienDal.SelectByNhomIdUsername(nhomTv.NHOM_ID.ToString(), mem);
                    if (memTv.ModLoai == 5)
                    {
                        nhomTv.ModLoai = Convert.ToInt32(loai);
                        nhomTv.IsMod = nhomTv.ModLoai != 0;
                        if (!nhomTv.Approved)
                        {
                            nhomTv.Approved = true;
                            nhomTv.ApprovedDate = DateTime.Now;
                        }
                        NhomThanhVienDal.Update(nhomTv);
                        rendertext("1");
                    }
                    rendertext("0");
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
                        if (img.Width > 300)
                        {
                            img.Resize(300);
                        }
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