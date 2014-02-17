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
    #region BinhLuan
    #region BO
    public class BinhLuan : BaseEntity
    {
        #region Properties
        public Int64 Id { get; set; }
        public Guid P_RowId { get; set; }
        public Int64 PBL_ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public String Url { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 LuotThich { get; set; }
        public Guid RowId { get; set; }
        public Int64 IndexId { get; set; }
        public Boolean Thich { get; set; }
        #endregion
        #region Contructor
        public BinhLuan()
        { }
        #endregion
        #region Customs properties
        public Member Member { get; set; }
        public string X_NguoiTao { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BinhLuanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BinhLuanCollection : BaseEntityCollection<BinhLuan>
    { }
    #endregion
    #region Dal
    public class BinhLuanDal
    {
        #region Methods

        public static void DeleteById(Int64 BL_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BL_ID", BL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Delete_DeleteById_linhnx", obj);
        }
        public static BinhLuan Insert(BinhLuan Inserted)
        {
            var item = new BinhLuan();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("BL_P_RowId", Inserted.P_RowId);
            obj[1] = new SqlParameter("BL_PBL_ID", Inserted.PBL_ID);
            obj[2] = new SqlParameter("BL_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("BL_NoiDung", Inserted.NoiDung);
            obj[4] = new SqlParameter("BL_Url", Inserted.Url);
            obj[5] = new SqlParameter("BL_Username", Inserted.Username);

            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("BL_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("BL_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("BL_LuotThich", Inserted.LuotThich);
            obj[8] = new SqlParameter("BL_RowId", Inserted.RowId);
            obj[9] = new SqlParameter("BL_IndexId", Inserted.IndexId);
            obj[10] = new SqlParameter("BL_Thich", Inserted.Thich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }

        public static BinhLuan Update(BinhLuan Updated)
        {
            BinhLuan Item = new BinhLuan();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("BL_ID", Updated.Id);
            obj[1] = new SqlParameter("BL_P_RowId", Updated.P_RowId);
            obj[2] = new SqlParameter("BL_PBL_ID", Updated.PBL_ID);
            obj[3] = new SqlParameter("BL_Ten", Updated.Ten);
            obj[4] = new SqlParameter("BL_NoiDung", Updated.NoiDung);
            obj[5] = new SqlParameter("BL_Url", Updated.Url);
            obj[6] = new SqlParameter("BL_Username", Updated.Username);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("BL_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("BL_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("BL_LuotThich", Updated.LuotThich);
            obj[9] = new SqlParameter("BL_RowId", Updated.RowId);
            obj[10] = new SqlParameter("BL_IndexId", Updated.IndexId);
            obj[11] = new SqlParameter("BL_Thich", Updated.Thich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BinhLuan SelectById(Int64 BL_ID)
        {
            BinhLuan Item = new BinhLuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BL_ID", BL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BinhLuanCollection SelectAll()
        {
            BinhLuanCollection List = new BinhLuanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BinhLuan> PagerNormal(SqlConnection con, string url, bool rewrite, string sort
           , int size
           , string q, string username, string tuNgay, string denNgay
           )
        {
            var obj = new SqlParameter[8];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[2] = new SqlParameter("q", q);
            }
            else
            {
                obj[2] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(username))
            {
                obj[3] = new SqlParameter("Username", username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(tuNgay))
            {
                obj[5] = new SqlParameter("TuNgay", tuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(denNgay))
            {
                obj[6] = new SqlParameter("DenNgay", denNgay);
            }
            else
            {
                obj[6] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<BinhLuan>(con, "sp_tblBinhLuan_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static BinhLuan getFromReader(IDataReader rd)
        {
            var item = new BinhLuan();
            if (rd.FieldExists("BL_ID"))
            {
                item.Id = (Int64)(rd["BL_ID"]);
            }
            if (rd.FieldExists("BL_P_RowId"))
            {
                item.P_RowId = (Guid)(rd["BL_P_RowId"]);
            }
            if (rd.FieldExists("BL_PBL_ID"))
            {
                item.PBL_ID = (Int64)(rd["BL_PBL_ID"]);
            }
            if (rd.FieldExists("BL_Ten"))
            {
                item.Ten = (String)(rd["BL_Ten"]);
            }
            if (rd.FieldExists("BL_NoiDung"))
            {
                item.NoiDung = (String)(rd["BL_NoiDung"]);
            }
            if (rd.FieldExists("BL_Url"))
            {
                item.Url = (String)(rd["BL_Url"]);
            }
            if (rd.FieldExists("BL_Username"))
            {
                item.Username = (String)(rd["BL_Username"]);
            }
            if (rd.FieldExists("BL_NgayTao"))
            {
                item.NgayTao = (DateTime)(rd["BL_NgayTao"]);
            }
            if (rd.FieldExists("BL_LuotThich"))
            {
                item.LuotThich = (Int32)(rd["BL_LuotThich"]);
            }
            if (rd.FieldExists("BL_RowId"))
            {
                item.RowId = (Guid)(rd["BL_RowId"]);
            }
            if (rd.FieldExists("BL_IndexId"))
            {
                item.IndexId = (Int64)(rd["BL_IndexId"]);
            }
            if (rd.FieldExists("BL_Thich"))
            {
                item.Thich = (Boolean)(rd["BL_Thich"]);
            }
            var mem = new Member();
            if (rd.FieldExists("MEM_Vcard"))
            {
                mem.Vcard = (String)(rd["MEM_Vcard"]);
            }
            if (rd.FieldExists("MEM_Ten"))
            {
                mem.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("X_NguoiTao"))
            {
                item.X_NguoiTao = (String)(rd["X_NguoiTao"]);
            }
            
            item.Member = mem;
            return item;
        }
        #endregion
        #region Extend
        public static Pager<BinhLuan> PagerByPRowId(SqlConnection con, string url, bool rewrite, string rowId, int size)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RowId", rowId);
            var pg = new Pager<BinhLuan>(con, "sp_tblBinhLuan_Pager_PagerByPRowId_linhnx", "q", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
    
}


