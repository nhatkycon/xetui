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
                    item.Clicked = Convert.ToInt32(clicked);
                    item.Views = Convert.ToInt32(views);
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
                    PromotedDal.DeleteById(Convert.ToInt32(id));
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
        RemoveCache();
    }
    public void RemoveCache()
    {
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "PromotedTop"));
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "KeyPromotedHomeBig"));
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "PromotedHomeMedium"));
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "PromotedHomeSmall"));
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "HomeTop"));
        CacheHelper.Remove(string.Format(XeDal.CacheListKey, "HomeNewest"));
    }
}