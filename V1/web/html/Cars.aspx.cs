using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Cars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var url = string.Empty;
        var ten = Request["Ten"];
        using (var con = DAL.con())
        {

            var item = DanhMucDal.SelectByTen(con, ten);
            if (item == null) return;

            var allModel = DanhMucDal.SelectByLdmMaFromCache("HANGXE");
            var filterModel = (from p in allModel
                               where p.PID == item.ID
                               select p).OrderBy(m => m.ThuTu).ToList();
            ListAll.List = filterModel;
        }
    }
}