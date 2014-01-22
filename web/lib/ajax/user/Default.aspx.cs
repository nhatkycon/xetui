using System;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_user_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ten = Request["Ten"];
        var moTa = Request["Mota"];
        var id = Request["Id"];
        var cUrl = Request["cUrl"];
        var rowId = Request["RowId"];
        var email = Request["Email"];
        var diaChi = Request["DiaChi"];
        var active = Request["Active"];
        var username = Request["Username"];
        var password = Request["Password"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(id) || id == "0";
        var joined = Request["Joined"];
        var approved = Request["approved"];
        var loai = Request["loai"];
        switch (subAct)
        {
            case "save":

                #region save User

                if (logged && !string.IsNullOrEmpty(ten))
                {
                    var item = idNull ? new Member() : MemberDal.SelectById(Convert.ToInt32(id));
                    item.Ten = ten;
                    item.Mota = moTa;
                    item.NgayCapNhat = DateTime.Now;
                    active = !string.IsNullOrEmpty(active) ? "true" : "false";
                    item.Active = Convert.ToBoolean(active);
                    item.Username = username;
                    if(!string.IsNullOrEmpty(password))
                    {
                        item.Password = maHoa.EncryptString(password, username);
                    }
                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        item.RowId=new Guid(rowId);
                        item = MemberDal.Insert(item);

                        var obj = ObjDal.Insert(new Obj()
                                                    {
                                                        ID = Guid.NewGuid()
                                                        ,
                                                        Kieu = typeof (Member).FullName
                                                        ,
                                                        NgayTao = DateTime.Now
                                                        ,
                                                        RowId = item.RowId
                                                        ,
                                                        Ten = item.Ten
                                                        ,
                                                        Url = string.Format("{0}", item.Url)
                                                        ,
                                                        Username = username
                                                    });
                    }
                    else
                    {
                        item = MemberDal.Update(item);
                    }
                    rendertext(item.Url);
                }
                rendertext("0");
                break;
                #endregion
            case "remove":
                #region remove User

                if (!string.IsNullOrEmpty(id) && logged)
                {
                    MemberDal.DeleteById(Convert.ToInt32(id));
                }
                break;

                #endregion
        }
    }
}