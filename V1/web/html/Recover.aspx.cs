using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class html_Recover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["Id"];
        var key = Request["Key"];
        if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(key))
        {
            var user = MemberDal.SelectById(Convert.ToInt32(Id));
            QuenMatKhau.Recovering = false;
            if (user.DiaChi == key)
            {
                QuenMatKhau.Id = Id;
                QuenMatKhau.Correct = true;
            }
            else
            {
                QuenMatKhau.Correct = false;
            }
        }
        else
        {
            QuenMatKhau.Recovering = true;
        }
    }
}