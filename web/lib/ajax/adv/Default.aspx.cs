using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_adv_Default : BasedPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var ten = Request["Ten"];
        var ma = Request["Ma"];
        var keywords = Request["Keywords"];
        var id = Request["Id"];
        var xurl = Request["Url"];
        var ngayBatDau = Request["NgayBatDau"];
        var ngayKetThuc = Request["NgayKetThuc"];
        var noiDung = Request["NoiDung"];
        var clicks = Request["Clicks"];
        var views = Request["Views"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(id) || id == "0";
        var approved = Request["Duyet"];
        var flash = Request["Flash"];
        var loai = Request["Loai"];
        var rowId = Request["RowId"];
        switch (subAct)
        {
            case "save":
                #region save Nhom
                if (logged && !string.IsNullOrEmpty(ten))
                {
                    var item = idNull ? new Adv() : AdvDal.SelectById(new Guid(id));
                    item.Ten = ten;
                    item.Ma = ma;
                    item.NoiDung = noiDung;
                    item.Keywords = keywords;
                    item.Url = xurl;
                    item.Clicks = Convert.ToInt32(clicks);
                    item.Views = Convert.ToInt32(views);
                    if (!string.IsNullOrEmpty(rowId))
                    {
                        item.RowId = new Guid(rowId);
                    }

                    if (!string.IsNullOrEmpty(ngayBatDau))
                    {
                        item.NgayBatDau = Convert.ToDateTime(ngayBatDau, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(ngayKetThuc))
                    {
                        item.NgayKetThuc = Convert.ToDateTime(ngayKetThuc, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(loai))
                    {
                        item.Loai = Convert.ToInt32(loai);
                    }
                    flash = string.IsNullOrEmpty(flash) ? "false" : "true";
                    item.Flash = Convert.ToBoolean(flash);
                    if (!string.IsNullOrEmpty(approved))
                    {
                        approved = !string.IsNullOrEmpty(approved) ? "true" : "false";
                        item.Duyet = Convert.ToBoolean(approved);
                        item.NguoiDuyet = Security.Username;
                        item.NgayDuyet = DateTime.Now;
                    }
                    else
                    {
                        item.Duyet = false;
                        item.NgayDuyet = DateTime.Now;
                    }
                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        item.ID = Guid.NewGuid();
                        item = AdvDal.Insert(item);
                    }
                    else
                    {
                        item = AdvDal.Update(item);
                    }
                    CacheHelper.RemoveByPattern(AdvDal.CacheKey);
                    rendertext(item.Url);
                }
                rendertext("0");
                break;
                #endregion
            case "remove":
                #region remove Nhom
                if (!string.IsNullOrEmpty(id) && logged)
                {
                    AdvDal.DeleteById(new Guid(id));
                }
                break;
                #endregion
            case "getAdv":
                #region Lấy quảng cáo
                if (!string.IsNullOrEmpty(loai))
                {
                    var list = AdvDal.SelectByLoai(DAL.con(), loai, true.ToString());
                    AdvList1.Visible = list.Any();
                    AdvList1.List = list;
                    if (!list.Any())
                        rendertext("0");
                }
                break;
                #endregion
        }
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