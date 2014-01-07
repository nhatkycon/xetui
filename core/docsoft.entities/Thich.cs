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
    #region Thich
    #region BO
    public class Thich : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 Loai { get; set; }
        #endregion
        #region Contructor
        public Thich()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThichDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThichCollection : BaseEntityCollection<Thich>
    { }
    #endregion
    #region Dal
    public class ThichDal
    {
        #region Methods

        public static void DeleteById(Guid T_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Delete_DeleteById_linhnx", obj);
        }

        public static Thich Insert(Thich item)
        {
            var Item = new Thich();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("T_ID", item.ID);
            obj[1] = new SqlParameter("T_P_ID", item.P_ID);
            obj[2] = new SqlParameter("T_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("T_LOAI", item.Loai);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thich Update(Thich item)
        {
            var Item = new Thich();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("T_ID", item.ID);
            obj[1] = new SqlParameter("T_P_ID", item.P_ID);
            obj[2] = new SqlParameter("T_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("T_LOAI", item.Loai);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thich SelectById(Guid T_ID)
        {
            var Item = new Thich();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThichCollection SelectAll()
        {
            var List = new ThichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Thich> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Thich>("sp_tblThich_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Thich getFromReader(IDataReader rd)
        {
            var Item = new Thich();
            if (rd.FieldExists("T_ID"))
            {
                Item.ID = (Guid)(rd["T_ID"]);
            }
            if (rd.FieldExists("T_P_ID"))
            {
                Item.P_ID = (Guid)(rd["T_P_ID"]);
            }
            if (rd.FieldExists("T_Username"))
            {
                Item.Username = (String)(rd["T_Username"]);
            }
            if (rd.FieldExists("T_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["T_NgayTao"]);
            }
            if (rd.FieldExists("T_Loai"))
            {
                Item.Loai = (Int32)(rd["T_Loai"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteByPIdUsername(Guid P_ID, string Username)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("P_ID", P_ID);
            obj[1] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Delete_DeleteByPIdUsername_linhnx", obj);
        }
        public static void DeleteByPId(Guid P_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Delete_DeleteByPId_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion
    
}


