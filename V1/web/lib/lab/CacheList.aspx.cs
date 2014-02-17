using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_lab_CacheList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var list = List.Skip(800).Take(10);
        foreach (var i in list)
        {
            Response.Write(i + "<br/>");
        }
    }
    public List<int> List
    {
        get { 
            var c = HttpRuntime.Cache;
            var obj = c["MyList"];
            if(obj == null)
            {
                var list = new List<int>();
                for (var i = 0; i < 1000000; i++)
                {
                    list.Add(i);
                }
                c.Insert("MyList", list);
                return list;
            }
            return (List<int>) obj;
        }
    }
}