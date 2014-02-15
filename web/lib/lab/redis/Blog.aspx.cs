using System;
using ServiceStack.Redis;
using docsoft.entities;

public partial class lib_lab_redis_Blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var blog = new BlogRedis(client);
        var binhLuanRedis = new BinhLuanRedis(client);
        var startDate = DateTime.Now;
        Response.Write("<h1>Blog</h1>");
        foreach (var i in blog.GetAll().GetRange(0,10))
        {
            var item = blog.GetById(Convert.ToInt64(i));
            Response.Write(string.Format("<h3>{0}:{1}</h3>", i, item.Ten));
            foreach (var b in item.BinhLuanIds)
            {
                var bluan = binhLuanRedis.GetById(Convert.ToInt32(b));
                Response.Write(string.Format("{0}:{1}<br/>", b, bluan.NoiDung));
            }
        }

        Response.Write("<h1>Member</h1>");
        var memberRedis = new MemberRedis(client);
        foreach (var i in memberRedis.GetAll())
        {
            var item = memberRedis.GetById(Convert.ToInt32(i));
            Response.Write(string.Format("<h3>{0}:{1}</h3>",i, item.Ten));
            Response.Write("<hr/>");
            foreach (var b in item.BlogIds)
            {
                var iblog = blog.GetById(Convert.ToInt64(b));
                Response.Write(string.Format("{0}:{1}<br/>", b, iblog.Ten));
            }
        }

        var endDate = DateTime.Now;
        Response.Write(string.Format("{0}",(endDate-startDate).TotalMilliseconds));
    }
}