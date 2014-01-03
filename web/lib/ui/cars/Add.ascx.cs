using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_cars_Add : System.Web.UI.UserControl
{
    public Xe Item { get; set; }
    public List<DanhMuc> HangList { get; set; }
    public List<DanhMuc> ThanhPhoList { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        HANG_ID.List = HangList;
        THANHPHO_ID.List = ThanhPhoList;
        if(Id!=null)
        {
            AnhList.Visible = true;
            AnhList.DataSource = Item.Anhs;
            AnhList.DataBind();
        }
    }
}