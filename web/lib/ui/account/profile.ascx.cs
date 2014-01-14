using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;
using linh.core.dal;

public partial class lib_ui_account_profile : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    public List<Xe> Xes { get; set; }
    public Pager<Blog> Pager { get; set; }
    public List<Nhom> Nhoms { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
            profileInfo.Item = Item;
            profileAbout.Nhoms = Nhoms;
            profileAbout.Item = Item;
            profileAbout.Xes = Xes;

            if (Pager == null) return;
            Pager.List.ToList().ForEach(s => s.Profile = Item);
            rpt.DataSource = Pager.List;
            rpt.DataBind();    
        
    }
}