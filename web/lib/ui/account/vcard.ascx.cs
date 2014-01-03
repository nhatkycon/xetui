using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_ui_account_vcard : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    public List<Xe> XeDangLai { get; set; }
    public List<Xe> XeCu { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Request["user"];
        using(var con = DAL.con())
        {
            Item = MemberDal.SelectByUser(user);
            var listCar = XeDal.SelectDuyetByNguoiTao(con, user, 20, true);
            XeDangLai = (from p in listCar
                         where p.DangLai
                         select p).ToList();
            XeCu = (from p in listCar
                         where !p.DangLai
                         select p).ToList();
        }
    }
}