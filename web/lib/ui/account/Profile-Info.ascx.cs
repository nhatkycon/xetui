using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_account_Profile_Info : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Item.Liked;
        likeBtn.RowId = Item.RowId;
    }
}