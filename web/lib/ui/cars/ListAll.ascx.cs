﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_cars_ListAll : System.Web.UI.UserControl
{
    public List<DanhMuc> List { get; set; }
    public DanhMuc Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List != null)
        {
            ListHangXe.List = List;
        }
    }
}