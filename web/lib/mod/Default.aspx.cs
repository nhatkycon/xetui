using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;

public partial class lib_mod_Default : System.Web.UI.Page
{
    public List<string> CacheKeys { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            CacheKeys = CacheHelper.GetKeys().Keys.ToList();
        }
    }
    protected void btnReindex_Click(object sender, EventArgs e)
    {
        SearchManager.ReIndex();
    }
    protected void btnClearCache_Click(object sender, EventArgs e)
    {
        CacheHelper.Clear();
    }
}