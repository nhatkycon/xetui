using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_ui_account_myAccount : System.Web.UI.UserControl
{
    public Member User { get; set; }
    public List<DanhMuc> DmTinh { get; set; }
    public Obj Obj { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Visible = Security.IsAuthenticated();
        changeAlias.Item = Obj;
        TinhList.List = DmTinh;
    }
}