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
    #region XeYeuThich
    #region BO
    public class XeYeuThich : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int64 X_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public XeYeuThich()
        { }
        public XeYeuThich(Int32? id, Int32? x_id, String username, DateTime? ngaytao)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (x_id != null)
            {
                X_ID = x_id.Value;
            }
            Username = username;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }

        }
        #endregion
        #region Customs properties

        public Xe Xe { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeYeuThichDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XeYeuThichCollection : BaseEntityCollection<XeYeuThich>
    { }
    #endregion
    #region Dal
    public class XeYeuThichDal
    {
        #region Methods

        public static void DeleteById(Int32 XYT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XYT_ID", XYT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Delete_DeleteById_linhnx", obj);
        }
        public static XeYeuThich Insert(XeYeuThich Inserted)
        {
            XeYeuThich Item = new XeYeuThich();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("XYT_X_ID", Inserted.X_ID);
            obj[1] = new SqlParameter("XYT_Username", Inserted.Username);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("XYT_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("XYT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeYeuThich Update(XeYeuThich Updated)
        {
            XeYeuThich Item = new XeYeuThich();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("XYT_ID", Updated.ID);
            obj[1] = new SqlParameter("XYT_X_ID", Updated.X_ID);
            obj[2] = new SqlParameter("XYT_Username", Updated.Username);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("XYT_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("XYT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeYeuThich SelectById(Int32 XYT_ID)
        {
            XeYeuThich Item = new XeYeuThich();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XYT_ID", XYT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static XeYeuThichCollection SelectAll()
        {
            XeYeuThichCollection List = new XeYeuThichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<XeYeuThich> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<XeYeuThich> pg = new Pager<XeYeuThich>("sp_tblXeYeuThich_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static XeYeuThich getFromReader(IDataReader rd)
        {
            var Item = new XeYeuThich();
            if (rd.FieldExists("XYT_ID"))
            {
                Item.ID = (Int32)(rd["XYT_ID"]);
            }
            if (rd.FieldExists("XYT_X_ID"))
            {
                Item.X_ID = (Int64)(rd["XYT_X_ID"]);
            }
            if (rd.FieldExists("XYT_Username"))
            {
                Item.Username = (String)(rd["XYT_Username"]);
            }
            if (rd.FieldExists("XYT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["XYT_NgayTao"]);
            }
            Item.Xe = XeDal.getFromReader(rd);
            return Item;
        }
        #endregion
        #region Extend
        public static bool SelectByXidUsername(string username, string X_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("X_ID", X_ID);
            return
                Convert.ToBoolean(
                    SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure,
                                            "sp_tblXeYeuThich_Select_SelectByXidUsername_linhnx", obj).ToString());
        }
        public static Pager<XeYeuThich> PagerByUsername(SqlConnection con, string url, bool rewrite, string sort, string username)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            var pg = new Pager<XeYeuThich>(con,"sp_tblXeYeuThich_Pager_pagerByUsername_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static void DeleteByUserXid(string username, string X_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("X_ID", X_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXeYeuThich_Delete_DeleteByUserXid_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion
    
}


