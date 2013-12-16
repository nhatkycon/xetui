﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region Xe
    #region BO
    public class Xe : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Guid HANG_ID { get; set; }
        public Guid MODEL_ID { get; set; }
        public String SubModel { get; set; }
        public Boolean XuatXu { get; set; }
        public Int32 Nam { get; set; }
        public Boolean TinhTrang { get; set; }
        public Guid DONGXE_ID { get; set; }
        public Guid MAUNGOAITHAT_ID { get; set; }
        public Guid MAUNOITHAT_ID { get; set; }
        public Boolean HopSo { get; set; }
        public Guid KIEUDANDONG_ID { get; set; }
        public Guid NHIENLIEU_ID { get; set; }
        public Guid THANHPHO_ID { get; set; }
        public String Ten { get; set; }
        public Guid RowId { get; set; }
        public Boolean RaoBan { get; set; }
        public Int64 Gia { get; set; }
        public Boolean DaBan { get; set; }
        public String Chu { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Khoa { get; set; }
        public Boolean Xoa { get; set; }
        #endregion
        #region Contructor
        public Xe()
        { }
        public Xe(Int64? id, Guid? hang_id, Guid? model_id, String submodel, Boolean? xuatxu, Int32? nam, Boolean? tinhtrang, Guid? dongxe_id, Guid? maungoaithat_id, Guid? maunoithat_id, Boolean? hopso, Guid? kieudandong_id, Guid? nhienlieu_id, Guid? thanhpho_id, String ten, Guid? rowid, Boolean? raoban, Int64? gia, Boolean? daban, String chu, String nguoitao, String nguoicapnhat, DateTime? ngaytao, DateTime? ngaycapnhat, Boolean? khoa, Boolean? xoa)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (hang_id != null)
            {
                HANG_ID = hang_id.Value;
            }
            if (model_id != null)
            {
                MODEL_ID = model_id.Value;
            }
            SubModel = submodel;
            if (xuatxu != null)
            {
                XuatXu = xuatxu.Value;
            }
            if (nam != null)
            {
                Nam = nam.Value;
            }
            if (tinhtrang != null)
            {
                TinhTrang = tinhtrang.Value;
            }
            if (dongxe_id != null)
            {
                DONGXE_ID = dongxe_id.Value;
            }
            if (maungoaithat_id != null)
            {
                MAUNGOAITHAT_ID = maungoaithat_id.Value;
            }
            if (maunoithat_id != null)
            {
                MAUNOITHAT_ID = maunoithat_id.Value;
            }
            if (hopso != null)
            {
                HopSo = hopso.Value;
            }
            if (kieudandong_id != null)
            {
                KIEUDANDONG_ID = kieudandong_id.Value;
            }
            if (nhienlieu_id != null)
            {
                NHIENLIEU_ID = nhienlieu_id.Value;
            }
            if (thanhpho_id != null)
            {
                THANHPHO_ID = thanhpho_id.Value;
            }
            Ten = ten;
            if (rowid != null)
            {
                RowId = rowid.Value;
            }
            if (raoban != null)
            {
                RaoBan = raoban.Value;
            }
            if (gia != null)
            {
                Gia = gia.Value;
            }
            if (daban != null)
            {
                DaBan = daban.Value;
            }
            Chu = chu;
            NguoiTao = nguoitao;
            NguoiCapNhat = nguoicapnhat;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (ngaycapnhat != null)
            {
                NgayCapNhat = ngaycapnhat.Value;
            }
            if (khoa != null)
            {
                Khoa = khoa.Value;
            }
            if (xoa != null)
            {
                Xoa = xoa.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XeCollection : BaseEntityCollection<Xe>
    { }
    #endregion
    #region Dal
    public class XeDal
    {
        #region Methods

        public static void DeleteById(Int64 X_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("X_ID", X_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Delete_DeleteById_linhnx", obj);
        }
        public static Xe Insert(Xe Inserted)
        {
            var Item = new Xe();
            var obj = new SqlParameter[25];
            obj[0] = new SqlParameter("X_HANG_ID", Inserted.HANG_ID);
            obj[1] = new SqlParameter("X_MODEL_ID", Inserted.MODEL_ID);
            obj[2] = new SqlParameter("X_SubModel", Inserted.SubModel);
            obj[3] = new SqlParameter("X_XuatXu", Inserted.XuatXu);
            obj[4] = new SqlParameter("X_Nam", Inserted.Nam);
            obj[5] = new SqlParameter("X_TinhTrang", Inserted.TinhTrang);
            obj[6] = new SqlParameter("X_DONGXE_ID", Inserted.DONGXE_ID);
            obj[7] = new SqlParameter("X_MAUNGOAITHAT_ID", Inserted.MAUNGOAITHAT_ID);
            obj[8] = new SqlParameter("X_MAUNOITHAT_ID", Inserted.MAUNOITHAT_ID);
            obj[9] = new SqlParameter("X_HopSo", Inserted.HopSo);
            obj[10] = new SqlParameter("X_KIEUDANDONG_ID", Inserted.KIEUDANDONG_ID);
            obj[11] = new SqlParameter("X_NHIENLIEU_ID", Inserted.NHIENLIEU_ID);
            obj[12] = new SqlParameter("X_THANHPHO_ID", Inserted.THANHPHO_ID);
            obj[13] = new SqlParameter("X_Ten", Inserted.Ten);
            obj[14] = new SqlParameter("X_RowId", Inserted.RowId);
            obj[15] = new SqlParameter("X_RaoBan", Inserted.RaoBan);
            obj[16] = new SqlParameter("X_Gia", Inserted.Gia);
            obj[17] = new SqlParameter("X_DaBan", Inserted.DaBan);
            obj[18] = new SqlParameter("X_Chu", Inserted.Chu);
            obj[19] = new SqlParameter("X_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("X_NguoiCapNhat", Inserted.NguoiCapNhat);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("X_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[21] = new SqlParameter("X_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("X_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[22] = new SqlParameter("X_NgayCapNhat", DBNull.Value);
            }
            obj[23] = new SqlParameter("X_Khoa", Inserted.Khoa);
            obj[24] = new SqlParameter("X_Xoa", Inserted.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Xe Update(Xe Updated)
        {
            var Item = new Xe();
            var obj = new SqlParameter[26];
            obj[0] = new SqlParameter("X_ID", Updated.ID);
            obj[1] = new SqlParameter("X_HANG_ID", Updated.HANG_ID);
            obj[2] = new SqlParameter("X_MODEL_ID", Updated.MODEL_ID);
            obj[3] = new SqlParameter("X_SubModel", Updated.SubModel);
            obj[4] = new SqlParameter("X_XuatXu", Updated.XuatXu);
            obj[5] = new SqlParameter("X_Nam", Updated.Nam);
            obj[6] = new SqlParameter("X_TinhTrang", Updated.TinhTrang);
            obj[7] = new SqlParameter("X_DONGXE_ID", Updated.DONGXE_ID);
            obj[8] = new SqlParameter("X_MAUNGOAITHAT_ID", Updated.MAUNGOAITHAT_ID);
            obj[9] = new SqlParameter("X_MAUNOITHAT_ID", Updated.MAUNOITHAT_ID);
            obj[10] = new SqlParameter("X_HopSo", Updated.HopSo);
            obj[11] = new SqlParameter("X_KIEUDANDONG_ID", Updated.KIEUDANDONG_ID);
            obj[12] = new SqlParameter("X_NHIENLIEU_ID", Updated.NHIENLIEU_ID);
            obj[13] = new SqlParameter("X_THANHPHO_ID", Updated.THANHPHO_ID);
            obj[14] = new SqlParameter("X_Ten", Updated.Ten);
            obj[15] = new SqlParameter("X_RowId", Updated.RowId);
            obj[16] = new SqlParameter("X_RaoBan", Updated.RaoBan);
            obj[17] = new SqlParameter("X_Gia", Updated.Gia);
            obj[18] = new SqlParameter("X_DaBan", Updated.DaBan);
            obj[19] = new SqlParameter("X_Chu", Updated.Chu);
            obj[20] = new SqlParameter("X_NguoiTao", Updated.NguoiTao);
            obj[21] = new SqlParameter("X_NguoiCapNhat", Updated.NguoiCapNhat);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("X_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[22] = new SqlParameter("X_NgayTao", DBNull.Value);
            }
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("X_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[23] = new SqlParameter("X_NgayCapNhat", DBNull.Value);
            }
            obj[24] = new SqlParameter("X_Khoa", Updated.Khoa);
            obj[25] = new SqlParameter("X_Xoa", Updated.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Xe SelectById(Int64 X_ID)
        {
            var Item = new Xe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("X_ID", X_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static XeCollection SelectAll()
        {
            var List = new XeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Xe> pagerNormal(string url, bool rewrite, string sort)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            var pg = new Pager<Xe>("sp_tblXe_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Xe getFromReader(IDataReader rd)
        {
            var Item = new Xe();
            if (rd.FieldExists("X_ID"))
            {
                Item.ID = (Int64)(rd["X_ID"]);
            }
            if (rd.FieldExists("X_HANG_ID"))
            {
                Item.HANG_ID = (Guid)(rd["X_HANG_ID"]);
            }
            if (rd.FieldExists("X_MODEL_ID"))
            {
                Item.MODEL_ID = (Guid)(rd["X_MODEL_ID"]);
            }
            if (rd.FieldExists("X_SubModel"))
            {
                Item.SubModel = (String)(rd["X_SubModel"]);
            }
            if (rd.FieldExists("X_XuatXu"))
            {
                Item.XuatXu = (Boolean)(rd["X_XuatXu"]);
            }
            if (rd.FieldExists("X_Nam"))
            {
                Item.Nam = (Int32)(rd["X_Nam"]);
            }
            if (rd.FieldExists("X_TinhTrang"))
            {
                Item.TinhTrang = (Boolean)(rd["X_TinhTrang"]);
            }
            if (rd.FieldExists("X_DONGXE_ID"))
            {
                Item.DONGXE_ID = (Guid)(rd["X_DONGXE_ID"]);
            }
            if (rd.FieldExists("X_MAUNGOAITHAT_ID"))
            {
                Item.MAUNGOAITHAT_ID = (Guid)(rd["X_MAUNGOAITHAT_ID"]);
            }
            if (rd.FieldExists("X_MAUNOITHAT_ID"))
            {
                Item.MAUNOITHAT_ID = (Guid)(rd["X_MAUNOITHAT_ID"]);
            }
            if (rd.FieldExists("X_HopSo"))
            {
                Item.HopSo = (Boolean)(rd["X_HopSo"]);
            }
            if (rd.FieldExists("X_KIEUDANDONG_ID"))
            {
                Item.KIEUDANDONG_ID = (Guid)(rd["X_KIEUDANDONG_ID"]);
            }
            if (rd.FieldExists("X_NHIENLIEU_ID"))
            {
                Item.NHIENLIEU_ID = (Guid)(rd["X_NHIENLIEU_ID"]);
            }
            if (rd.FieldExists("X_THANHPHO_ID"))
            {
                Item.THANHPHO_ID = (Guid)(rd["X_THANHPHO_ID"]);
            }
            if (rd.FieldExists("X_Ten"))
            {
                Item.Ten = (String)(rd["X_Ten"]);
            }
            if (rd.FieldExists("X_RowId"))
            {
                Item.RowId = (Guid)(rd["X_RowId"]);
            }
            if (rd.FieldExists("X_RaoBan"))
            {
                Item.RaoBan = (Boolean)(rd["X_RaoBan"]);
            }
            if (rd.FieldExists("X_Gia"))
            {
                Item.Gia = (Int64)(rd["X_Gia"]);
            }
            if (rd.FieldExists("X_DaBan"))
            {
                Item.DaBan = (Boolean)(rd["X_DaBan"]);
            }
            if (rd.FieldExists("X_Chu"))
            {
                Item.Chu = (String)(rd["X_Chu"]);
            }
            if (rd.FieldExists("X_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["X_NguoiTao"]);
            }
            if (rd.FieldExists("X_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["X_NguoiCapNhat"]);
            }
            if (rd.FieldExists("X_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["X_NgayTao"]);
            }
            if (rd.FieldExists("X_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["X_NgayCapNhat"]);
            }
            if (rd.FieldExists("X_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["X_Khoa"]);
            }
            if (rd.FieldExists("X_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["X_Xoa"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion
    #endregion
    
}


