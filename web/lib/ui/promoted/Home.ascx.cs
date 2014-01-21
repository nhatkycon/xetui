using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_promoted_Home : System.Web.UI.UserControl
{
    public Xe HomeBig { get; set; }
    public List<Xe> HomeMedium { get; set; }
    public List<Xe> HomeSMall { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(HomeBig!= null)
        {
            ItemBig.Item = HomeBig;
        }
        else
        {
            ItemBig.Visible = false;
        }
        if (HomeMedium != null)
        {
            homeMedium.DataSource = HomeMedium;
            homeMedium.DataBind();
        }
        if (HomeSMall != null)
        {
            homeSmall.DataSource = HomeSMall;
            homeSmall.DataBind();
        }
    }
}