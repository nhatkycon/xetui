using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_cars_promotedCars : System.Web.UI.UserControl
{
    public List<Xe> List { get; set; }
    public bool Logged { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Logged = Security.IsAuthenticated();
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}