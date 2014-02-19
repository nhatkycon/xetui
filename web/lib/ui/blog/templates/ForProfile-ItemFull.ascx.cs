using System;
using docsoft;
using docsoft.entities;

public partial class lib_ui_blog_templates_ForProfile_ItemFull : System.Web.UI.UserControl
{
    public Blog Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Item.IsLiked(Security.Username);
        likeBtn.RowId = Item.RowId;
    }
}