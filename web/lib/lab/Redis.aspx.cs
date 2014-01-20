using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft.entities;

public partial class lib_lab_Redis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var redisClient = new RedisClient("localhost"))
        {
            //DanhMucDal.ClearCache(CacheManager.Loai.Redis);
            //LoaiDanhMucDal.ClearCache(CacheManager.Loai.Redis);

            //var list = DanhMucDal.List;

            var dm = redisClient.As<DanhMuc>();
            var key = string.Format("urn:danhmuc:list");
            var obj = dm.Lists[key];
            Response.Write(obj.Count + "<br/>");
            foreach (var item in obj.ToList())
            {
                Response.Write(string.Format("{0}:{1}", item.Ten,item.LoaiDanhMuc.Ten));
                Response.Write(item.Ten + "<br/>");
            }
            Response.Write("<hr/>");
            foreach (var _key in dm.GetAllKeys())
            {
                Response.Write(string.Format("{0}<br/>", _key));
            }
        }
    }
}