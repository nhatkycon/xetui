using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class html_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ret = Request["return"];
        if (!string.IsNullOrEmpty(ret))
            ret = Server.UrlDecode(ret);
        if (!Security.IsAuthenticated()) return;
        if(!string.IsNullOrEmpty(ret))
            Response.Redirect(ret);
        Response.Redirect("~/");
    }
}