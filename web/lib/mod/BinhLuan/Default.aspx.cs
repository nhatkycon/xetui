using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_BinhLuan_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];
        var username = Request["username"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var pgUrl = string.Format(
            "?q={0}&size={1}&HANG_ID={2}&username={4}&TuNgay={5}&DenNgay={6}&", q, size, string.Empty,
            null, username, tuNgay, denNgay) + "{1}={0}";

        using (var con = DAL.con())
        {
            var pager = BinhLuanDal.PagerNormal(con, pgUrl, false, "BL_ID DESC", Convert.ToInt32(size), q, username, tuNgay,
                                           denNgay);
            AdminList.Pager = pager;
        }
    }
}