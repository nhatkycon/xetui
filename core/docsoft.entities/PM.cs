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
    #region Pm
    #region BO
    public class Pm : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 PMR_ID { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayXem { get; set; }
        public Boolean Doc { get; set; }
        public String NguoiGui { get; set; }
        public String NguoiNhan { get; set; }
        public Guid RowId { get; set; }
        public Boolean NguoiGuiXoa { get; set; }
        public Boolean NguoiNhanXoa { get; set; }
        #endregion
        #region Contructor
        public Pm()
        { }
        #endregion
        #region Customs properties

        public Member NguoiGuiMember { get; set; }
        public Member NguoiNhanMember { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PmDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PmCollection : BaseEntityCollection<Pm>
    { }
    #endregion
    #region Dal
    public class PmDal
    {
        #region Methods

        public static void DeleteById(Int64 PM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PM_ID", PM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Delete_DeleteById_linhnx", obj);
        }
        public static Pm Insert(Pm Inserted)
        {
            Pm Item = new Pm();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("PM_PMR_ID", Inserted.PMR_ID);
            obj[1] = new SqlParameter("PM_NoiDung", Inserted.NoiDung);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("PM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("PM_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayXem > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PM_NgayXem", Inserted.NgayXem);
            }
            else
            {
                obj[3] = new SqlParameter("PM_NgayXem", DBNull.Value);
            }
            obj[4] = new SqlParameter("PM_Doc", Inserted.Doc);
            obj[5] = new SqlParameter("PM_NguoiGui", Inserted.NguoiGui);
            obj[6] = new SqlParameter("PM_NguoiNhan", Inserted.NguoiNhan);
            obj[7] = new SqlParameter("PM_RowId", Inserted.RowId);
            obj[8] = new SqlParameter("PM_NguoiGuiXoa", Inserted.NguoiGuiXoa);
            obj[9] = new SqlParameter("PM_NguoiNhanXoa", Inserted.NguoiNhanXoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Pm Update(Pm Updated)
        {
            Pm Item = new Pm();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("PM_ID", Updated.ID);
            obj[1] = new SqlParameter("PM_PMR_ID", Updated.PMR_ID);
            obj[2] = new SqlParameter("PM_NoiDung", Updated.NoiDung);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("PM_NgayTao", DBNull.Value);
            }
            if (Updated.NgayXem > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PM_NgayXem", Updated.NgayXem);
            }
            else
            {
                obj[4] = new SqlParameter("PM_NgayXem", DBNull.Value);
            }
            obj[5] = new SqlParameter("PM_Doc", Updated.Doc);
            obj[6] = new SqlParameter("PM_NguoiGui", Updated.NguoiGui);
            obj[7] = new SqlParameter("PM_NguoiNhan", Updated.NguoiNhan);
            obj[8] = new SqlParameter("PM_RowId", Updated.RowId);
            obj[9] = new SqlParameter("PM_NguoiGuiXoa", Updated.NguoiGuiXoa);
            obj[10] = new SqlParameter("PM_NguoiNhanXoa", Updated.NguoiNhanXoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Pm SelectById(Int64 PM_ID)
        {
            Pm Item = new Pm();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PM_ID", PM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PmCollection SelectAll()
        {
            PmCollection List = new PmCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Pm> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Pm> pg = new Pager<Pm>("sp_tblPm_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Pm getFromReader(IDataReader rd)
        {
            Pm Item = new Pm();
            if (rd.FieldExists("PM_ID"))
            {
                Item.ID = (Int64)(rd["PM_ID"]);
            }
            if (rd.FieldExists("PM_PMR_ID"))
            {
                Item.PMR_ID = (Int32)(rd["PM_PMR_ID"]);
            }
            if (rd.FieldExists("PM_NoiDung"))
            {
                Item.NoiDung = (String)(rd["PM_NoiDung"]);
            }
            if (rd.FieldExists("PM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PM_NgayTao"]);
            }
            if (rd.FieldExists("PM_NgayXem"))
            {
                Item.NgayXem = (DateTime)(rd["PM_NgayXem"]);
            }
            if (rd.FieldExists("PM_Doc"))
            {
                Item.Doc = (Boolean)(rd["PM_Doc"]);
            }
            if (rd.FieldExists("PM_NguoiGui"))
            {
                Item.NguoiGui = (String)(rd["PM_NguoiGui"]);
            }
            if (rd.FieldExists("PM_NguoiNhan"))
            {
                Item.NguoiNhan = (String)(rd["PM_NguoiNhan"]);
            }
            if (rd.FieldExists("PM_RowId"))
            {
                Item.RowId = (Guid)(rd["PM_RowId"]);
            }
            if (rd.FieldExists("PM_NguoiGuiXoa"))
            {
                Item.NguoiGuiXoa = (Boolean)(rd["PM_NguoiGuiXoa"]);
            }
            if (rd.FieldExists("PM_NguoiNhanXoa"))
            {
                Item.NguoiNhanXoa = (Boolean)(rd["PM_NguoiNhanXoa"]);
            }

            var mem = new Member();
            if (rd.FieldExists("NguoiGui_Ten"))
            {
                mem.Ten = (String)(rd["NguoiGui_Ten"]);
            }
            if (rd.FieldExists("NguoiGui_Anh"))
            {
                mem.Anh = (String)(rd["NguoiGui_Anh"]);
            }
            Item.NguoiGuiMember = mem;


            mem = new Member();
            if (rd.FieldExists("NguoiNhan_Ten"))
            {
                mem.Ten = (String)(rd["NguoiNhan_Ten"]);
            }
            if (rd.FieldExists("NguoiNhan_Anh"))
            {
                mem.Anh = (String)(rd["NguoiNhan_Anh"]);
            }
            Item.NguoiNhanMember = mem;

            return Item;
        }
        #endregion
        #region Extend
        public static Int32 NewByUser(string username)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", username);
            return
                Convert.ToInt32(
                    SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure,
                                            "sp_tblPm_Select_NewByUser_linhnx", obj).ToString());
        }
        public static List<Pm> NewByUserGet(string username, int top)
        {
            var list = new List<Pm>();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("Top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_NewByUserGet_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static PmCollection SelectByUser(string username, int Top, string fromId)
        {
            var list = new PmCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(fromId))
            {
                obj[2] = new SqlParameter("fromId", fromId);
            }
            else
            {
                obj[2] = new SqlParameter("fromId", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_SelectByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static PmCollection SelectByPmRoomId(string PmRoomId, int Top, string fromId, string username)
        {
            var list = new PmCollection();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("PmRoomId", PmRoomId);
            obj[1] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(fromId))
            {
                obj[2] = new SqlParameter("fromId", fromId);
            }
            else
            {
                obj[2] = new SqlParameter("fromId", DBNull.Value);
            }
            obj[3] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_SelectByPmRoomId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static PmCollection SelectLatestByPmRoomId(string PmRoomId, int Top, string fromId, string username)
        {
            var list = new PmCollection();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("PmRoomId", PmRoomId);
            obj[1] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(fromId))
            {
                obj[2] = new SqlParameter("fromId", fromId);
            }
            else
            {
                obj[2] = new SqlParameter("fromId", DBNull.Value);
            }
            obj[3] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPm_Select_SelectLatestByPmRoomId_linhnx", obj))
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


