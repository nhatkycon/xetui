using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core;

public partial class lib_lab_CacheAll : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var js = new JavaScriptSerializer();
        //rendertext(js.Serialize(GetMembers()));
        foreach (var key in CacheHelper.GetKeys().Keys.ToList())
        {
            Response.Write(key + "<br/>");
        }
    }
}