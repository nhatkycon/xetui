using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_cars_view : System.Web.UI.UserControl
{
    public Xe Item { get; set; }
    public List<DanhMuc> HangList { get; set; }
    public List<DanhMuc> ThanhPhoList { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
    }
}