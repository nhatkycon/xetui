using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_cars_ListNewest : System.Web.UI.UserControl
{
    public Pager<Xe> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Pager==null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}