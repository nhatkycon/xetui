using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class html_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            var userHomeList = (from p in MemberDal.SelectAll()
                                select p
                                ).Where(p => !string.IsNullOrEmpty(p.Anh)).Take(8).ToList();
            
            UserHomeList.List = userHomeList;
        }
    }
}