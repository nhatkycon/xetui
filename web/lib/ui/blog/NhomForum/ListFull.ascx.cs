using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_blog_NhomForum_ListFull : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    public Pager<Blog> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pager == null) return;
        Pager.List.ForEach(x => x.Nhom = Item);
        rpt.DataSource = Pager.List;
        rpt.DataBind();
        NhomHeaderForum.Item = Item;
        NhomInfo.Item = Item;
    }
}