using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class html_RegisterDone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Security.IsAuthenticated())
        {
            SignUpDone.Item = MemberDal.SelectAllByUserName(Security.Username);
        }
        else
        {
            Response.Redirect("~/");
        }
    }
}