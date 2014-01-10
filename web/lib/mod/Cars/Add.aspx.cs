using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Cars_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Add.IsAdmin = true;
        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        var Item = new Xe()
        {
            RowId = Guid.NewGuid()
        };

        using (var con = DAL.con())
        {
            if (!idNull)
            {
                Item = XeDal.SelectById(con, Convert.ToInt32(Id));
                Item.Anhs = AnhDal.SelectByPId(con, Item.RowId.ToString(), 20);
            }

            Add.Item = Item;

            var hangXeList = DanhMucDal.SelectByLDMMa(con, "HANGXE");
            if (Cache["HANGXE"] == null)
            {
                Cache.Insert("HANGXE", hangXeList);
            }

            var hangList = (from p in hangXeList
                            where p.PID == Guid.Empty
                            select p).OrderBy(m => m.ThuTu).ToList();
            Add.HangList = hangList;
            Add.ThanhPhoList = DanhMucDal.SelectByLDMMa(con, "KHUVUC");

        }
    }
}