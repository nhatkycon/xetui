using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_NhomBlogs : System.Web.UI.Page
{
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["PID_ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item=new Nhom();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                Item = NhomDal.SelectById(con, Convert.ToInt32(Id), Security.Username);
                var pagerBlog = BlogDal.PagerByPRowIdLoaiFull(con, string.Empty, false, null, Item.RowId.ToString(),
                                                      Security.Username, 3);
                ListBlogForNhomFull1.Pager = pagerBlog;
                ListBlogForNhomFull1.Item = Item;
            }
        }
    }
}