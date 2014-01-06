using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

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
                       ThichDal.DeleteByPIdUsername(new Guid(Id),Security.Username);
                   }
                   else
                   {
                       ThichDal.Insert(new Thich()
                                           {
                                               ID = Guid.NewGuid()
                                               , NgayTao = DateTime.Now
                                               , P_ID = new Guid(Id)
                                               , Username = Security.Username
                                               , Loai = Convert.ToInt32(loai)
                                           });
                   }
               }
                break;
                #endregion
            default:
                break;

        }
    }
}