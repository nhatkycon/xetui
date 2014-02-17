﻿using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_cars_homeSmallList : System.Web.UI.UserControl
{
    public string Title { get; set; }
    public List<Xe> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}