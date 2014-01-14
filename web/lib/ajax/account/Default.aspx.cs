using System;
using System.IO;
using System.Net;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_account_Default : BasedPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var dic = Server.MapPath("~/lib/up/users/");
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var Mobile = Request["Mobile"];
        var Tinh_ID = Request["Tinh_ID"];
        var Alias = Request["Alias"];
        var rowId = Request["RowId"];
        switch (subAct)
        {
            case "changeAvatar":
                #region change avatar
                if(logged)
                {
                    if(Request.Files.Count > 0)
                    {
                        var img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        if(img.Width > img.Heigth)
                        {
                            img.ResizeHeight(180);
                        }
                        else
                        {
                            img.Resize(180);
                        }
                        img.Crop(180, 180);
                        var user = MemberDal.SelectByUser(Security.Username);
                        var anh = dic + user.Anh;
                        if(!string.IsNullOrEmpty(anh))
                        {
                            if(File.Exists(anh))
                                File.Delete(anh);
                        }
                        var anhNew = string.Format("{0}{1}", user.ID, img.Ext);
                        img.Save(dic + anhNew);
                        MemberDal.UpdateAnh(Security.Username,anhNew);
                        rendertext(anhNew);
                    }
                }
                rendertext("0");
                break;
                #endregion
            case "validateAlias":
                #region validate object alias
                if (logged && !string.IsNullOrEmpty(rowId) && !string.IsNullOrEmpty(Alias))
                {
                    var RowId = new Guid(rowId);
                    var obj = ObjDal.SelectByAlias(Alias);
                    if(obj.ID == Guid.Empty)
                    {
                        rendertext("1");
                    }
                    else
                    {
                        if (obj.RowId == RowId)
                        {
                            rendertext("1");
                        }
                        else
                        {
                            rendertext("0");
                        }
                    }
                    rendertext("0");
                }
                rendertext("0");
                break;
                #endregion
            case "saveAlias":
                #region validate object alias
                if (logged && !string.IsNullOrEmpty(rowId) && !string.IsNullOrEmpty(Alias))
                {
                    var RowId = new Guid(rowId);
                    var obj = ObjDal.SelectByAlias(Alias);
                    if (obj.ID == Guid.Empty)
                    {
                        obj = ObjDal.SelectByRowId(RowId);
                        obj.Alias = Alias;
                        ObjDal.Update(obj);
                        rendertext("1");
                    }
                    else
                    {
                        if (obj.RowId == RowId)
                        {
                            rendertext("1");
                        }
                        else
                        {
                            rendertext("0");
                        }
                    }
                    rendertext("0");
                }
                rendertext("0");
                break;
                #endregion
            case "GetVcard":
                #region change avatar
                vcard.Visible = true;
                break;
                #endregion
            case "saveInformation":
                #region Store information
                if (logged && !string.IsNullOrEmpty(Ten))
                {
                    var user = MemberDal.SelectByUser(Security.Username);
                    if(!string.IsNullOrEmpty(Tinh_ID))
                    {
                        user.Tinh = new Guid(Tinh_ID);
                    }
                    user.Ten = Ten;
                    user.Mota = MoTa;
                    user.Mobile = Mobile;
                    user.NgayCapNhat = DateTime.Now;
                    user = MemberDal.Update(user);
                    Security.Login(user.Username, "true");
                    MemberDal.UpdateVcard(DAL.con(), user.Username);
                    rendertext("1");
                }
                rendertext("0");
                break;
                #endregion
        }
    }
}