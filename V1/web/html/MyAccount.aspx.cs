using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_MyAccount : LoggedPage
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