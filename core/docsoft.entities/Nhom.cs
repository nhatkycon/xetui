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
    #region Nhom
    #region BO
    public class Nhom : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Alias { get; set; }
        public String MoTa { get; set; }
        public String GioiThieu { get; set; }
        public String Anh { get; set; }
        public String Cover { get; set; }
        public String ConverCss { get; set; }
        public Int32 Views { get; set; }
        public Int32 TotalMember { get; set; }
        public Int32 TotalComment { get; set; }
        public Int32 TotalLiked { get; set; }
        public Int32 TotalBlog { get; set; }
        public Boolean Liked { get; set; }
        public Boolean Joined { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Active { get; set; }
        public Boolean NhomMo { get; set; }
        public Boolean IsAdmin { get; set; }
        public String Admin { get; set; }
        public Guid RowId { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Duyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public String NguoiDuyet { get; set; }
        #endregion
        #region Contructor
        public Nhom()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NhomDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NhomCollection : BaseEntityCollection<Nhom>
    { }
    #endregion
    #region Dal
    public class NhomDal
    {
        #region Methods

        public static void DeleteById(Int32 G_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Delete_DeleteById_linhnx", obj);
        }

        public static Nhom Insert(Nhom item)
        {
            var Item = new Nhom();
            var obj = new SqlParameter[28];
            obj[0] = new SqlParameter("G_ID", item.ID);
            obj[1] = new SqlParameter("G_Ten", item.Ten);
            obj[2] = new SqlParameter("G_Alias", item.Alias);
            obj[3] = new SqlParameter("G_MoTa", item.MoTa);
            obj[4] = new SqlParameter("G_GioiThieu", item.GioiThieu);
            obj[5] = new SqlParameter("G_Anh", item.Anh);
            obj[6] = new SqlParameter("G_Cover", item.Cover);
            obj[7] = new SqlParameter("G_ConverCss", item.ConverCss);
            obj[8] = new SqlParameter("G_Views", item.Views);
            obj[9] = new SqlParameter("G_TotalMember", item.TotalMember);
            obj[10] = new SqlParameter("G_TotalComment", item.TotalComment);
            obj[11] = new SqlParameter("G_TotalLiked", item.TotalLiked);
            obj[12] = new SqlParameter("G_TotalBlog", item.TotalBlog);
            obj[13] = new SqlParameter("G_Liked", item.Liked);
            obj[14] = new SqlParameter("G_Joined", item.Joined);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("G_NgayTao", item.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("G_NgayTao", DBNull.Value);
            }
            obj[16] = new SqlParameter("G_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("G_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("G_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("G_NguoiCapNhat", item.NguoiCapNhat);
            obj[19] = new SqlParameter("G_Active", item.Active);
            obj[20] = new SqlParameter("G_NhomMo", item.NhomMo);
            obj[21] = new SqlParameter("G_IsAdmin", item.IsAdmin);
            obj[22] = new SqlParameter("G_Admin", item.Admin);
            obj[23] = new SqlParameter("G_RowId", item.RowId);
            obj[24] = new SqlParameter("G_ThuTu", item.ThuTu);
            obj[25] = new SqlParameter("G_Duyet", item.Duyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[26] = new SqlParameter("G_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[26] = new SqlParameter("G_NgayDuyet", DBNull.Value);
            }
            obj[27] = new SqlParameter("G_NguoiDuyet", item.NguoiDuyet);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Nhom Update(Nhom item)
        {
            var Item = new Nhom();
            var obj = new SqlParameter[28];
            obj[0] = new SqlParameter("G_ID", item.ID);
            obj[1] = new SqlParameter("G_Ten", item.Ten);
            obj[2] = new SqlParameter("G_Alias", item.Alias);
            obj[3] = new SqlParameter("G_MoTa", item.MoTa);
            obj[4] = new SqlParameter("G_GioiThieu", item.GioiThieu);
            obj[5] = new SqlParameter("G_Anh", item.Anh);
            obj[6] = new SqlParameter("G_Cover", item.Cover);
            obj[7] = new SqlParameter("G_ConverCss", item.ConverCss);
            obj[8] = new SqlParameter("G_Views", item.Views);
            obj[9] = new SqlParameter("G_TotalMember", item.TotalMember);
            obj[10] = new SqlParameter("G_TotalComment", item.TotalComment);
            obj[11] = new SqlParameter("G_TotalLiked", item.TotalLiked);
            obj[12] = new SqlParameter("G_TotalBlog", item.TotalBlog);
            obj[13] = new SqlParameter("G_Liked", item.Liked);
            obj[14] = new SqlParameter("G_Joined", item.Joined);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("G_NgayTao", item.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("G_NgayTao", DBNull.Value);
            }
            obj[16] = new SqlParameter("G_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("G_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("G_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("G_NguoiCapNhat", item.NguoiCapNhat);
            obj[19] = new SqlParameter("G_Active", item.Active);
            obj[20] = new SqlParameter("G_NhomMo", item.NhomMo);
            obj[21] = new SqlParameter("G_IsAdmin", item.IsAdmin);
            obj[22] = new SqlParameter("G_Admin", item.Admin);
            obj[23] = new SqlParameter("G_RowId", item.RowId);
            obj[24] = new SqlParameter("G_ThuTu", item.ThuTu);
            obj[25] = new SqlParameter("G_Duyet", item.Duyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[26] = new SqlParameter("G_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[26] = new SqlParameter("G_NgayDuyet", DBNull.Value);
            }
            obj[27] = new SqlParameter("G_NguoiDuyet", item.NguoiDuyet);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Nhom SelectById(Int32 G_ID)
        {
            var Item = new Nhom();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NhomCollection SelectAll()
        {
            var List = new NhomCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Nhom> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Nhom>("sp_tblNhom_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Nhom getFromReader(IDataReader rd)
        {
            var Item = new Nhom();
            if (rd.FieldExists("G_ID"))
            {
                Item.ID = (Int32)(rd["G_ID"]);
            }
            if (rd.FieldExists("G_Ten"))
            {
                Item.Ten = (String)(rd["G_Ten"]);
            }
            if (rd.FieldExists("G_Alias"))
            {
                Item.Alias = (String)(rd["G_Alias"]);
            }
            if (rd.FieldExists("G_MoTa"))
            {
                Item.MoTa = (String)(rd["G_MoTa"]);
            }
            if (rd.FieldExists("G_GioiThieu"))
            {
                Item.GioiThieu = (String)(rd["G_GioiThieu"]);
            }
            if (rd.FieldExists("G_Anh"))
            {
                Item.Anh = (String)(rd["G_Anh"]);
            }
            if (rd.FieldExists("G_Cover"))
            {
                Item.Cover = (String)(rd["G_Cover"]);
            }
            if (rd.FieldExists("G_ConverCss"))
            {
                Item.ConverCss = (String)(rd["G_ConverCss"]);
            }
            if (rd.FieldExists("G_Views"))
            {
                Item.Views = (Int32)(rd["G_Views"]);
            }
            if (rd.FieldExists("G_TotalMember"))
            {
                Item.TotalMember = (Int32)(rd["G_TotalMember"]);
            }
            if (rd.FieldExists("G_TotalComment"))
            {
                Item.TotalComment = (Int32)(rd["G_TotalComment"]);
            }
            if (rd.FieldExists("G_TotalLiked"))
            {
                Item.TotalLiked = (Int32)(rd["G_TotalLiked"]);
            }
            if (rd.FieldExists("G_TotalBlog"))
            {
                Item.TotalBlog = (Int32)(rd["G_TotalBlog"]);
            }
            if (rd.FieldExists("G_Liked"))
            {
                Item.Liked = (Boolean)(rd["G_Liked"]);
            }
            if (rd.FieldExists("G_Joined"))
            {
                Item.Joined = (Boolean)(rd["G_Joined"]);
            }
            if (rd.FieldExists("G_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["G_NgayTao"]);
            }
            if (rd.FieldExists("G_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["G_NguoiTao"]);
            }
            if (rd.FieldExists("G_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["G_NgayCapNhat"]);
            }
            if (rd.FieldExists("G_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["G_NguoiCapNhat"]);
            }
            if (rd.FieldExists("G_Active"))
            {
                Item.Active = (Boolean)(rd["G_Active"]);
            }
            if (rd.FieldExists("G_NhomMo"))
            {
                Item.NhomMo = (Boolean)(rd["G_NhomMo"]);
            }
            if (rd.FieldExists("G_IsAdmin"))
            {
                Item.IsAdmin = (Boolean)(rd["G_IsAdmin"]);
            }
            if (rd.FieldExists("G_Admin"))
            {
                Item.Admin = (String)(rd["G_Admin"]);
            }
            if (rd.FieldExists("G_RowId"))
            {
                Item.RowId = (Guid)(rd["G_RowId"]);
            }
            if (rd.FieldExists("G_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["G_ThuTu"]);
            }
            if (rd.FieldExists("G_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["G_Duyet"]);
            }
            if (rd.FieldExists("G_NgayDuyet"))
            {
                Item.NgayDuyet = (DateTime)(rd["G_NgayDuyet"]);
            }
            if (rd.FieldExists("G_NguoiDuyet"))
            {
                Item.NguoiDuyet = (String)(rd["G_NguoiDuyet"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static NhomCollection SelectByUser(string username, int top, bool? approved)
        {
            var list = new NhomCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("Top", top);
            if (approved.HasValue)
            {
                obj[2] = new SqlParameter("TV_Approved", approved);
            }
            else
            {
                obj[2] = new SqlParameter("TV_Approved", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNhom_Select_SelectByUser_linhnx", obj))
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


