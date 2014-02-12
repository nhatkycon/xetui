using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft.entities;

public partial class lib_lab_RedisRelated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var danhMuc = DanhMucDal.List;
        //using (var client = new RedisClient(CacheManager.RedisAddress))
        //{
        //    var redis = client.As<Xe>();
        //    Response.Write("<hr/>");
        //    foreach (var key in redis.GetAllKeys())
        //    {
        //        Response.Write(string.Format("{0}<br/>", key));
        //    }
        //}

        //return;

        var xe = new Person()
            {
                ID = new Guid("FF2573F3-368C-46B8-A0F4-49BB4747521C")
                ,               
                Ten = "BMW 325i thần thánh"
            };
        var hangXe = new DanhMuc()
                         {
                             ID = new Guid("1a57008a-d21f-4c97-b714-61075421b80f")
                             , Ten = "BMW"
                             , PID = xe.ID
                         };
        var hangXe_1 = new DanhMuc()
        {
            ID = new Guid("4EBA0D5B-3530-4874-BEDA-139B20212450")
            ,
            Ten = "Mercedes"
            ,
            PID = xe.ID
        };
        var hangXe_2 = new DanhMuc()
        {
            ID = new Guid("C6AA2CF9-9D44-4A3A-AF29-7878012F7CFA")
            ,
            Ten = "Fyo"
            ,
            PID = xe.ID
        };
        var model = new DanhMuc()
                        {
                            ID = new Guid("26536587-bf03-4e98-a905-dac60d6e3669")
                            ,
                            Ten = "325i"
                            ,
                            PID = xe.ID
                        };
        
        using (var client = new RedisClient(CacheManager.RedisAddress))
        {
            
            var redis = client.As<Person>();
            var redisHang = client.As<DanhMuc>();

            redisHang.Store(hangXe);
            redisHang.Store(hangXe_1);
            redisHang.Store(hangXe_2);
            redisHang.Store(model);

            redis.Store(xe);
            redis.StoreRelatedEntities(xe.ID, new List<DanhMuc>()
            {
                hangXe, hangXe_1, hangXe_2, model
            });
            redis.StoreRelatedEntities(xe.Model, model);

            var hangs = redis.GetRelatedEntities<DanhMuc>(xe.ID);
            foreach (var item in hangs)
            {
                Response.Write("<hr/>" + item.Ten);
            }

            Response.Write("<hr/>");
            foreach (var key in redis.GetAllKeys())
            {
                Response.Write(string.Format("{0}<br/>", key));
            }

            Response.Write("<hr/>Deleted");
            //redis.DeleteRelatedEntities<DanhMuc>(xe.ID);
            Response.Write("<hr/>");
            foreach (var key in redis.GetAllKeys())
            {
                Response.Write(string.Format("{0}<br/>", key));
            }
        }

    }
}
public class Person
{
    public Guid ID { get; set; }
    public Guid HANG { get; set; }
    public Guid Model { get; set; }
    public string Ten { get; set; }
}