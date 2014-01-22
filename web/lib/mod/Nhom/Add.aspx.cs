using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Nhom_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var item = new Nhom()
        {
            RowId = Guid.NewGuid()
        };
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                item = NhomDal.SelectById(Convert.ToInt32(id));
            }
        }
        Add.Item = item;
        Add.IsAdmin = true;
    }
}