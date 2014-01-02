using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class html_AddCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Add.Item=new Xe();
        var hangXeList = DanhMucDal.SelectByLDMMa("HANGXE");
        var hangList = (from p in hangXeList
                        where p.PID == Guid.Empty
                        select p).OrderBy(m => m.ThuTu).ToList();        
        Add.HangList = hangList;
    }
}