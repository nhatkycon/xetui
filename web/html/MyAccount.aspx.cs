using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class html_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        myAcc.User = MemberDal.SelectAllByUserName(Security.Username);
        myAcc.DmTinh = DanhMucDal.SelectByLDMMa("KHUVUC");
    }
}