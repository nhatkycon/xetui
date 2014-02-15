using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_nhom_Nhom_Info : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Item.Duyet)
        {
            Server.Transfer(string.Format("~/html/NhomUnApproved.aspx?ID={0}", Item.Id));
        }
    }
}