using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_adv_AdmList : System.Web.UI.UserControl
{
    public Pager<Adv> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pager == null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}