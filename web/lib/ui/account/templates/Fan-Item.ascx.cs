﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_account_templates_Fan_Item : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.RowId = Item.RowId;
        likeBtn.Liked = Item.Liked;
    }
}