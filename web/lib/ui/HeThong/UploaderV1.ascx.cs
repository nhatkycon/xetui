using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_HeThong_UploaderV1 : System.Web.UI.UserControl
{
    public string RowId { get; set; }
    public List<Anh> Anhs { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Anhs == null) return;
        AnhList.Visible = true;
        AnhList.DataSource = Anhs;
        AnhList.DataBind();
    }
}