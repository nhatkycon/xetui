﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core;

public partial class lib_ajax_binhLuan_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();

        var txt = Request["txt"];
        var noiDung = Request["NoiDung"];
        var PRowId = Request["PRowId"];
        var Id = Request["Id"];
        var PBL_ID = Request["PBL_ID"];
        var cUrl = Request["cUrl"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(Id);
        switch (subAct)
        {
            case "save":
                #region save comment
                if(logged && !string.IsNullOrEmpty(PRowId))
                {
                    var item = idNull ? new BinhLuan() : BinhLuanDal.SelectById(Convert.ToInt64(Id));
                    txt = Lib.RemoveUnwantedTags(txt);
                    txt = Lib.Rutgon(txt, 1000);
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
                        item.Url = cUrl;
                        item.RowId = Guid.NewGuid();
                        item = BinhLuanDal.Insert(item);

                        ObjMemberDal.Insert(new ObjMember()
                                                {
                                                    PRowId = item.P_RowId
                                                    ,
                                                    Username = Security.Username
                                                    ,
                                                    Owner = false
                                                    ,
                                                    NgayTao = DateTime.Now
                                                    ,
                                                    RowId = Guid.NewGuid()
                                                });
                        ObjMemberDal.Insert(new ObjMember()
                        {
                            PRowId = item.RowId
                            ,
                            Username = Security.Username
                            ,
                            Owner = true
                            ,
                            RowId = Guid.NewGuid()
                        });
                        var obj = ObjDal.Insert(new Obj()
                        {
                            Id = Guid.NewGuid()
                            ,
                            Kieu = typeof(BinhLuan).FullName
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = item.RowId
                            ,
                            Url = string.Format("{0}#{1}", cUrl, item.Id)
                            ,
                            Username = Security.Username
                        });
                        if(!string.IsNullOrEmpty(cUrl))
                        {
                            var uri = new Uri(cUrl, UriKind.RelativeOrAbsolute);
                            cUrl = uri.OriginalString;
                        }
                        systemMessageDal.Insert(new systemMessage()
                                                    {
                                                        NoiDung = string.Format("<strong>{0}</strong> bình luận",item.Member.Ten)
                                                        , HeThong = false
                                                        , Id = Guid.NewGuid()
                                                        , PRowId = item.P_RowId
                                                        , NgayTao = DateTime.Now
                                                        , Active = true
                                                        , Loai = 1
                                                        , Url = string.Format("{0}#{1}", cUrl,item.Id)
                                                        , Ten = string.Empty
                                                        , ThanhVienMoi = false
                                                        , Username = Security.Username
                                                        , ThuTu =  0                                                        
                                                    });

                        
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
            case "saveAdm":
            #region admin do saved
                if(logged)
                {
                    var item = BinhLuanDal.SelectById(Convert.ToInt64(Id));
                    item.NoiDung = noiDung;
                    item = BinhLuanDal.Update(item);
                    rendertext("1");
                }
                break;
            #endregion
            case "removeAdm":
                #region admin do delete
                if (logged)
                {
                    var item = BinhLuanDal.SelectById(Convert.ToInt64(Id));
                    ObjDal.DeleteByRowId(item.RowId);
                    BinhLuanDal.DeleteById(item.Id);
                }
                break;
                #endregion
            case "remove":
                #region remove comment
                if(!string.IsNullOrEmpty(Id))
                {
                    var item = BinhLuanDal.SelectById(Convert.ToInt64(Id));
                    if(item.Username== Security.Username || item.X_NguoiTao == Security.Username)
                    {
                        ObjMemberDal.DeleteByPRowIdUsername(item.RowId.ToString(), Security.Username);
                        ObjDal.DeleteByRowId(item.RowId);
                        BinhLuanDal.DeleteById(item.Id);
                    }
                }
                break;
                #endregion
        }
    }
}