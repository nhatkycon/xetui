using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_HeThong_DanhMucListByLdmMa : System.Web.UI.UserControl
{
    public string ControlId { get; set; }
    public string ControlName { get; set; }
    public List<DanhMuc> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}