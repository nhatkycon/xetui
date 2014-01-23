using System;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.core.dal;

public partial class html_car_blog_view : System.Web.UI.Page
{
    public Xe Item { get; set; }
    public Blog Blog { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item = new Xe();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                var blog = BlogDal.SelectById(con, Convert.ToInt64(Id), Security.Username);
                Blog = blog;
                Item = XeDal.SelectByRowIdUsername(con, blog.PID_ID, Security.Username);
                Item.Anhs = AnhDal.SelectByPId(con, Item.RowId.ToString(), 20);
                Item.Member = MemberDal.SelectByUser(con, Item.NguoiTao);
                viewForCar.Pager = BinhLuanDal.PagerByPRowId(con, "", true, blog.RowId.ToString(), 20);
                viewForCar.Blog = blog;
            }
            viewForCar.Item = Item;
        }
    }
}