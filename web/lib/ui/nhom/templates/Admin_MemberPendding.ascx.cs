using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_nhom_templates_Admin_MemberPendding : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    public List<NhomThanhVien> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}