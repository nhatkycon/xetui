using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_mod_Blog_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var item = new Blog()
        {
            RowId = Guid.NewGuid()
        };
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                item = BlogDal.SelectById(Convert.ToInt32(id));
            }
        }
        Add.Item = item;
    }
}