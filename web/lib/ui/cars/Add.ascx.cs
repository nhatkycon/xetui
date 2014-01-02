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
    protected void Page_Load(object sender, EventArgs e)
    {
        HANG_ID.List = HangList;       
    }
}