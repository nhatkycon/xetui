using System;
using docsoft.entities;

public partial class lib_ui_blog_templates_ForNhom_Blog_Item_Full : System.Web.UI.UserControl
{
    public Blog Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Item.Liked;
        likeBtn.RowId = Item.RowId;
    }
}