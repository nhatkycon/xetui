using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_account_profile_about : System.Web.UI.UserControl
{
    public Member Item { get; set; }
    public List<Xe> Xes { get; set; }
    public List<Nhom> Nhoms { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Nhoms!= null)
        {
            ListForProfile.Visible = (Nhoms.Count > 0);
            ListForProfile.List = Nhoms;
        }
        if(Xes != null)
        {
            var xeMoi = Xes.Where(x => x.DangLai).ToList();
            xeMoiList.List = xeMoi;

            var xeCu = Xes.Where(x => !x.DangLai).ToList();

            xeCuList.List = xeCu;
        }
    }
}