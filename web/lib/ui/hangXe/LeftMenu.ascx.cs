using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_hangXe_LeftMenu : System.Web.UI.UserControl
{
    public List<DanhMuc> Oto { get; set; }
    public List<DanhMuc> XeMay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Oto != null)
        {
            otoRpt.DataSource = Oto;
            otoRpt.DataBind();    
        }
        if (XeMay == null) return;
        xeMayRpt.DataSource = XeMay;
        xeMayRpt.DataBind();
    }
}