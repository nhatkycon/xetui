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
        using(var con = DAL.con())
        {
            var userHomeList = (from p in MemberDal.SelectAll()
                                select p
                                ).Where(p => !string.IsNullOrEmpty(p.Anh)).Take(8).ToList();
            
            UserHomeList.List = userHomeList;

            var userBlogs = BlogDal.SelectTopBlogByLoai(con, 10, 1, Security.Username);
            blogTop.List = userBlogs;

            var carBlogs = BlogDal.SelectTopBlogByLoai(con, 10, 2, Security.Username);
            nhatKyXeTop.List = carBlogs;

            var topCars = XeDal.SelectTopCar(con, 10, Security.Username);
            var newstpCars = XeDal.SelectTopCar(con, 10, Security.Username);
            topCarsList.List = topCars;
            newestCarsList.List = newstpCars;

        }
    }
}