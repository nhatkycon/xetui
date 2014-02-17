using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_MyCars : LoggedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            myCars.MyCarsList = XeDal.SelectDuyetByNguoiTao(con, Security.Username, 20, null);
            var pg = XeDal.PagerXeYeuThichByUsername(con, string.Empty, true, null, Security.Username);
            myCars.LikedCarsPager = pg;
        }
    }
}