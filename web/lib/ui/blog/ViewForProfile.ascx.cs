using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_blog_ViewForProfile : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    public Blog Blog { get; set; }
    public string Id { get; set; }
    public Pager<BinhLuan> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        BinhLuanList.Pager = Pager;
        BinhLuanList.PRowId = Blog.RowId.ToString();
        profileInfo.Item = Item;
        profileAbout.Item = Item;
        blogViewItem.Blog = Blog;
    }
}