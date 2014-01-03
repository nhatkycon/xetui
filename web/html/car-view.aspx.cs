using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class html_car_view : BasedPage
{
    public Xe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item = new Xe();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                Item = XeDal.SelectById(con, Convert.ToInt32(Id));
                Item.Anhs = AnhDal.SelectByPId(con, Item.RowId.ToString(), 20);
                Item.Member = MemberDal.SelectByUser(con, Item.NguoiTao);
                view.Pager = BinhLuanDal.PagerByPRowId(con, "", true, Item.RowId.ToString(), 20);

            }
            view.Item = Item;
        }
    }
}