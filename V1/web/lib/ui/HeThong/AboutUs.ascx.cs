using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_HeThong_AboutUs : System.Web.UI.UserControl
{
    public string AboutUs { get; set; }
    public string Rules { get; set; }
    public string Support { get; set; }
    public string Ads { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var list = DanhMucDal.List;
        var aboutUs = list.FirstOrDefault(x => x.Ma == "HETHONG-ABOUT-US");
        if (aboutUs != null)
            AboutUs = aboutUs.Description;

        var rules = list.FirstOrDefault(x => x.Ma == "HETHONG-RULES");
        if (rules != null)
            Rules = rules.Description;

        var support = list.FirstOrDefault(x => x.Ma == "HETHONG-SUPPORT");
        if (support != null)
            Support = support.Description;

        var ads = list.FirstOrDefault(x => x.Ma == "HETHONG-ADS");
        if (ads != null)
            Ads = ads.Description;
    }
}