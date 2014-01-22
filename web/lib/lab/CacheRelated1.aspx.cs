using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;

public partial class lib_lab_CacheRelated1 : BasedPage
{
    private const string BlogKey = "blog:ID:{0}";
    private const string MemKey = "mem:ID:{0}";

    protected void Page_Load(object sender, EventArgs e)
    {
        var key = string.Format(MemKey, "46");
        CacheHelper.Remove(key);
    }
}