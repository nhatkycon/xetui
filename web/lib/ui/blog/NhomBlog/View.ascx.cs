using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_blog_NhomBlog_View : System.Web.UI.UserControl
{
    public Blog Blog { get; set; }
    public Nhom Item { get; set; }
    public Pager<BinhLuan> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        NhomInfo.Item = Item;
        NhomHeaderBlog.Item = Item;
        BinhLuanList.Pager = Pager;
        BinhLuanList.PRowId = Blog.RowId.ToString();
        Blog.Nhom = Item;
        ItemView.Item = Item;
        ItemView.Blog = Blog;
    }
}