using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_blog_Add : System.Web.UI.UserControl
{
    public Blog Item { get; set; }
    public string Id { get; set; }
    public string PID_ID { get; set; }
    public string Loai { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        UploaderV1.RowId = Item.RowId.ToString();
        if (Id != null)
        {
            UploaderV1.Anhs = Item.Anhs;
        }
    }
}