using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using docsoft.entities;
using Image = System.Web.UI.WebControls.Image;

public partial class lib_lab_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (var item in MemberDal.SelectAll())
        {
            ObjDal.Insert(new Obj()
                              {
                                  Id = Guid.NewGuid()
                                  ,
                                  Kieu = typeof (Member).FullName
                                  ,
                                  NgayTao = DateTime.Now
                                  ,
                                  Alias = item.Username
                                  ,
                                  RowId = item.RowId
                                  ,
                                  Ten = item.Ten
                                  ,
                                  Url = item.Url
                                  ,
                                  Username = item.Username
                              });
        }
        foreach (var item in XeDal.SelectAll())
        {
            ObjDal.Insert(new Obj()
            {
                Id = Guid.NewGuid()
                ,
                Kieu = typeof(Xe).FullName
                ,
                NgayTao = DateTime.Now
                ,
                RowId = item.RowId
                ,
                Ten = item.Ten
                ,
                Url = item.XeUrl
                ,
                Username = item.NguoiTao
            });
        }

        foreach (var item in BlogDal.SelectAll())
        {
            ObjDal.Insert(new Obj()
            {
                Id = Guid.NewGuid()
                ,
                Kieu = typeof(Blog).FullName
                ,
                NgayTao = DateTime.Now
                ,
                RowId = item.RowId
                ,
                Ten = item.Ten
                ,
                Url = item.Url
                ,
                Username = item.NguoiTao
            });
        }

        foreach (var item in NhomDal.SelectAll())
        {
            ObjDal.Insert(new Obj()
            {
                Id = Guid.NewGuid()
                ,
                Kieu = typeof(Nhom).FullName
                ,
                NgayTao = DateTime.Now
                ,
                RowId = item.RowId
                ,
                Ten = item.Ten
                ,
                Url = item.Url
                ,
                Username = item.NguoiTao
            });
        }
    }
}