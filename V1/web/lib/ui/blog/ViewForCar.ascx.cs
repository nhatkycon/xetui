using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_blog_ViewForCar : System.Web.UI.UserControl
{
    public Blog Blog { get; set; }
    public Xe Item { get; set; }
    public List<DanhMuc> HangList { get; set; }
    public List<DanhMuc> ThanhPhoList { get; set; }
    public string Id { get; set; }
    public Pager<BinhLuan> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        BinhLuanList.Pager = Pager;
        BinhLuanList.PRowId = Blog.RowId.ToString();
        ViewCarInfo.Item = Item;
        viewCarSlider.Item = Item;
        blogViewItem.Blog = Blog;
    }
}