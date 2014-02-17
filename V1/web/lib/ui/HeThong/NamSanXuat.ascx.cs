using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_ui_HeThong_NamSanXuat : System.Web.UI.UserControl
{
    public string ControlId { get; set; }
    public string ControlName { get; set; }
    public List<string> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        List=new List<string>();
        for (var i = DateTime.Now.Year; i >= 1970; i--)
        {
            List.Add(i.ToString());
        }
    }
}