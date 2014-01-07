using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_ui_HeThong_LikeBtn : System.Web.UI.UserControl
{
    public Guid RowId { get; set; }
    public bool Liked { get; set; }
    public string Css { get; set; }
    public string Loai { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}