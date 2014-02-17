using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class html_ActiveEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["Id"];
        var key = Request["Key"];
        if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(key))
        {
            var user = MemberDal.SelectById(Convert.ToInt32(Id));
            activeEmail.Item = user;
            if (user.DiaChi == key)
            {
                user.DiaChi = string.Empty;
                user.Password = null;
                user.XacNhan = true;
                user.NgayXacNhan = DateTime.Now;
                MemberDal.Update(user);
                activeEmail.Done = true;
            }
            else
            {
                activeEmail.Done = false;
            }
        }
        else
        {
            Security.LogOut();
            activeEmail.Item=new Member();
            activeEmail.Done = false;
        }
    }
}