using System;
using System.Web;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        promotedCars.List = XeDal.SelectPromoted(DAL.con(), 5, Security.Username);
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
