using System;
using docsoft;
using docsoft.entities;

public partial class lib_ui_blog_templates_BlogView_Item : System.Web.UI.UserControl
{
    public Blog Blog { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Blog.IsLiked(Security.Username);
        likeBtn.RowId = Blog.RowId;
    }
}