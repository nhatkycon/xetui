using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_nhom_templates_Admin_Info : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    public Obj Obj { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ChangeAlias.Item = Obj;
    }
}