using System;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;

namespace docsoft.entities
{
    #region ObjMember
    #region BO
    public class ObjMember : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Guid PRowId { get; set; }
        public String Username { get; set; }
        public Boolean Owner { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public ObjMember()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ObjMemberDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ObjMemberCollection : BaseEntityCollection<ObjMember>
    { }
    #endregion
    #region Dal
    public class ObjMemberDal
    {
        #region Methods

        public static void DeleteById(Int64 OM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("OM_ID", OM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Delete_DeleteById_linhnx", obj);
        }

        public static ObjMember Insert(ObjMember item)
        {
            var Item = new ObjMember();
            var obj = new SqlParameter[6];            
            obj[1] = new SqlParameter("OM_PRowId", item.PRowId);
            obj[2] = new SqlParameter("OM_Username", item.Username);
            obj[3] = new SqlParameter("OM_Owner", item.Owner);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("OM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("OM_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("OM_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ObjMember Update(ObjMember item)
        {
            var Item = new ObjMember();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("OM_ID", item.ID);
            obj[1] = new SqlParameter("OM_PRowId", item.PRowId);
            obj[2] = new SqlParameter("OM_Username", item.Username);
            obj[3] = new SqlParameter("OM_Owner", item.Owner);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("OM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("OM_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("OM_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ObjMember SelectById(Int64 OM_ID)
        {
            var Item = new ObjMember();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("OM_ID", OM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ObjMemberCollection SelectAll()
        {
            var List = new ObjMemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ObjMember> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ObjMember>("sp_tblObjMember_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ObjMember getFromReader(IDataReader rd)
        {
            var Item = new ObjMember();
            if (rd.FieldExists("OM_ID"))
            {
                Item.ID = (Int64)(rd["OM_ID"]);
            }
            if (rd.FieldExists("OM_PRowId"))
            {
                Item.PRowId = (Guid)(rd["OM_PRowId"]);
            }
            if (rd.FieldExists("OM_Username"))
            {
                Item.Username = (String)(rd["OM_Username"]);
            }
            if (rd.FieldExists("OM_Owner"))
            {
                Item.Owner = (Boolean)(rd["OM_Owner"]);
            }
            if (rd.FieldExists("OM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["OM_NgayTao"]);
            }
            if (rd.FieldExists("OM_RowId"))
            {
                Item.RowId = (Guid)(rd["OM_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static ObjMember SelectByPRowId(string PRowId)
        {
            var item = new ObjMember();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PRowId", PRowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Select_SelectByPRowId_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }

        public static void DeleteByPRowId(string PRowId)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PRowId", PRowId);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Delete_DeleteByPRowId_linhnx", obj);
        }
        public static void DeleteByPRowIdUsername(string PRowId, string username)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("PRowId", PRowId);
            obj[1] = new SqlParameter("username", username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Delete_DeleteByPRowIdUsername_linhnx", obj);
        }
        public static ObjMemberCollection SelectUsernameByPRowId(string PRowId)
        {
            var list = new ObjMemberCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PRowId", PRowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblObjMember_Select_SelectUsernameByPRowId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion

    #endregion
}


