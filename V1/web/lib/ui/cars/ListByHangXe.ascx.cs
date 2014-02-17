using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_cars_ListByHangXe : System.Web.UI.UserControl
{
    public Pager<Xe> Pager { get; set; }
    public DanhMuc Item { get; set; }
    public List<DanhMuc> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(List!=null)
        {
            ListModelByHang.List = List;
        }
        if(Pager== null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}