using System;
using docsoft.entities;

public partial class lib_ui_blog_templates_ForCar_ItemFull : System.Web.UI.UserControl
{
    public Blog Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Item.Liked;
        likeBtn.RowId = Item.RowId;
    }
}