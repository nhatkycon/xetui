using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_cars_ProfileLikedCars : System.Web.UI.UserControl
{
    public Pager<Xe> Pager { get; set; }
    public Member Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Pager==null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}