using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_nhom_NhomView : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    public List<Blog> Blogs { get; set; }
    public List<Blog> Topics { get; set; }
    public List<Blog> QAs { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        NhomHeader.Item = Item;
        NhomInfo.Item = Item;
        ListBlogForNhom.List = Blogs;
        ListThreadForNhom.List = Topics;
    }
}