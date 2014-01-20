using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class html_Search : System.Web.UI.Page
{
    public bool NullQuery { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var q = Request["q"];
        NullQuery = string.IsNullOrEmpty(q);
        if(NullQuery) return;
        var list = SearchManager.Search(q);
        search1.List = list;
    }
}