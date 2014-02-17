using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core;

public partial class lib_lab_Method : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.HttpMethod.Contains("GET"))
            rendertext("OK");
        rendertext(Request.HttpMethod);

    }
}