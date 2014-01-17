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

            var userHomeList = (from p in MemberDal.SelectAll()
                                select p
                                ).Where(p => !string.IsNullOrEmpty(p.Anh)).Take(8).ToList();
            
            UserHomeList.List = userHomeList;

                    
            var userBlogs = BlogDal.SelectTopBlogProfile(con, 10, Security.Username);
            blogTop.List = userBlogs;

            var carBlogs = BlogDal.SelectTopBlogXe(con, 10, Security.Username);
            nhatKyXeTop.List = carBlogs;

            var topCars = XeDal.SelectTopCar(con, 10, Security.Username);
            var newstpCars = XeDal.SelectTopCar(con, 10, Security.Username);
            topCarsList.List = topCars;
            newestCarsList.List = newstpCars;

            var hangXeList = DanhMucDal.SelectByLdmMaFromCache(con, "HANGXE");
            var hangList = (from p in hangXeList
                            where p.PID == Guid.Empty
                            select p).OrderBy(m => m.ThuTu).ToList();
            LeftMenu.List = hangList;

        }
    }
}