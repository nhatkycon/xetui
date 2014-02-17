using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_NhomBlogView : System.Web.UI.Page
{
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item = new Nhom();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                var blog = BlogDal.SelectById(con, Convert.ToInt64(Id), Security.Username);

                Item = NhomDal.SelectByRowId(con, blog.PID_ID, Security.Username);

                //blog.Anhs = AnhDal.SelectByPId(con, blog.RowId.ToString(), 20);
                //blog.Nhom = Item;

                View.Pager = BinhLuanDal.PagerByPRowId(con, "", true, blog.RowId.ToString(), 20);
                View.Blog = blog;
                View.Item = Item;
            }
        }
    }
}