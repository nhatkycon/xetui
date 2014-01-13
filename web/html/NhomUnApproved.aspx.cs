using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_NhomUnApproved : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        using (var con = DAL.con())
        {
            var item = NhomDal.SelectById(con, Convert.ToInt32(id), Security.Username);
            UnApproved1.Item = item;
        }
    }
}