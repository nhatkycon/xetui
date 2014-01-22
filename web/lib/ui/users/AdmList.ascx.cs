using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_users_AdmList : System.Web.UI.UserControl
{
    public Pager<Member> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pager == null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}