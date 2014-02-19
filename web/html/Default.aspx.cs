using System;
using System.Linq;
using ServiceStack.Redis;
using docsoft.entities;
using linh.core.dal;

public partial class html_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var alias = Request["Alias"];
        using (var con = DAL.con())
        {
            var objRedis = new ObjRedis(client);

            var obj = objRedis.GetByAlias(alias);
            if(obj != null && !string.IsNullOrEmpty(obj.Url))
            {
                Response.Redirect(obj.Url, true);
            }

            var memberRedis = new MemberRedis(client);
            var promotedUsers = memberRedis.GetXacNhanItems(0, 7);
            //UserHomeList.List = MemberDal.SelectPromoted(con, 8, 61);
            UserHomeList.List = promotedUsers;

            var blogRedis = new BlogRedis(client);
            //var userBlogs = BlogDal.SelectTopBlogProfile(con, 10, Security.Username, null);
            var userBlogs = blogRedis.GetNhatKyItems(0, 9);
            blogTop.List = userBlogs;
            //var carBlogs = BlogDal.SelectTopBlogXe(con, 10, Security.Username, null);
            var carBlogs = blogRedis.GetHanhTrinhItems(0, 10);
            nhatKyXeTop.List = carBlogs;


            var xeRedis = new XeRedis(client);
            //var topCars = XeDal.HomeTop;
            var topCars = xeRedis.GetAllItems(0, 9);
            //var newstpCars = XeDal.HomeNewest;
            var newstpCars = xeRedis.GetTopItems(0, 9);


            topCarsList.List = topCars;
            newestCarsList.List = newstpCars;

            promotedHome.Visible = false;
            promotedHome.HomeBig = XeDal.PromotedHomeBig.FirstOrDefault();
            promotedHome.HomeMedium = XeDal.PromotedHomeMedium.Take(2).ToList();
            promotedHome.HomeSMall = XeDal.PromotedHomeSmall.Take(4).ToList();

            var loaiDanhMucRedis = new LoaiDanhMucRedis(client);
            var hangXe = loaiDanhMucRedis.GetByAlias("HANGXE");
            
            //var hangXeList = DanhMucDal.SelectByLDMMa(con, "HANGXE");
            if(hangXe!=null)
            {
                var hangXeList = hangXe.GetDanhMuc(client);
                var hangList = (from p in hangXeList
                                where p.PID == Guid.Empty
                                select p).OrderBy(m => m.ThuTu).ToList();
                LeftMenu.List = hangList;    
            }
        }
    }
}