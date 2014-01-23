using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;


public partial class html_CarsTop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            const string url = "{1}={0}";
            var pager = XeDal.PagerNormal(con, url, false, "X_TotalLike desc, X_TotalComment desc", 100, null, true.ToString()
                                          , null, null, null, null, null);
            List.Pager = pager;
        }
    }
}