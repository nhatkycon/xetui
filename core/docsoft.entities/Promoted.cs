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
        public Object ApprovedDate { get; set; }
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
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Delete_DeleteById_linhnx", obj);
        }

        public static Promoted Insert(Promoted item)
        {
            var Item = new Promoted();
            var obj = new SqlParameter[20];
            obj[0] = new SqlParameter("P_ID", item.ID);
            obj[1] = new SqlParameter("P_PRowId", item.PRowId);
            obj[2] = new SqlParameter("P_Loai", item.Loai);
            obj[3] = new SqlParameter("P_Ten", item.Ten);
            obj[4] = new SqlParameter("P_MoTa", item.MoTa);
            obj[5] = new SqlParameter("P_Anh", item.Anh);
            obj[6] = new SqlParameter("P_Url", item.Url);
            obj[7] = new SqlParameter("P_KhachHang", item.KhachHang);
            obj[8] = new SqlParameter("P_KhachHangId", item.KhachHangId);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("P_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[9] = new SqlParameter("P_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", DBNull.Value);
            }
            obj[11] = new SqlParameter("P_refId", item.refId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("P_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("P_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("P_NguoiTao", item.NguoiTao);
            obj[14] = new SqlParameter("P_Approved", item.Approved);
            obj[15] = new SqlParameter("P_ApprovedDate", item.ApprovedDate);
            obj[16] = new SqlParameter("P_ApprovedBy", item.ApprovedBy);
            obj[17] = new SqlParameter("P_Views", item.Views);
            obj[18] = new SqlParameter("P_Clicked", item.Clicked);
            obj[19] = new SqlParameter("P_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Promoted Update(Promoted item)
        {
            var Item = new Promoted();
            var obj = new SqlParameter[20];
            obj[0] = new SqlParameter("P_ID", item.ID);
            obj[1] = new SqlParameter("P_PRowId", item.PRowId);
            obj[2] = new SqlParameter("P_Loai", item.Loai);
            obj[3] = new SqlParameter("P_Ten", item.Ten);
            obj[4] = new SqlParameter("P_MoTa", item.MoTa);
            obj[5] = new SqlParameter("P_Anh", item.Anh);
            obj[6] = new SqlParameter("P_Url", item.Url);
            obj[7] = new SqlParameter("P_KhachHang", item.KhachHang);
            obj[8] = new SqlParameter("P_KhachHangId", item.KhachHangId);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("P_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[9] = new SqlParameter("P_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[10] = new SqlParameter("P_NgayKetThuc", DBNull.Value);
            }
            obj[11] = new SqlParameter("P_refId", item.refId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("P_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("P_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("P_NguoiTao", item.NguoiTao);
            obj[14] = new SqlParameter("P_Approved", item.Approved);
            obj[15] = new SqlParameter("P_ApprovedDate", item.ApprovedDate);
            obj[16] = new SqlParameter("P_ApprovedBy", item.ApprovedBy);
            obj[17] = new SqlParameter("P_Views", item.Views);
            obj[18] = new SqlParameter("P_Clicked", item.Clicked);
            obj[19] = new SqlParameter("P_RowId", item.RowId);

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
            var Item = new Promoted();
            var obj = new SqlParameter[1];
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
            var List = new PromotedCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPromoted_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Promoted> PagerNormal(string url, bool rewrite, string sort, string q, int size
            , string loai, string tuNgay, string denNgay)
        {
            var obj = new SqlParameter[5];
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
                obj[2] = new SqlParameter("Loai", loai);
            }
            else
            {
                obj[2] = new SqlParameter("Loai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(tuNgay))
            {
                obj[3] = new SqlParameter("TuNgay", tuNgay);
            }
            else
            {
                obj[3] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(denNgay))
            {
                obj[4] = new SqlParameter("DenNgay", denNgay);
            }
            else
            {
                obj[4] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<Promoted>("sp_tblPromoted_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Promoted getFromReader(IDataReader rd)
        {
            var Item = new Promoted();
            if (rd.FieldExists("P_ID"))
            {
                Item.ID = (Int32)(rd["P_ID"]);
            }
            if (rd.FieldExists("P_PRowId"))
            {
                Item.PRowId = (Guid)(rd["P_PRowId"]);
            }
            if (rd.FieldExists("P_Loai"))
            {
                Item.Loai = (Int32)(rd["P_Loai"]);
            }
            if (rd.FieldExists("P_Ten"))
            {
                Item.Ten = (String)(rd["P_Ten"]);
            }
            if (rd.FieldExists("P_MoTa"))
            {
                Item.MoTa = (String)(rd["P_MoTa"]);
            }
            if (rd.FieldExists("P_Anh"))
            {
                Item.Anh = (String)(rd["P_Anh"]);
            }
            if (rd.FieldExists("P_Url"))
            {
                Item.Url = (String)(rd["P_Url"]);
            }
            if (rd.FieldExists("P_KhachHang"))
            {
                Item.KhachHang = (String)(rd["P_KhachHang"]);
            }
            if (rd.FieldExists("P_KhachHangId"))
            {
                Item.KhachHangId = (Guid)(rd["P_KhachHangId"]);
            }
            if (rd.FieldExists("P_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["P_NgayBatDau"]);
            }
            if (rd.FieldExists("P_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["P_NgayKetThuc"]);
            }
            if (rd.FieldExists("P_refId"))
            {
                Item.refId = (String)(rd["P_refId"]);
            }
            if (rd.FieldExists("P_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["P_NgayTao"]);
            }
            if (rd.FieldExists("P_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["P_NguoiTao"]);
            }
            if (rd.FieldExists("P_Approved"))
            {
                Item.Approved = (Boolean)(rd["P_Approved"]);
            }
            if (rd.FieldExists("P_ApprovedDate"))
            {
                Item.ApprovedDate = (Object)(rd["P_ApprovedDate"]);
            }
            if (rd.FieldExists("P_ApprovedBy"))
            {
                Item.ApprovedBy = (String)(rd["P_ApprovedBy"]);
            }
            if (rd.FieldExists("P_Views"))
            {
                Item.Views = (Int32)(rd["P_Views"]);
            }
            if (rd.FieldExists("P_Clicked"))
            {
                Item.Clicked = (Int32)(rd["P_Clicked"]);
            }
            if (rd.FieldExists("P_RowId"))
            {
                Item.RowId = (Guid)(rd["P_RowId"]);
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


