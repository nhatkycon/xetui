using System;
using docsoft.entities;

public partial class lib_ui_blog_NhomBlog_templates_Item_View : System.Web.UI.UserControl
{
    public Blog Blog { get; set; }
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Blog.Liked;
        likeBtn.RowId = Blog.RowId;
    }
}