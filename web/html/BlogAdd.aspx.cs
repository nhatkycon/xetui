using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class html_BlogAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var PID_ID = Request["PID_ID"];
        var Loai = Request["Loai"];
        var idNull = string.IsNullOrEmpty(Id);
        var item = new Blog()
        {
            RowId = Guid.NewGuid()
        };

        using (var con = DAL.con())
        {
            if (!idNull)
            {
                item = BlogDal.SelectById(con, Convert.ToInt32(Id));
                item.Anhs = AnhDal.SelectByPId(con, item.RowId.ToString(), 20);
            }
            else
            {
                item.PID_ID = new Guid(PID_ID);
                item.Loai = Convert.ToInt32(Loai);
            }
            Add.Id = Id;
            Add.PID_ID = PID_ID;
            Add.Loai = Loai;
            Add.Item = item;
        }
    }
}