using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Profile_Fans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var u = Request["u"];
        using (var con = DAL.con())
        {
            var user = MemberDal.SelectAllByUserName(con, u, Security.Username);
            ProfileFans.Item = user;

            var pager = MemberDal.PagerFanByRowId(string.Empty, true, null, user.RowId.ToString(), Security.Username);
            ProfileFans.Pager = pager;
        }
    }
}