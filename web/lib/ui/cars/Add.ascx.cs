using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_cars_Add : System.Web.UI.UserControl
{
    public Xe Item { get; set; }
    public List<DanhMuc> HangList { get; set; }
    public List<DanhMuc> ThanhPhoList { get; set; }
    public string Id { get; set; }
    public string Css { get; set; }
    public bool IsAdmin { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {        
        Id = Request["ID"];
        HANG_ID.List = HangList;
        THANHPHO_ID.List = ThanhPhoList;

        if(Id!=null)
        {
            UploaderV1.RowId = Item.RowId.ToString();
            UploaderV1.Anhs = Item.Anhs;
        }
    }
}