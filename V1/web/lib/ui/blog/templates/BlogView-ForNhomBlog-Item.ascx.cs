using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_blog_templates_BlogView_ForNhomBlog_Item : System.Web.UI.UserControl
{
    public Blog Blog { get; set; }
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        likeBtn.Liked = Blog.Liked;
        likeBtn.RowId = Blog.RowId;
    }
}