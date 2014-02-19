using System;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;

namespace docsoft.entities
{
    #region Obj
    #region BO
    public class Obj : BaseEntity
    {
        #region Properties
        public Guid Id { get; set; }
        public Guid RowId { get; set; }
        public String Username { get; set; }
        public String Ten { get; set; }
        public String Kieu { get; set; }
        public String Url { get; set; }
        public DateTime NgayTao { get; set; }
        public string Alias { get; set; }
        public string NoiDung { get; set; }
        #endregion
        #region Contructor
        public Obj()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ObjDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ObjCollection : BaseEntityCollection<Obj>
    { }
    #endregion
    #region Dal
    public class ObjDal
    {
        #region Methods

        public static void DeleteById(Guid OB_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("OB_ID", OB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Delete_DeleteById_linhnx", obj);
        }

        public static Obj Insert(Obj item)
        {
            var Item = new Obj();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("OB_ID", item.Id);
            obj[1] = new SqlParameter("OB_RowId", item.RowId);
            obj[2] = new SqlParameter("OB_Username", item.Username);
            obj[3] = new SqlParameter("OB_Ten", item.Ten);
            obj[4] = new SqlParameter("OB_Kieu", item.Kieu);
            obj[5] = new SqlParameter("OB_Url", item.Url);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("OB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("OB_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Obj Update(Obj item)
        {
            var Item = new Obj();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("OB_ID", item.Id);
            obj[1] = new SqlParameter("OB_RowId", item.RowId);
            obj[2] = new SqlParameter("OB_Username", item.Username);
            obj[3] = new SqlParameter("OB_Ten", item.Ten);
            obj[4] = new SqlParameter("OB_Kieu", item.Kieu);
            obj[5] = new SqlParameter("OB_Url", item.Url);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("OB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("OB_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("OB_Alias", item.Alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Obj SelectById(Guid OB_ID)
        {
            var Item = new Obj();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("OB_ID", OB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ObjCollection SelectAll()
        {
            var List = new ObjCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Obj> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Obj>("sp_tblObj_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Obj getFromReader(IDataReader rd)
        {
            var Item = new Obj();
            if (rd.FieldExists("OB_ID"))
            {
                Item.Id = (Guid)(rd["OB_ID"]);
            }
            if (rd.FieldExists("OB_RowId"))
            {
                Item.RowId = (Guid)(rd["OB_RowId"]);
            }
            if (rd.FieldExists("OB_Username"))
            {
                Item.Username = (String)(rd["OB_Username"]);
            }
            if (rd.FieldExists("OB_Ten"))
            {
                Item.Ten = (String)(rd["OB_Ten"]);
            }
            if (rd.FieldExists("OB_Kieu"))
            {
                Item.Kieu = (String)(rd["OB_Kieu"]);
            }
            if (rd.FieldExists("OB_Url"))
            {
                Item.Url = (String)(rd["OB_Url"]);
            }
            if (rd.FieldExists("OB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["OB_NgayTao"]);
            }
            if (rd.FieldExists("OB_Alias"))
            {
                Item.Alias = (String)(rd["OB_Alias"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Obj SelectByRowId(Guid RowId)
        {
            return SelectByRowId(DAL.con(),RowId);
        }
        public static Obj SelectByRowId(SqlConnection con, Guid RowId)
        {
            var item = new Obj();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RowId", RowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblObj_Select_SelectByRowId_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }
        public static Obj SelectByAlias(string alias)
        {
            return SelectByAlias(DAL.con(),alias);
        }
        public static Obj SelectByAlias(SqlConnection con, string alias)
        {
            var item = new Obj();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Alias", alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblObj_Select_SelectByAlias_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }
        public static void DeleteByRowId(Guid RowId)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RowId", RowId);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblObj_Delete_DeleteByRowId_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion
    
}


