using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_Thich_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var blogRedis = new BlogRedis(client);
        var memberRedis = new MemberRedis(client);
        var nhomRedis = new NhomRedis(client);
        var xeRedis = new XeRedis(client);

        var Id = Request["ID"];
        var liked = Request["liked"];
        var loai = Request["Loai"];
        var username = Security.Username;
        switch (subAct)
        {
            case "like":
                #region add
               if(Security.IsAuthenticated())
               {
                   var likedVal = Convert.ToBoolean(liked);
                   if(likedVal)
                   {
                       using(var con = DAL.con())
                       {
                           var item = ThichDal.SelectByPidUsernameLoai(con, Id, username, loai);
                           switch (item.Loai)
                           {
                               case 1:
                                   ObjMemberDal.DeleteByPRowIdUsername(Id, username);
                                   var xe = xeRedis.GetByRowId(item.P_ID);
                                   if (xe.Fans.Contains(username))
                                   {
                                       xe.Fans.Remove(username);
                                       xe.TotalLike -= 1;
                                   }
                                   xeRedis.Save(xe);
                                   XeDal.Update(xe);
                                   CacheHelper.Remove(string.Format(XeDal.CacheItemKey, xe.Id));
                                   break;
                               case 2:
                                   var mem = memberRedis.GetByRowId(item.P_ID);
                                   if (mem.Fans.Contains(username))
                                   {
                                       mem.Fans.Remove(username);
                                       mem.TotalLiked -= 1;
                                   }
                                   memberRedis.Save(mem);
                                   MemberDal.Update(mem);  
                                   break;
                               case 3:
                                   var blog = blogRedis.GetByRowId(item.P_ID);
                                   if (blog.NguoiThich.Contains(username))
                                   {
                                       blog.NguoiThich.Remove(username);
                                       blog.TotalLike -= 1;
                                   }
                                   blogRedis.Save(blog);
                                   BlogDal.Update(blog);  
                                   break;
                           }
                           ThichDal.DeleteById(item.ID);
                       }
                       
                   }
                   else
                   {
                      var item= ThichDal.Insert(new Thich()
                                           {
                                               ID = Guid.NewGuid()
                                               , NgayTao = DateTime.Now
                                               , P_ID = new Guid(Id)
                                               , Username = Security.Username
                                               , Loai = Convert.ToInt32(loai)
                                           });
                       switch (item.Loai)
                       {
                           case 1:
                               var xe = xeRedis.GetByRowId(item.P_ID);
                               if (xe.Fans.Contains(username))
                               {
                                   xe.Fans.Insert(0, username);
                                   xe.TotalLike += 1;
                               }
                               xeRedis.Save(xe);
                               XeDal.Update(xe);
                               CacheHelper.Remove(string.Format(XeDal.CacheItemKey, xe.Id));
                               ObjMemberDal.Insert(new ObjMember()
                                                       {
                                                           PRowId = xe.RowId
                                                           ,
                                                           Username = username
                                                           , Owner = false
                                                           , NgayTao = DateTime.Now
                                                           , RowId = Guid.NewGuid()
                                                       });
                               break;
                           case 2:
                               var mem = memberRedis.GetByRowId(item.P_ID);
                               if (mem.Fans.Contains(username))
                               {
                                   mem.Fans.Insert(0, username);
                                   mem.TotalLiked += 1;
                               }
                               memberRedis.Save(mem);
                               MemberDal.Update(mem);                               
                               break;
                           case 3:
                               var blog = blogRedis.GetByRowId(item.P_ID);

                               if (blog.NguoiThich.Contains(username))
                               {
                                   blog.NguoiThich.Insert(0, username);
                                   blog.TotalLike += 1;
                               }
                               blogRedis.Save(blog);
                               BlogDal.Update(blog);                               
                               break;
                       }
                   }
               }
                break;
                #endregion
            default:
                break;

        }
    }
}