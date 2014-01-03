using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_binhLuan_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var txt = Request["txt"];
        var PRowId = Request["PRowId"];
        var Id = Request["Id"];
        var PBL_ID = Request["P_Id"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(Id);
        switch (subAct)
        {
            case "save":
                #region save comment
                if(logged && !string.IsNullOrEmpty(PRowId))
                {
                    var item = idNull ? new BinhLuan() : BinhLuanDal.SelectById(Convert.ToInt64(Id));
                    item.NoiDung = txt;
                    
                    if(idNull)
                    {
                        item.Username = Security.Username;
                        item.NgayTao = DateTime.Now;
                        if (!string.IsNullOrEmpty(PBL_ID))
                        {
                            item.PBL_ID = Convert.ToInt64(PBL_ID);
                        }
                        if (!string.IsNullOrEmpty(PRowId))
                        {
                            item.P_RowId = new Guid(PRowId);
                        }
                        item.RowId = Guid.NewGuid();
                        item = BinhLuanDal.Insert(item);
                    }
                    else
                    {
                        item = BinhLuanDal.Update(item);
                    }
                    Item.Item = item;
                    Item.Visible = true;
                }
                break;
                #endregion
            case "remove":
                #region remove comment
                break;
                #endregion
            case "getById":
                #region get comment by id
                break;
                #endregion
        }
    }
}