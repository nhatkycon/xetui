using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_cars_templates_ProfileLikedCar_Item : System.Web.UI.UserControl
{
    public Xe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        LikeBtn.Liked = Item.Liked;
        LikeBtn.RowId = Item.RowId;
    }
}