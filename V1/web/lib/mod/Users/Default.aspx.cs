using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Users_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];
        var active = Request["Active"];
        var xacNhan = Request["XacNhan"];
        if (string.IsNullOrEmpty(size)) size = "10";

        var pgUrl = string.Format(
            "?q={0}&size={1}&HANG_ID={2}&Active={3}&XacNhan={4}&TuNgay={5}&DenNgay={6}&", q, size, string.Empty,
            active, xacNhan, tuNgay, denNgay) + "{1}={0}";
        using(var con = DAL.con())
        {
            var pager = MemberDal.PagerAll(con, pgUrl, false, "MEM_ID DESC", Convert.ToInt32(size), q, xacNhan, active, tuNgay,
                                           denNgay);
            AdminList.Pager = pager;
        }
    }
}