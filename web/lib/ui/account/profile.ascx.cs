using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_account_profile : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    public List<Xe> Xes { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}