using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_binhLuan_List : System.Web.UI.UserControl
{
    public Pager<BinhLuan> Pager { get; set; }
    public string PRowId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Pager==null)
            return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}