using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.common;

public partial class lib_lab_SesEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        omail.SesSend("danhbaspa@gmail.com","Chào baby","Nhận được nhớ reply cho bố nhé", "xetui.vn@gmail.com");
    }
}