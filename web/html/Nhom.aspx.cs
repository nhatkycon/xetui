using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Nhom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            var listDuyet = NhomDal.SelectDuyet(Security.Username, 100, "true");
            List.List = listDuyet;
        }
    }
}