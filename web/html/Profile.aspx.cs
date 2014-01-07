using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var u = Request["u"];
        using(var con = DAL.con())
        {
            var user = MemberDal.SelectAllByUserName(con, u, Security.Username);
            profile.Item = user;
            profile.Xes = XeDal.SelectDuyetByNguoiTao(con, Security.Username, 20, null);

            var pagerBlog = BlogDal.PagerByPRowIdFull(con, string.Empty, false, null, user.RowId.ToString(),
                                                      Security.Username);
            profile.Pager = pagerBlog;
        }
    }
}