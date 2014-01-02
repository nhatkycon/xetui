using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_ui_HeThong_userbar : System.Web.UI.UserControl
{
    public Member User { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Visible = Security.IsAuthenticated();
        User = MemberDal.SelectAllByUserName(Security.Username);
    }
}