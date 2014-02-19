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
            var k = Request["k"];
            if(!string.IsNullOrEmpty(k))
            {
                var obj = redisClient.Get(k);
                if(obj != null)
                {
                    string result = System.Text.Encoding.UTF8.GetString(obj);
                    Response.Write(result);
                }
                return;
            }
            foreach (var _key in redisClient.GetAllKeys())
            {
                Response.Write(string.Format(@"<a href=""?k={0}"">{0}</a><br/>", _key));
            }
        }
    }
}