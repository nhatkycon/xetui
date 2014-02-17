using System;
using docsoft.entities;
using linh.core.dal;

public partial class html_BinhLuanAll : System.Web.UI.Page
{
    public Obj Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using(var con = DAL.con())
        {
            Item = ObjDal.SelectByRowId(con, new Guid(id));
            var pager = BinhLuanDal.PagerByPRowId(con, "?{1}={0}", true, id, 20);
            ListAll.Item = Item;
            ListAll.Pager = pager;
        }
    }
}