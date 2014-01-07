using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_car_blog : System.Web.UI.Page
{
    public Xe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["PID_ID"];
        var idNull = string.IsNullOrEmpty(Id);
        Item = new Xe();
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                Item = XeDal.SelectByIdUsername(con, Convert.ToInt32(Id), Security.Username);
                Item.Member = MemberDal.SelectByUser(con, Item.NguoiTao);
                var pagerBlog = BlogDal.PagerByPRowIdFull(con, string.Empty, false, null, Item.RowId.ToString(),
                                                      Security.Username);
                ListForCarFull.Pager = pagerBlog;

            }
            ListForCarFull.Item = Item;
        }
    }
}