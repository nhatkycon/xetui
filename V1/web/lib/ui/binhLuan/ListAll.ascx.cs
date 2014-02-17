using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_binhLuan_ListAll : System.Web.UI.UserControl
{
    public Pager<BinhLuan> Pager { get; set; }
    public string PRowId { get; set; }
    public Obj Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pager == null)
            return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}