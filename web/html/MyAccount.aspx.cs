using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            myAcc.User = MemberDal.SelectAllByUserName(con, Security.Username);
            myAcc.DmTinh = DanhMucDal.SelectByLDMMa(con, "KHUVUC");
            myAcc.Obj = ObjDal.SelectByRowId(con, myAcc.User.RowId);
        }
        
    }
}