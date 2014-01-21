using System;
using System.Collections.Generic;
using System.Linq;
using docsoft.entities;

public partial class lib_ui_cars_carsInAccountPage : System.Web.UI.UserControl
{
    public string Ten { get; set; }
    public List<Xe> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Visible = (List != null && List.Any());
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}