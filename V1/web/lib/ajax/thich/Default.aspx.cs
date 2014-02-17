using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_Thich_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var liked = Request["liked"];
        var loai = Request["Loai"];
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
                           var item = ThichDal.SelectByPidUsernameLoai(con, Id, Security.Username, loai);
                           switch (item.Loai)
                           {
                               case 1:
                                   ObjMemberDal.DeleteByPRowIdUsername(Id,Security.Username);
                                   var xe = XeDal.SelectByRowId(item.P_ID);
                                   CacheHelper.Remove(string.Format(XeDal.CacheItemKey, xe.Id));
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
                               var xe = XeDal.SelectByRowId(item.P_ID);
                               CacheHelper.Remove(string.Format(XeDal.CacheItemKey, xe.Id));
                               ObjMemberDal.Insert(new ObjMember()
                                                       {
                                                           PRowId = xe.RowId
                                                           , Username = Security.Username
                                                           , Owner = false
                                                           , NgayTao = DateTime.Now
                                                           , RowId = Guid.NewGuid()
                                                       });
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