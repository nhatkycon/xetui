using System;
using System.Linq;
using ServiceStack.Redis;
using docsoft.entities;

public partial class html_Profile : System.Web.UI.Page
{
    public Member Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var u = Request["u"];
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var memberRedis = new MemberRedis(client);
        var user = memberRedis.GetByUsername(u);
        Item = user;
        profile.Item = user;
        profile.Xes = user.GetXe(client);
        profile.Nhoms = user.GetNhom(client);
        profile.List = user.GetBlogs(client);
    }
}