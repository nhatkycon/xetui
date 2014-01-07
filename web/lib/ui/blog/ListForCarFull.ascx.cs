using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_blog_ListForCarFull : System.Web.UI.UserControl
{
    public Pager<Blog> Pager { get; set; }
    public Xe Item { get; set; }
    public string PID_ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pager == null) return;
        Pager.List.ToList().ForEach(s => s.Xe = Item);
        rpt.DataSource = Pager.List;
        rpt.DataBind();

        ViewCarInfo.Item = Item;
        viewCarSlider.Item = Item;
    }
}