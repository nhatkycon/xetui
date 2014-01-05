using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_thongBao_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var js = new JavaScriptSerializer();
        switch (subAct)
        {
            case "notifications":
            #region get notifications
                if(logged)
                {
                    var list = new List<int>();
                    list.Add(systemMessageDal.NewByUser(Security.Username));
                    list.Add(PmDal.NewByUser(Security.Username));
                    rendertext(js.Serialize(list));
                }
                break;
            #endregion
            case "notifications-get":
                #region get notifications list
                if (logged)
                {
                    var list = systemMessageDal.SelectByUser(Security.Username, 5, false);
                    notificationList.Visible = true;
                    notificationList.List = list;
                }
                break;
            #endregion
            case "notifications-view":
                #region get notification
                
                break;
                #endregion
        }
    }
}