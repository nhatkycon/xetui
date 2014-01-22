using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_AddCar : LoggedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

            var hangXeList = DanhMucDal.SelectByLdmMaFromCache(con, "HANGXE");
            var hangList = (from p in hangXeList
                            where p.PID == Guid.Empty
                            select p).OrderBy(m => m.ThuTu).ToList();
            Add.HangList = hangList;
            Add.ThanhPhoList = DanhMucDal.SelectByLdmMaFromCache(con, "KHUVUC");

        }
    }
}