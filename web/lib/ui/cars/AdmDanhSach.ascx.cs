using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_cars_AdmDanhSach : System.Web.UI.UserControl
{
    public Pager<Xe> Pager { get; set; }
    public List<DanhMuc> HangList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        HANG_ID.List = HangList;
        if (Pager == null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}