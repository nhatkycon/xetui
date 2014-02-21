using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var alias = Request["Alias"];
        using (var con = DAL.con())
        {
            var obj = ObjDal.SelectByAlias(con, alias);
            if(!string.IsNullOrEmpty(obj.Url))
            {
                Response.Redirect(obj.Url, true);
            }

            UserHomeList.List = MemberDal.SelectPromoted(con, 8, 61);

                    
            var userBlogs = BlogDal.SelectTopBlogProfile(con, 10, Security.Username, null);
            blogTop.List = userBlogs;

            var carBlogs = BlogDal.SelectTopBlogXe(con, 10, Security.Username, null);
            nhatKyXeTop.List = carBlogs;

            var topCars = XeDal.HomeTop.Take(10);
            var newstpCars = XeDal.HomeNewest.Take(10);



            topCarsList.List = topCars.ToList();
            newestCarsList.List = newstpCars.ToList();


            promotedHome.HomeBig = XeDal.PromotedHomeBig.FirstOrDefault();
            promotedHome.HomeMedium = XeDal.PromotedHomeMedium.Take(2).ToList();
            promotedHome.HomeSMall = XeDal.PromotedHomeSmall.Take(4).ToList();

            var hangXeList = DanhMucDal.SelectByLDMMa(con, "HANGXE");
            var hangList = (from p in hangXeList
                            where p.PID == Guid.Empty
                            select p).OrderBy(m => m.ThuTu).ToList();
            LeftMenu.List = hangList;

        }
    }
}