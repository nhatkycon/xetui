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
    #region Promoted
    #region BO
    public class Promoted : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Guid PRowId { get; set; }
        public Int32 Loai { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Keywords { get; set; }
        public String Anh { get; set; }
        public String Url { get; set; }
        public String KhachHang { get; set; }
        public Guid KhachHangId { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public String refId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Boolean Approved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public String ApprovedBy { get; set; }
        public Int32 Views { get; set; }
        public Int32 Clicked { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Promoted()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PromotedDal.getFromReader(rd);
        }
        public string LoaiTen
        {
            get
            {
                switch(Loai)
                {
                    case 1:
                        return "Xe top";
                    case 2:
                        return "Xe Home Big";
                    case 3:
                        return "Xe Home Medium";
                    case 4:
                        return "Xe Home Small";
                    case 5:
                        return "Xe View";
                    case 10:
                        return "Other";
                    default:
                        return string.Empty;
                }
            }
        }
    }
    #endregion
    #region Collection
    public class PromotedCollection : BaseEntityCollection<Promoted>
    { }
    #endregion
    #region Dal
    public class PromotedDal
    {
        #region Methods

        public static void DeleteById(Int32 P_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Delete_DeleteById_linhnx", obj);
        }
        public static Promoted Insert(Promoted Inserted)
        {
            Promoted Item = new Promoted();
            SqlParameter[] obj = new SqlParameter[20];
            obj[0] = new SqlParameter("P_PRowId", Inserted.PRowId);
            obj[1] = new SqlParameter("P_Loai", Inserted.Loai);
            obj[2] = new SqlParameter("P_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("P_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("P_Keywords", Inserted.Keywords);
            obj[5] = new SqlParameter("P_Anh", Inserted.Anh);
            obj[6] = new SqlParameter("P_Url", Inserted.Url);
            obj[7] = new SqlParameter("P_KhachHang", Inserted.KhachHang);
            obj[8] = new SqlParameter("P_KhachHangId", Inserted.KhachHangId);
            if (Inserted.NgayBatDau > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("P_NgayBatDau", Inserted.NgayBatDau);
            }
            else
            {
                obj[9] = new SqlParameter("P_NgayBatDau", DBNull.Value);
            }
            if (Inserted.NgayKetThuc > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", Inserted.NgayKetThuc);
            }
            else
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", DBNull.Value);
            }
            obj[11] = new SqlParameter("P_refId", Inserted.refId);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("P_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("P_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("P_NguoiTao", Inserted.NguoiTao);
            obj[14] = new SqlParameter("P_Approved", Inserted.Approved);
            obj[15] = new SqlParameter("P_ApprovedDate", Inserted.ApprovedDate);
            obj[16] = new SqlParameter("P_ApprovedBy", Inserted.ApprovedBy);
            obj[17] = new SqlParameter("P_Views", Inserted.Views);
            obj[18] = new SqlParameter("P_Clicked", Inserted.Clicked);
            obj[19] = new SqlParameter("P_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Promoted Update(Promoted Updated)
        {
            Promoted Item = new Promoted();
            SqlParameter[] obj = new SqlParameter[21];
            obj[0] = new SqlParameter("P_ID", Updated.ID);
            obj[1] = new SqlParameter("P_PRowId", Updated.PRowId);
            obj[2] = new SqlParameter("P_Loai", Updated.Loai);
            obj[3] = new SqlParameter("P_Ten", Updated.Ten);
            obj[4] = new SqlParameter("P_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("P_Keywords", Updated.Keywords);
            obj[6] = new SqlParameter("P_Anh", Updated.Anh);
            obj[7] = new SqlParameter("P_Url", Updated.Url);
            obj[8] = new SqlParameter("P_KhachHang", Updated.KhachHang);
            obj[9] = new SqlParameter("P_KhachHangId", Updated.KhachHangId);
            if (Updated.NgayBatDau > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("P_NgayBatDau", Updated.NgayBatDau);
            }
            else
            {
                obj[10] = new SqlParameter("P_NgayBatDau", DBNull.Value);
            }
            if (Updated.NgayKetThuc > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("P_NgayKetThuc", Updated.NgayKetThuc);
            }
            else
            {
                obj[11] = new SqlParameter("P_NgayKetThuc", DBNull.Value);
            }
            obj[12] = new SqlParameter("P_refId", Updated.refId);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("P_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("P_NgayTao", DBNull.Value);
            }
            obj[14] = new SqlParameter("P_NguoiTao", Updated.NguoiTao);
            obj[15] = new SqlParameter("P_Approved", Updated.Approved);
            obj[16] = new SqlParameter("P_ApprovedDate", Updated.ApprovedDate);
            obj[17] = new SqlParameter("P_ApprovedBy", Updated.ApprovedBy);
            obj[18] = new SqlParameter("P_Views", Updated.Views);
            obj[19] = new SqlParameter("P_Clicked", Updated.Clicked);
            obj[20] = new SqlParameter("P_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Promoted SelectById(Int32 P_ID)
        {
            Promoted Item = new Promoted();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PromotedCollection SelectAll()
        {
            PromotedCollection List = new PromotedCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Promoted> PagerNormal(string url, bool rewrite, string sort, string q, int size, string tuNgay, string denNgay, string loai, string duyet)
        {
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(loai))
            {
                obj[2] = new SqlParameter("loai", loai);
            }
            else
            {
                obj[2] = new SqlParameter("loai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(duyet))
            {
                obj[3] = new SqlParameter("Duyet", duyet);
            }
            else
            {
                obj[3] = new SqlParameter("Duyet", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(denNgay))
            {
                obj[4] = new SqlParameter("DenNgay", denNgay);
            }
            else
            {
                obj[4] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(tuNgay))
            {
                obj[5] = new SqlParameter("TuNgay", tuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("TuNgay", DBNull.Value);
            }
            var pg = new Pager<Promoted>("sp_tblPromoted_Pager_Normal_linhnx", "p", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Promoted getFromReader(IDataReader rd)
        {
            var item = new Promoted();
            if (rd.FieldExists("P_ID"))
            {
                item.ID = (Int32)(rd["P_ID"]);
            }
            if (rd.FieldExists("P_PRowId"))
            {
                item.PRowId = (Guid)(rd["P_PRowId"]);
            }
            if (rd.FieldExists("P_Loai"))
            {
                item.Loai = (Int32)(rd["P_Loai"]);
            }
            if (rd.FieldExists("P_Ten"))
            {
                item.Ten = (String)(rd["P_Ten"]);
            }
            if (rd.FieldExists("P_MoTa"))
            {
                item.MoTa = (String)(rd["P_MoTa"]);
            }
            if (rd.FieldExists("P_Keywords"))
            {
                item.Keywords = (String)(rd["P_Keywords"]);
            }
            if (rd.FieldExists("P_Anh"))
            {
                item.Anh = (String)(rd["P_Anh"]);
            }
            if (rd.FieldExists("P_Url"))
            {
                item.Url = (String)(rd["P_Url"]);
            }
            if (rd.FieldExists("P_KhachHang"))
            {
                item.KhachHang = (String)(rd["P_KhachHang"]);
            }
            if (rd.FieldExists("P_KhachHangId"))
            {
                item.KhachHangId = (Guid)(rd["P_KhachHangId"]);
            }
            if (rd.FieldExists("P_NgayBatDau"))
            {
                item.NgayBatDau = (DateTime)(rd["P_NgayBatDau"]);
            }
            if (rd.FieldExists("P_NgayKetThuc"))
            {
                item.NgayKetThuc = (DateTime)(rd["P_NgayKetThuc"]);
            }
            if (rd.FieldExists("P_refId"))
            {
                item.refId = (String)(rd["P_refId"]);
            }
            if (rd.FieldExists("P_NgayTao"))
            {
                item.NgayTao = (DateTime)(rd["P_NgayTao"]);
            }
            if (rd.FieldExists("P_NguoiTao"))
            {
                item.NguoiTao = (String)(rd["P_NguoiTao"]);
            }
            if (rd.FieldExists("P_Approved"))
            {
                item.Approved = (Boolean)(rd["P_Approved"]);
            }
            if (rd.FieldExists("P_ApprovedDate"))
            {
                item.ApprovedDate = (DateTime)(rd["P_ApprovedDate"]);
            }
            if (rd.FieldExists("P_ApprovedBy"))
            {
                item.ApprovedBy = (String)(rd["P_ApprovedBy"]);
            }
            if (rd.FieldExists("P_Views"))
            {
                item.Views = (Int32)(rd["P_Views"]);
            }
            if (rd.FieldExists("P_Clicked"))
            {
                item.Clicked = (Int32)(rd["P_Clicked"]);
            }
            if (rd.FieldExists("P_RowId"))
            {
                item.RowId = (Guid)(rd["P_RowId"]);
            }
            return item;
        }
        #endregion
        #region Extend
        public static PromotedCollection SelectByLoai(SqlConnection con, string top, string loai)
        {
            var list = new PromotedCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("loai", loai);
            obj[1] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Select_SelectByLoai_linhnx", obj))
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


