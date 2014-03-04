using System;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class html_car_view : System.Web.UI.Page
{
    public Xe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var idNull = string.IsNullOrEmpty(Id);
        var logged = Security.IsAuthenticated();
        Item = new Xe();
        view.Visible = false;
        Missing.Visible = true;
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                Item = logged
                           ? XeDal.SelectByIdUsername(con, Convert.ToInt32(Id), Security.Username)
                           : XeDal.SelectByIdUsername(con, Convert.ToInt32(Id), Security.Username);

                
                Item.Anhs = AnhDal.SelectByPId(con, Item.RowId.ToString(), 20);
                Item.Member = MemberDal.SelectByUser(con, Item.NguoiTao);
                view.Pager = BinhLuanDal.PagerByPRowId(con, "", true, Item.RowId.ToString(), 20);
                var pagerBlog = BlogDal.PagerByPRowId(string.Empty, false, null, Item.RowId.ToString(),
                                                      Security.Username);
                view.PagerBlog = pagerBlog;
                view.Item = Item;
                if (Item.Id == 0)
                {
                    return;
                }
                view.Visible = true;
                Missing.Visible = false;
            }
        }
    }
}