using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_ui_HeThong_login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Visible = !Security.IsAuthenticated();
    }
}