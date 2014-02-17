using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_nhom_ListForProfile : System.Web.UI.UserControl
{
    public List<Nhom> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        rptNhom.Visible = (List != null && List.Count > 0);
        rptNhom.DataSource = List;
        rptNhom.DataBind();
    }
}