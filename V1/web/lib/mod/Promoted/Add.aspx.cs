using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Promoted_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var item = new Promoted()
                       {
                           RowId = Guid.NewGuid()
                       };
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                item = PromotedDal.SelectById(Convert.ToInt32(id));
            }
            add.Item = item;
        }
    }
}