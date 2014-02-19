using System;
using ServiceStack.Redis;
using docsoft.entities;
using linh.core.dal;

public partial class html_Profile_blog_view : System.Web.UI.Page
{
    public Member Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var blogRedis = new BlogRedis(client);
        var memberRedis = new MemberRedis(client);

        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item = new Member();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                var blog = blogRedis.GetById(Convert.ToInt64(Id));

                Item = memberRedis.GetByUsername(blog.NguoiTao);
                //blog.Anhs = AnhDal.SelectByPId(con, blog.RowId.ToString(), 20);
                //blog.Profile = Item;
                ViewForProfile.Xes = Item.GetXe(client);
                ViewForProfile.Nhoms = Item.GetNhom(client);
                ViewForProfile.Pager = BinhLuanDal.PagerByPRowId(con, "", true, blog.RowId.ToString(), 20);
                ViewForProfile.Blog = blog;
                ViewForProfile.Item = Item;
            }
        }
    }
}