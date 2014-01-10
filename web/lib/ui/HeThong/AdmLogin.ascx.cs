using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_ui_HeThong_AdmLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Pwd.Text))
        {
            msg.Visible = true;
            return;

        }
        var ok = Security.Login(Username.Text, Pwd.Text, ckb.Checked.ToString());
        if (ok)
        {
            var ret = Request["ret"];
            Response.Redirect(string.IsNullOrEmpty(ret) ? "/Default.aspx" : Server.UrlDecode(ret));
        }
        else
        {
            msg.Visible = true;
        }
    }
}