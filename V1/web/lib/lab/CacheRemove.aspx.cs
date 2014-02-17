using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core;

public partial class lib_lab_CacheRemove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CacheHelper.Clear();
    }
}