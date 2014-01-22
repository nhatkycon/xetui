using System;
using linh.core;

namespace docsoft
{
    public class LoggedPage:BasedPage
    {
        protected override void OnInit(EventArgs e)
        {
            if(!Security.IsAuthenticated())
            {
                var url = Request.RawUrl;
                Response.Redirect("~/login/?return=" + Server.UrlEncode(url));
            }
            base.OnInit(e);
        }
    }
}
