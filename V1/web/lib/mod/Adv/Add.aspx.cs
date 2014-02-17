using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Adv_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var item = new Adv()
        {
            RowId = Guid.NewGuid()
        };
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                item = AdvDal.SelectById(new Guid(id));
            }
            Add.Item = item;
        }
    }
}