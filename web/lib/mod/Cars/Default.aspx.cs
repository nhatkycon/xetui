﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Cars_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var hang_Id = Request["HANG_ID"];
        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];
        var duyet = Request["Duyet"];
        var Id = Request["ID"];
        var username = Request["username"];
        bool? duyetValue = Convert.ToBoolean(duyet);

        var pgUrl = string.Format(
            "?q={0}&size={1}&HANG_ID={2}&Duyet={3}&Username={4}&TuNgay={5}&DenNgay={6}&", q, size, hang_Id,
            duyet, username, tuNgay, denNgay) + "{1}={0}";
        using (var con = DAL.con())
        {
            var pager = XeDal.PagerNormal(con, pgUrl, false, "X_ID desc", q, duyetValue
                                          , hang_Id, tuNgay, denNgay, Id, username);
            var hangId = DanhMucDal.SelectByLDMMa(con, "HANGXE");
            AdmDanhSach.HangList = hangId;
            AdmDanhSach.Pager = pager;
        }
    }
}