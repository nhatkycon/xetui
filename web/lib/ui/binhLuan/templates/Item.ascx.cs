using System;
using docsoft.entities;

public partial class lib_ui_binhLuan_templates_Item : System.Web.UI.UserControl
{
    public BinhLuan Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Item == null) this.Visible = false;
    }
}