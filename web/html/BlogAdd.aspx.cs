﻿using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_BlogAdd : LoggedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        var PID_ID = Request["PID_ID"];
        var Loai = Request["Loai"];
        var idNull = string.IsNullOrEmpty(Id);
        var item = new Blog()
        {
            RowId = Guid.NewGuid()
        };

        using (var con = DAL.con())
        {
            
            if (!idNull)
            {
                item = BlogDal.SelectById(con, Convert.ToInt32(Id));
                //item.Anhs = AnhDal.SelectByPId(con, item.RowId.ToString(), 20);
                Add.ListAnh = AnhDal.SelectByPId(con, item.RowId.ToString(), 20);
                
            }
            item.Loai = Convert.ToInt32(Loai);
            switch (item.Loai)
            {
                case 1: // Profile
                    var mem = MemberDal.SelectAllByUserName(con, PID_ID);
                    item.PID_ID = mem.RowId;
                    Add.MemberProfile = mem;
                    //item.Profile = mem;
                    break;
                case 2: // Xe
                    var xe = XeDal.SelectById(con, Convert.ToInt64(PID_ID));
                    item.PID_ID = xe.RowId;
                    Add.XeItem = xe;
                    //item.Xe = xe;
                    break;
                case 3:
                case 4:
                case 5: // Community
                    var nhom = NhomDal.SelectById(con, Convert.ToInt32(PID_ID));
                    item.PID_ID = nhom.RowId;
                    Add.NhomItem = nhom;
                    //item.Nhom = nhom;
                    break;
            }
            Add.Id = Id;
            Add.PID_ID = PID_ID;
            Add.Loai = Loai;
            Add.Item = item;
        }
    }
}