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
                            ID = Guid.NewGuid()
                            ,
                            Kieu = typeof(BinhLuan).FullName
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = item.RowId
                            ,
                            Url = string.Format("{0}#{1}", cUrl, item.ID)
                            ,
                            Username = Security.Username
                        });

                        systemMessageDal.Insert(new systemMessage()
                                                    {
                                                        NoiDung = string.Format("<strong>{0}</strong> bình luận",item.Member.Ten)
                                                        , HeThong = false
                                                        , ID = Guid.NewGuid()
                                                        , PRowId = item.P_RowId
                                                        , NgayTao = DateTime.Now
                                                        , Active = true
                                                        , Loai = 1
                                                        , Url = string.Format("{0}#{1}", cUrl,item.ID)
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
            case "remove":
                #region remove comment
                break;
                #endregion
        }
    }
}