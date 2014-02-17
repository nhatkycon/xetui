using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.common;

public partial class lib_lab_TimeDiff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var d = Convert.ToDateTime(TextBox1.Text);
        Literal1.Text = Lib.TimeDiff(d);
    }
}