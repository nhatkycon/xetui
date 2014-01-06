﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_blog_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var PID_ID = Request["PID_ID"];
        var Loai = Request["Loai"];
        var Id = Request["Id"];
        var cUrl = Request["cUrl"];
        var noiDung = Request["NoiDung"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(Id);
        switch (subAct)
        {
            case "save":
                #region save comment
                if (logged && !string.IsNullOrEmpty(PID_ID) && !string.IsNullOrEmpty(Loai))
                {
                    var item = idNull ? new Blog() : BlogDal.SelectById(Convert.ToInt64(Id));
                    item.NoiDung = noiDung;
                    item.Ten = Ten;

                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        if (!string.IsNullOrEmpty(Loai))
                        {
                            item.Loai = Convert.ToInt32(Loai);
                        }
                        if (!string.IsNullOrEmpty(PID_ID))
                        {
                            item.PID_ID = new Guid(PID_ID);
                        }
                        item.RowId = Guid.NewGuid();
                        item = BlogDal.Insert(item);
                        ObjMemberDal.Insert(new ObjMember()
                        {
                            PRowId = item.RowId
                            ,
                            Username = Security.Username
                            ,
                            Owner = true
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = Guid.NewGuid()
                        });
                        var obj = ObjDal.Insert(new Obj()
                        {
                            ID = Guid.NewGuid()
                            ,
                            Kieu = typeof(Blog).FullName
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = item.RowId
                            ,
                            Url = string.Format("{0}#{1}", cUrl, item.ID)
                            ,
                            Username = Security.Username
                        });


                    }
                    else
                    {
                        item = BlogDal.Update(item);
                    }
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