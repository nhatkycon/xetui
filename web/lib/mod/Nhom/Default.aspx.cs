using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Nhom_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];
        var duyet = Request["Duyet"];
        var username = Request["username"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var pgUrl = string.Format(
            "?q={0}&size={1}&Duyet={3}&Username={4}&TuNgay={5}&DenNgay={6}&", q, size, string.Empty,
            duyet, username, tuNgay, denNgay) + "{1}={0}";
        using(var con = DAL.con())
        {
            var pager = NhomDal.PagerNormal(con, pgUrl, false, "G_NgayCapNhat desc", q, Convert.ToInt32(size), username,
                                            duyet, tuNgay, denNgay);
            AdmList.Pager = pager;
        }
    }
}