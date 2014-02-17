using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_pm_pmNotificationList : System.Web.UI.UserControl
{
    public List<Pm> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}