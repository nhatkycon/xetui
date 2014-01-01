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
    #region Anh
    #region BO
    public class Anh : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid AB_ID { get; set; }
        public Guid P_ID { get; set; }
        public String Ten { get; set; }
        public String FileAnh { get; set; }
        public Boolean Thich { get; set; }
        public Int32 LuotThich { get; set; }
        public Int32 LuotXem { get; set; }
        public Int32 LuotBinhLuan { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public Anh()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AnhCollection : BaseEntityCollection<Anh>
    { }
    #endregion
    #region Dal
    public class AnhDal
    {
        #region Methods

        public static void DeleteById(Guid A_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Delete_DeleteById_linhnx", obj);
        }

        public static Anh Insert(Anh item)
        {
            var Item = new Anh();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_AB_ID", item.AB_ID);
            obj[2] = new SqlParameter("A_P_ID", item.P_ID);
            obj[3] = new SqlParameter("A_Ten", item.Ten);
            obj[4] = new SqlParameter("A_FileAnh", item.FileAnh);
            obj[5] = new SqlParameter("A_Thich", item.Thich);
            obj[6] = new SqlParameter("A_LuotThich", item.LuotThich);
            obj[7] = new SqlParameter("A_LuotXem", item.LuotXem);
            obj[8] = new SqlParameter("A_LuotBinhLuan", item.LuotBinhLuan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("A_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Anh Update(Anh item)
        {
            var Item = new Anh();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_AB_ID", item.AB_ID);
            obj[2] = new SqlParameter("A_P_ID", item.P_ID);
            obj[3] = new SqlParameter("A_Ten", item.Ten);
            obj[4] = new SqlParameter("A_FileAnh", item.FileAnh);
            obj[5] = new SqlParameter("A_Thich", item.Thich);
            obj[6] = new SqlParameter("A_LuotThich", item.LuotThich);
            obj[7] = new SqlParameter("A_LuotXem", item.LuotXem);
            obj[8] = new SqlParameter("A_LuotBinhLuan", item.LuotBinhLuan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("A_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Anh SelectById(Guid A_ID)
        {
            var Item = new Anh();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static AnhCollection SelectAll()
        {
            var List = new AnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Anh> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Anh>("sp_tblAnh_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Anh getFromReader(IDataReader rd)
        {
            var Item = new Anh();
            if (rd.FieldExists("A_ID"))
            {
                Item.ID = (Guid)(rd["A_ID"]);
            }
            if (rd.FieldExists("A_AB_ID"))
            {
                Item.AB_ID = (Guid)(rd["A_AB_ID"]);
            }
            if (rd.FieldExists("A_P_ID"))
            {
                Item.P_ID = (Guid)(rd["A_P_ID"]);
            }
            if (rd.FieldExists("A_Ten"))
            {
                Item.Ten = (String)(rd["A_Ten"]);
            }
            if (rd.FieldExists("A_FileAnh"))
            {
                Item.FileAnh = (String)(rd["A_FileAnh"]);
            }
            if (rd.FieldExists("A_Thich"))
            {
                Item.Thich = (Boolean)(rd["A_Thich"]);
            }
            if (rd.FieldExists("A_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["A_LuotThich"]);
            }
            if (rd.FieldExists("A_LuotXem"))
            {
                Item.LuotXem = (Int32)(rd["A_LuotXem"]);
            }
            if (rd.FieldExists("A_LuotBinhLuan"))
            {
                Item.LuotBinhLuan = (Int32)(rd["A_LuotBinhLuan"]);
            }
            if (rd.FieldExists("A_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["A_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static AnhCollection SelectByAbId(SqlConnection con, string AB_ID)
        {
            var List = new AnhCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectByAbId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static AnhCollection SelectByAbId(SqlConnection con, string AB_ID, int Top)
        {
            var List = new AnhCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectByAbId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}


