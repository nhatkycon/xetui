using System;
using System.Web;
using docsoft;

public partial class lib_master_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
        {
            Response.Redirect("~/lib/mod/Login.aspx?ret=" + Server.UrlEncode(Request.Url.PathAndQuery));
        }
    }
    public string domain
    {
        get
        {
            HttpContext c = HttpContext.Current;
            if (c.Request.Url.Host.ToLower() == "localhost")
            {
                return string.Format("http://{0}{1}", c.Request.Url.Host
                , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
            }
            return string.Format("http://{0}{1}", c.Request.Url.Host, (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
        }
    }
}
