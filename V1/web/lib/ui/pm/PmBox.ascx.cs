using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_pm_PmBox : System.Web.UI.UserControl
{
    public List<Pm> List { get; set; }
    public string ToUser { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        PmList.List = List;
        PmList.RoomId = Id;
    }
}