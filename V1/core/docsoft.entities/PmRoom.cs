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
    #region PmRoom
    #region BO
    public class PmRoom : BaseEntity
    {
        #region Properties
        public Int32 Id { get; set; }
        public String NguoiGui { get; set; }
        public String NguoiNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Int32 Total { get; set; }
        #endregion
        #region Contructor
        public PmRoom()
        { }
        #endregion
        #region Customs properties

        public Member Member { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PmRoomDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PmRoomCollection : BaseEntityCollection<PmRoom>
    { }
    #endregion
    #region Dal
    public class PmRoomDal
    {
        #region Methods

        public static void DeleteById(Int32 PMR_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PMR_ID", PMR_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Delete_DeleteById_linhnx", obj);
        }
        public static PmRoom Insert(PmRoom Inserted)
        {
            PmRoom Item = new PmRoom();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("PMR_NguoiGui", Inserted.NguoiGui);
            obj[1] = new SqlParameter("PMR_NguoiNhan", Inserted.NguoiNhan);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("PMR_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("PMR_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PMR_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[3] = new SqlParameter("PMR_NgayCapNhat", DBNull.Value);
            }
            obj[4] = new SqlParameter("PMR_RowId", Inserted.RowId);
            obj[5] = new SqlParameter("PMR_Total", Inserted.Total);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PmRoom Update(PmRoom Updated)
        {
            PmRoom Item = new PmRoom();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("PMR_ID", Updated.Id);
            obj[1] = new SqlParameter("PMR_NguoiGui", Updated.NguoiGui);
            obj[2] = new SqlParameter("PMR_NguoiNhan", Updated.NguoiNhan);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PMR_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("PMR_NgayTao", DBNull.Value);
            }
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PMR_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[4] = new SqlParameter("PMR_NgayCapNhat", DBNull.Value);
            }
            obj[5] = new SqlParameter("PMR_RowId", Updated.RowId);
            obj[6] = new SqlParameter("PMR_Total", Updated.Total);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PmRoom SelectById(Int32 PMR_ID)
        {
            PmRoom Item = new PmRoom();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PMR_ID", PMR_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PmRoomCollection SelectAll()
        {
            PmRoomCollection List = new PmRoomCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PmRoom> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<PmRoom> pg = new Pager<PmRoom>("sp_tblPmRoom_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static PmRoom getFromReader(IDataReader rd)
        {
            PmRoom Item = new PmRoom();
            if (rd.FieldExists("PMR_ID"))
            {
                Item.Id = (Int32)(rd["PMR_ID"]);
            }
            if (rd.FieldExists("PMR_NguoiGui"))
            {
                Item.NguoiGui = (String)(rd["PMR_NguoiGui"]);
            }
            if (rd.FieldExists("PMR_NguoiNhan"))
            {
                Item.NguoiNhan = (String)(rd["PMR_NguoiNhan"]);
            }
            if (rd.FieldExists("PMR_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PMR_NgayTao"]);
            }
            if (rd.FieldExists("PMR_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PMR_NgayCapNhat"]);
            }
            if (rd.FieldExists("PMR_RowId"))
            {
                Item.RowId = (Guid)(rd["PMR_RowId"]);
            }
            var mem = new Member();
            if (rd.FieldExists("MEM_Ten"))
            {
                mem.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("MEM_Anh"))
            {
                mem.Anh = (String)(rd["MEM_Anh"]);
            }
            if (rd.FieldExists("PMR_Total"))
            {
                Item.Total = (Int32)(rd["PMR_Total"]);
            }
            if (rd.FieldExists("MEM_Username"))
            {
                mem.Username = (String)(rd["MEM_Username"]);
            }
            Item.Member = mem;
            return Item;
        }
        #endregion
        #region Extend
        public static PmRoomCollection SelectByUser(SqlConnection con, string username, int Top, bool? Doc)
        {
            var list = new PmRoomCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblPmRoom_Select_SelectByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static PmRoom SelectByU1U2(string u1,string u2)
        {
            var item = new PmRoom();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("u1", u1);
            obj[1] = new SqlParameter("u2", u2);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPmRoom_Select_SelectByU1U2_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }
        #endregion
    }
    #endregion
    #endregion
    
}


