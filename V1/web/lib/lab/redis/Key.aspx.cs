using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft.entities;
public partial class lib_lab_redis_Key : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var redisClient = new RedisClient("localhost"))
        {
            var dm = redisClient.As<DanhMuc>();
            foreach (var _key in dm.GetAllKeys())
            {
                Response.Write(string.Format("{0}<br/>", _key));
            }
        }
    }
}