using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_CarByModelXe : System.Web.UI.Page
{
    public DanhMuc Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var allModel = DanhMucDal.SelectByLdmMaFromCache("HANGXE");

        var url = string.Empty;
        var ten = Request["Ten"];
        using (var con = DAL.con())
        {
            var item = allModel.FirstOrDefault(x => x.Ma == ten);
            if (item == null) return;
            item.Hang = allModel.FirstOrDefault(x => x.PID == item.PID); 
            Item = item;

            var pager = XeDal.PagerByHang(con, url, false, null, 50, null, null, item.ID.ToString(), Security.Username);
            ListByModelXe.Pager = pager;
            ListByModelXe.Item = item;

        }
    }
}