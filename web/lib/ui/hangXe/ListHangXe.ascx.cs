using System;
using System.Collections.Generic;
using System.Linq;
using docsoft.entities;

public partial class lib_ui_hangXe_ListHangXe : System.Web.UI.UserControl
{
    public List<DanhMuc> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        

        if (List == null || !List.Any()) return;
        var xeMayDm = List.FirstOrDefault(x => x.Ma != null && x.Ma.Contains("Xe-may"));
        var otoDm = List.FirstOrDefault(x => x.Ma != null && x.Ma.Contains("Oto"));
        var xeMayList = (from p in List
                         where p.PID == xeMayDm.ID
                         select p).OrderBy(m => m.ThuTu).ToList();

        var otoList = (from p in List
                       where p.PID == otoDm.ID 
                       select p).OrderBy(m => m.ThuTu).ToList();

        otoRpt.DataSource = otoList;
        otoRpt.DataBind();

        xeMayRpt.DataSource = xeMayList;
        xeMayRpt.DataBind();
    }
}