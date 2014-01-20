using System;
using docsoft.entities;
using linh.core.dal;
public partial class lib_mod_Promoted_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];
        var duyet = Request["Duyet"];
        var loai = Request["Loai"];
        if (string.IsNullOrEmpty(size)) size = "10";

        var pgUrl = string.Format(
            "?q={0}&size={1}&Duyet={3}&TuNgay={4}&DenNgay={5}&", q, size, string.Empty,
            duyet, tuNgay, denNgay) + "{1}={0}";

        var pg = PromotedDal.PagerNormal(pgUrl, false,null,q,Convert.ToInt32(size), tuNgay,denNgay,loai,duyet);
        List.Pager = pg;
    }
}