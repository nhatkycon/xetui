using System;
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
    #region NhomThanhVien
    #region BO
    public class NhomThanhVien : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 NHOM_ID { get; set; }
        public String Username { get; set; }
        public Boolean Admin { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Approved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Boolean Accepted { get; set; }
        public DateTime AcceptedDate { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public NhomThanhVien()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NhomThanhVienDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NhomThanhVienCollection : BaseEntityCollection<NhomThanhVien>
    { }
    #endregion
    #region Dal
    public class NhomThanhVienDal
    {
        #region Methods

        public static void DeleteById(Guid TV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNhomThanhVien_Delete_DeleteById_linhnx", obj);
        }

        public static NhomThanhVien Insert(NhomThanhVien item)
        {
            var Item = new NhomThanhVien();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("TV_ID", item.ID);
            obj[1] = new SqlParameter("TV_NHOM_ID", item.NHOM_ID);
            obj[2] = new SqlParameter("TV_Username", item.Username);
            obj[3] = new SqlParameter("TV_Admin", item.Admin);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TV_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("TV_Approved", item.Approved);
            if (item.ApprovedDate > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TV_ApprovedDate", item.ApprovedDate);
            }
            else
            {
                obj[6] = new SqlParameter("TV_ApprovedDate", DBNull.Value);
            }
            obj[7] = new SqlParameter("TV_Accepted", item.Accepted);
            if (item.AcceptedDate > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TV_AcceptedDate", item.AcceptedDate);
            }
            else
            {
                obj[8] = new SqlParameter("TV_AcceptedDate", DBNull.Value);
            }
            obj[9] = new SqlParameter("TV_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhomThanhVien_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NhomThanhVien Update(NhomThanhVien item)
        {
            var Item = new NhomThanhVien();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("TV_ID", item.ID);
            obj[1] = new SqlParameter("TV_NHOM_ID", item.NHOM_ID);
            obj[2] = new SqlParameter("TV_Username", item.Username);
            obj[3] = new SqlParameter("TV_Admin", item.Admin);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TV_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("TV_Approved", item.Approved);
            if (item.ApprovedDate > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TV_ApprovedDate", item.ApprovedDate);
            }
            else
            {
                obj[6] = new SqlParameter("TV_ApprovedDate", DBNull.Value);
            }
            obj[7] = new SqlParameter("TV_Accepted", item.Accepted);
            if (item.AcceptedDate > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TV_AcceptedDate", item.AcceptedDate);
            }
            else
            {
                obj[8] = new SqlParameter("TV_AcceptedDate", DBNull.Value);
            }
            obj[9] = new SqlParameter("TV_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhomThanhVien_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NhomThanhVien SelectById(Guid TV_ID)
        {
            var Item = new NhomThanhVien();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhomThanhVien_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NhomThanhVienCollection SelectAll()
        {
            var List = new NhomThanhVienCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhomThanhVien_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NhomThanhVien> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<NhomThanhVien>("sp_tblNhomThanhVien_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static NhomThanhVien getFromReader(IDataReader rd)
        {
            var Item = new NhomThanhVien();
            if (rd.FieldExists("TV_ID"))
            {
                Item.ID = (Guid)(rd["TV_ID"]);
            }
            if (rd.FieldExists("TV_NHOM_ID"))
            {
                Item.NHOM_ID = (Int32)(rd["TV_NHOM_ID"]);
            }
            if (rd.FieldExists("TV_Username"))
            {
                Item.Username = (String)(rd["TV_Username"]);
            }
            if (rd.FieldExists("TV_Admin"))
            {
                Item.Admin = (Boolean)(rd["TV_Admin"]);
            }
            if (rd.FieldExists("TV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TV_NgayTao"]);
            }
            if (rd.FieldExists("TV_Approved"))
            {
                Item.Approved = (Boolean)(rd["TV_Approved"]);
            }
            if (rd.FieldExists("TV_ApprovedDate"))
            {
                Item.ApprovedDate = (DateTime)(rd["TV_ApprovedDate"]);
            }
            if (rd.FieldExists("TV_Accepted"))
            {
                Item.Accepted = (Boolean)(rd["TV_Accepted"]);
            }
            if (rd.FieldExists("TV_AcceptedDate"))
            {
                Item.AcceptedDate = (DateTime)(rd["TV_AcceptedDate"]);
            }
            if (rd.FieldExists("TV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TV_NguoiTao"]);
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


