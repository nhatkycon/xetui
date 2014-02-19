using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region Xe
    #region BO
    public class Xe : BaseEntity
    {
        #region Properties
        public Int64 Id { get; set; }
        public Guid HANG_ID { get; set; }
        public Guid MODEL_ID { get; set; }
        public String SubModel { get; set; }
        public Boolean XuatXu { get; set; }
        public Int32 Nam { get; set; }
        public Boolean TinhTrang { get; set; }
        public Guid DONGXE_ID { get; set; }
        public Guid MAUNGOAITHAT_ID { get; set; }
        public Guid MAUNOITHAT_ID { get; set; }
        public Boolean HopSo { get; set; }
        public Guid KIEUDANDONG_ID { get; set; }
        public Guid NHIENLIEU_ID { get; set; }
        public Guid THANHPHO_ID { get; set; }
        public String Ten { get; set; }
        public Guid RowId { get; set; }
        public Boolean RaoBan { get; set; }
        public Int64 Gia { get; set; }
        public Boolean DaBan { get; set; }
        public String Chu { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Khoa { get; set; }
        public Boolean Xoa { get; set; }
        public Boolean DangLai { get; set; }
        public Int32 TotalComment { get; set; }
        public Int32 TotalLike { get; set; }
        public Int32 TotalBlog { get; set; }
        public Int32 TotalView { get; set; }
        public String Anh { get; set; }
        public Boolean Duyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public String NguoiDuyet { get; set; }
        #endregion
        #region Contructor
        public Xe()
        {
            BinhLuanIds=new List<long>();
            BlogIds=new List<long>();
            Fans = new List<string>();
            AnhIds=new List<Guid>();
        }
        #endregion
        #region Customs properties

        public List<Int64> BinhLuanIds { get; set; }
        public List<BinhLuan> GetBinhLuans()
        {
            return new List<BinhLuan>();
        }

        public List<Int64> BlogIds { get; set; }
        public List<Blog> GetBlog()
        {
            return new List<Blog>();
        }

        public List<string> Fans { get; set; }
        public List<Member> GetFans()
        {
            return new List<Member>();
        }

        public List<Guid> AnhIds { get; set; }
        public List<Anh> GetAnhs()
        {
            return new List<Anh>();
        }

        public string GioiThieu { get; set; }
        public List<Anh> Anhs { get; set; }

        public string HANG_Ma { get; set; }
        public string HANG_Ten { get; set; }

        public string MODEL_Ma { get; set; }
        public string MODEL_Ten { get; set; }

        public string THANHPHO_Ten { get; set; }

        public string NguoiTao_Ten { get; set; }
        public Member Member { get; set; }
        public bool Liked { get; set; }
        #endregion
        public string XeUrl
        {
            get
            {
                return string.Format("/cars/{0}/{1}/{2}/{3}/"
                 , Lib.Bodau(HANG_Ten)
                 , Lib.Bodau(MODEL_Ten)
                 , Lib.Bodau(Ten)
                 , Id); 
            }
        }
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XeCollection : BaseEntityCollection<Xe>
    { }
    #endregion
    #region Dal
    public class XeDal
    {
        #region Methods

        public static void DeleteById(Int64 X_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("X_ID", X_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Delete_DeleteById_linhnx", obj);
            CacheHelper.Remove(string.Format(CacheItemKey, X_ID));
        }
        public static Xe Insert(Xe Inserted)
        {
            var item = new Xe();
            var obj = new SqlParameter[35];
            obj[0] = new SqlParameter("X_HANG_ID", Inserted.HANG_ID);
            obj[1] = new SqlParameter("X_MODEL_ID", Inserted.MODEL_ID);
            obj[2] = new SqlParameter("X_SubModel", Inserted.SubModel);
            obj[3] = new SqlParameter("X_XuatXu", Inserted.XuatXu);
            obj[4] = new SqlParameter("X_Nam", Inserted.Nam);
            obj[5] = new SqlParameter("X_TinhTrang", Inserted.TinhTrang);
            obj[6] = new SqlParameter("X_DONGXE_ID", Inserted.DONGXE_ID);
            obj[7] = new SqlParameter("X_MAUNGOAITHAT_ID", Inserted.MAUNGOAITHAT_ID);
            obj[8] = new SqlParameter("X_MAUNOITHAT_ID", Inserted.MAUNOITHAT_ID);
            obj[9] = new SqlParameter("X_HopSo", Inserted.HopSo);
            obj[10] = new SqlParameter("X_KIEUDANDONG_ID", Inserted.KIEUDANDONG_ID);
            obj[11] = new SqlParameter("X_NHIENLIEU_ID", Inserted.NHIENLIEU_ID);
            obj[12] = new SqlParameter("X_THANHPHO_ID", Inserted.THANHPHO_ID);
            obj[13] = new SqlParameter("X_Ten", Inserted.Ten);
            obj[14] = new SqlParameter("X_RowId", Inserted.RowId);
            obj[15] = new SqlParameter("X_RaoBan", Inserted.RaoBan);
            obj[16] = new SqlParameter("X_Gia", Inserted.Gia);
            obj[17] = new SqlParameter("X_DaBan", Inserted.DaBan);
            obj[18] = new SqlParameter("X_Chu", Inserted.Chu);
            obj[19] = new SqlParameter("X_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("X_NguoiCapNhat", Inserted.NguoiCapNhat);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("X_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[21] = new SqlParameter("X_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("X_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[22] = new SqlParameter("X_NgayCapNhat", DBNull.Value);
            }
            obj[23] = new SqlParameter("X_Khoa", Inserted.Khoa);
            obj[24] = new SqlParameter("X_Xoa", Inserted.Xoa);
            obj[25] = new SqlParameter("X_DangLai", Inserted.DangLai);
            obj[26] = new SqlParameter("X_TotalComment", Inserted.TotalComment);
            obj[27] = new SqlParameter("X_TotalLike", Inserted.TotalLike);
            obj[28] = new SqlParameter("X_TotalBlog", Inserted.TotalBlog);
            obj[29] = new SqlParameter("X_TotalView", Inserted.TotalView);

            obj[30] = new SqlParameter("X_Anh", Inserted.Anh);
            if (Inserted.NgayDuyet > DateTime.MinValue)
            {
                obj[31] = new SqlParameter("X_NgayDuyet", Inserted.NgayDuyet);
            }
            else
            {
                obj[31] = new SqlParameter("X_NgayDuyet", DBNull.Value);
            }
            obj[32] = new SqlParameter("X_Duyet", Inserted.Duyet);
            obj[33] = new SqlParameter("X_NguoiDuyet", Inserted.NguoiDuyet);
            obj[34] = new SqlParameter("X_GioiThieu", Inserted.GioiThieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            CacheHelper.Max(string.Format(CacheItemKey, item.Id), item);
            return item;
        }

        public static Xe Update(Xe Updated)
        {
            Xe item = new Xe();
            var obj = new SqlParameter[36];
            obj[0] = new SqlParameter("X_ID", Updated.Id);
            obj[1] = new SqlParameter("X_HANG_ID", Updated.HANG_ID);
            obj[2] = new SqlParameter("X_MODEL_ID", Updated.MODEL_ID);
            obj[3] = new SqlParameter("X_SubModel", Updated.SubModel);
            obj[4] = new SqlParameter("X_XuatXu", Updated.XuatXu);
            obj[5] = new SqlParameter("X_Nam", Updated.Nam);
            obj[6] = new SqlParameter("X_TinhTrang", Updated.TinhTrang);
            obj[7] = new SqlParameter("X_DONGXE_ID", Updated.DONGXE_ID);
            obj[8] = new SqlParameter("X_MAUNGOAITHAT_ID", Updated.MAUNGOAITHAT_ID);
            obj[9] = new SqlParameter("X_MAUNOITHAT_ID", Updated.MAUNOITHAT_ID);
            obj[10] = new SqlParameter("X_HopSo", Updated.HopSo);
            obj[11] = new SqlParameter("X_KIEUDANDONG_ID", Updated.KIEUDANDONG_ID);
            obj[12] = new SqlParameter("X_NHIENLIEU_ID", Updated.NHIENLIEU_ID);
            obj[13] = new SqlParameter("X_THANHPHO_ID", Updated.THANHPHO_ID);
            obj[14] = new SqlParameter("X_Ten", Updated.Ten);
            obj[15] = new SqlParameter("X_RowId", Updated.RowId);
            obj[16] = new SqlParameter("X_RaoBan", Updated.RaoBan);
            obj[17] = new SqlParameter("X_Gia", Updated.Gia);
            obj[18] = new SqlParameter("X_DaBan", Updated.DaBan);
            obj[19] = new SqlParameter("X_Chu", Updated.Chu);
            obj[20] = new SqlParameter("X_NguoiTao", Updated.NguoiTao);
            obj[21] = new SqlParameter("X_NguoiCapNhat", Updated.NguoiCapNhat);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("X_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[22] = new SqlParameter("X_NgayTao", DBNull.Value);
            }
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("X_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[23] = new SqlParameter("X_NgayCapNhat", DBNull.Value);
            }

            obj[24] = new SqlParameter("X_Khoa", Updated.Khoa);
            obj[25] = new SqlParameter("X_Xoa", Updated.Xoa);
            obj[26] = new SqlParameter("X_DangLai", Updated.DangLai);
            obj[27] = new SqlParameter("X_TotalComment", Updated.TotalComment);
            obj[28] = new SqlParameter("X_TotalLike", Updated.TotalLike);
            obj[29] = new SqlParameter("X_TotalBlog", Updated.TotalBlog);
            obj[30] = new SqlParameter("X_TotalView", Updated.TotalView);

            if (Updated.NgayDuyet > DateTime.MinValue)
            {
                obj[31] = new SqlParameter("X_NgayDuyet", Updated.NgayDuyet);
            }
            else
            {
                obj[31] = new SqlParameter("X_NgayDuyet", DBNull.Value);
            }
            obj[32] = new SqlParameter("X_Duyet", Updated.Duyet);
            obj[33] = new SqlParameter("X_NguoiDuyet", Updated.NguoiDuyet);
            obj[34] = new SqlParameter("X_Anh", Updated.Anh);
            obj[35] = new SqlParameter("X_GioiThieu", Updated.GioiThieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            CacheHelper.Remove(string.Format(CacheItemKey, item.Id));
            CacheHelper.Max(string.Format(CacheItemKey, item.Id), item);
            return item;
        }
        public static Xe SelectById(Int64 X_ID)
        {
            return SelectById(DAL.con(), X_ID);
        }
        public static Xe SelectById(SqlConnection con, Int64 X_ID)
        {
            var item = new Xe();
            var cache = CacheHelper.Get(string.Format(CacheItemKey, item.Id));
            if(cache == null)
            {
                var obj = new SqlParameter[1];
                obj[0] = new SqlParameter("X_ID", X_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                CacheHelper.Max(string.Format(CacheItemKey, item.Id), item);
            }
            else
            {
                item = (Xe) cache;
            }
            return item;
        }
        public static Xe SelectByIdUsername(SqlConnection con, Int64 X_ID, string username)
        {
            var item = new Xe();
            var key = string.Format(CacheItemKey, X_ID);
            var keyUser = string.Format(CacheItemKey, string.Format("{0}-User:{1}", X_ID, username));
            var cache = CacheHelper.Get(keyUser);
            if (cache == null)
            {
                var obj = new SqlParameter[2];
                obj[0] = new SqlParameter("X_ID", X_ID);
                if (!string.IsNullOrEmpty(username))
                {
                    obj[1] = new SqlParameter("username", username);
                }
                else
                {
                    obj[1] = new SqlParameter("username", DBNull.Value);
                }
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectByIdUsername_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                var dep = new CacheDependency(null, new string[] {key});
                CacheHelper.Max(keyUser, item, dep);
                return item;
            }
            return (Xe) cache;
        }
        public static XeCollection SelectAll()
        {
            var List = new XeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Xe> PagerNormal(SqlConnection con, string url, bool rewrite, string sort
            , int size
            , string q, string Duyet, string HANG_ID, string TuNgay, string DenNgay
            , string Id, string username)
        {
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[2] = new SqlParameter("q", q);
            }
            else
            {
                obj[2] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Duyet))
            {
                obj[3] = new SqlParameter("Duyet", Duyet);
            }
            else
            {
                obj[3] = new SqlParameter("Duyet", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(HANG_ID))
            {
                obj[4] = new SqlParameter("HANG_ID", HANG_ID);
            }
            else
            {
                obj[4] = new SqlParameter("HANG_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[5] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[6] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[6] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Id))
            {
                obj[7] = new SqlParameter("Id", Id);
            }
            else
            {
                obj[7] = new SqlParameter("Id", DBNull.Value);
            }
            var pg = new Pager<Xe>(con, "sp_tblXe_Pager_Normal_linhnx", "p", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Xe getFromReader(IDataReader rd)
        {
            var Item = new Xe();
            if (rd.FieldExists("X_ID"))
            {
                Item.Id = (Int64)(rd["X_ID"]);
            }
            if (rd.FieldExists("X_HANG_ID"))
            {
                Item.HANG_ID = (Guid)(rd["X_HANG_ID"]);
            }
            if (rd.FieldExists("X_MODEL_ID"))
            {
                Item.MODEL_ID = (Guid)(rd["X_MODEL_ID"]);
            }
            if (rd.FieldExists("X_SubModel"))
            {
                Item.SubModel = (String)(rd["X_SubModel"]);
            }
            if (rd.FieldExists("X_XuatXu"))
            {
                Item.XuatXu = (Boolean)(rd["X_XuatXu"]);
            }
            if (rd.FieldExists("X_Nam"))
            {
                Item.Nam = (Int32)(rd["X_Nam"]);
            }
            if (rd.FieldExists("X_TinhTrang"))
            {
                Item.TinhTrang = (Boolean)(rd["X_TinhTrang"]);
            }
            if (rd.FieldExists("X_DONGXE_ID"))
            {
                Item.DONGXE_ID = (Guid)(rd["X_DONGXE_ID"]);
            }
            if (rd.FieldExists("X_MAUNGOAITHAT_ID"))
            {
                Item.MAUNGOAITHAT_ID = (Guid)(rd["X_MAUNGOAITHAT_ID"]);
            }
            if (rd.FieldExists("X_MAUNOITHAT_ID"))
            {
                Item.MAUNOITHAT_ID = (Guid)(rd["X_MAUNOITHAT_ID"]);
            }
            if (rd.FieldExists("X_HopSo"))
            {
                Item.HopSo = (Boolean)(rd["X_HopSo"]);
            }
            if (rd.FieldExists("X_KIEUDANDONG_ID"))
            {
                Item.KIEUDANDONG_ID = (Guid)(rd["X_KIEUDANDONG_ID"]);
            }
            if (rd.FieldExists("X_NHIENLIEU_ID"))
            {
                Item.NHIENLIEU_ID = (Guid)(rd["X_NHIENLIEU_ID"]);
            }
            if (rd.FieldExists("X_THANHPHO_ID"))
            {
                Item.THANHPHO_ID = (Guid)(rd["X_THANHPHO_ID"]);
            }
            if (rd.FieldExists("X_Ten"))
            {
                Item.Ten = (String)(rd["X_Ten"]);
            }
            if (rd.FieldExists("X_RowId"))
            {
                Item.RowId = (Guid)(rd["X_RowId"]);
            }
            if (rd.FieldExists("X_RaoBan"))
            {
                Item.RaoBan = (Boolean)(rd["X_RaoBan"]);
            }
            if (rd.FieldExists("X_Gia"))
            {
                Item.Gia = (Int64)(rd["X_Gia"]);
            }
            if (rd.FieldExists("X_DaBan"))
            {
                Item.DaBan = (Boolean)(rd["X_DaBan"]);
            }
            if (rd.FieldExists("X_Chu"))
            {
                Item.Chu = (String)(rd["X_Chu"]);
            }
            if (rd.FieldExists("X_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["X_NguoiTao"]);
            }
            if (rd.FieldExists("X_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["X_NguoiCapNhat"]);
            }
            if (rd.FieldExists("X_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["X_NgayTao"]);
            }
            if (rd.FieldExists("X_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["X_NgayCapNhat"]);
            }
            if (rd.FieldExists("X_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["X_Khoa"]);
            }
            if (rd.FieldExists("X_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["X_Xoa"]);
            }
            if (rd.FieldExists("X_DangLai"))
            {
                Item.DangLai = (Boolean)(rd["X_DangLai"]);
            }
            if (rd.FieldExists("X_TotalComment"))
            {
                Item.TotalComment = (Int32)(rd["X_TotalComment"]);
            }
            if (rd.FieldExists("X_TotalLike"))
            {
                Item.TotalLike = (Int32)(rd["X_TotalLike"]);
            }
            if (rd.FieldExists("X_TotalBlog"))
            {
                Item.TotalBlog = (Int32)(rd["X_TotalBlog"]);
            }
            if (rd.FieldExists("X_TotalView"))
            {
                Item.TotalView = (Int32)(rd["X_TotalView"]);
            }
            if (rd.FieldExists("X_NgayDuyet"))
            {
                Item.NgayDuyet = (DateTime)(rd["X_NgayDuyet"]);
            }
            if (rd.FieldExists("X_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["X_Duyet"]);
            }
            if (rd.FieldExists("X_NguoiDuyet"))
            {
                Item.NguoiDuyet = (String)(rd["X_NguoiDuyet"]);
            }
            if (rd.FieldExists("X_Anh"))
            {
                Item.Anh = (String)(rd["X_Anh"]);
            }

            if (rd.FieldExists("HANG_Ten"))
            {
                Item.HANG_Ten = (String)(rd["HANG_Ten"]);
            }
            if (rd.FieldExists("MODEL_Ten"))
            {
                Item.MODEL_Ten = (String)(rd["MODEL_Ten"]);
            }
            if (rd.FieldExists("THANHPHO_Ten"))
            {
                Item.THANHPHO_Ten = (String)(rd["THANHPHO_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("X_GioiThieu"))
            {
                Item.GioiThieu = (String)(rd["X_GioiThieu"]);
            }
            if (rd.FieldExists("X_Liked"))
            {
                Item.Liked = (Boolean)(rd["X_Liked"]);
            }
            var mem = new Member();
            if (rd.FieldExists("MEM_Vcard"))
            {
                mem.Vcard = (String)(rd["MEM_Vcard"]);
            }
            if (rd.FieldExists("MEM_Ten"))
            {
                mem.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("MEM_Anh"))
            {
                mem.Anh = (String)(rd["MEM_Anh"]);
            }
            Item.Member = mem;
            return Item;
        }
        #endregion
        #region Extend
        public static Xe SelectByRowIdUsername(SqlConnection con, Guid rowId, string username)
        {
            var Item = new Xe();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("X_RowID", rowId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectByRowId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Xe SelectByRowId(string RowId)
        {
            var item = new Xe();
            var keyRowId = string.Format(CacheItemKey, RowId);
            var cache = CacheHelper.Get(keyRowId);
            if (cache == null)
            {
                var obj = new SqlParameter[2];
                obj[0] = new SqlParameter("X_RowID", RowId);
                obj[1] = new SqlParameter("username", DBNull.Value);
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXe_Select_SelectByRowId_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                var key = string.Format(CacheItemKey, item.Id);
                var dep = new CacheDependency(null, new string[] { key });
                CacheHelper.Max(keyRowId, item, dep);
                return item;
            }
            return (Xe) cache;
        }
        public static Xe SelectByRowId(Guid RowId)
        {
            return SelectByRowId(RowId.ToString());
        }

        public static List<Xe> SelectDuyetByNguoiTao(SqlConnection con, string NguoiTao, int Top, bool? Duyet )
        {
            var list = new XeCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("NguoiTao", NguoiTao);
            obj[1] = new SqlParameter("Top", Top);
            if (Duyet.HasValue)
            {
                obj[2] = new SqlParameter("X_Duyet", Duyet);
            }
            else
            {
                obj[2] = new SqlParameter("X_Duyet", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectDuyetByNguoiTao_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static Pager<Xe> PagerXeYeuThichByUsername(SqlConnection con, string url, bool rewrite, string sort, string username)
        {
            return PagerXeYeuThichByUsername(con, url, false, sort, username, null);
        }
        public static Pager<Xe> PagerXeYeuThichByUsername(SqlConnection con, string url, bool rewrite, string sort, string username, string refUser)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            if (!string.IsNullOrEmpty(refUser))
            {
                obj[2] = new SqlParameter("refUser", refUser);

            }
            else
            {

                obj[2] = new SqlParameter("refUser", DBNull.Value);
            }
            var pg = new Pager<Xe>(con, "sp_tblXe_Pager_pagerXeYeuThichByUsername_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }


        public static List<Xe> SelectPromoted(SqlConnection con, int Top, string username, string loai)
        {
            var list = new XeCollection();
            var obj = new SqlParameter[4];
            obj[1] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(loai))
            {
                obj[3] = new SqlParameter("loai", loai);
            }
            else
            {
                obj[3] = new SqlParameter("loai", DBNull.Value);
            }
            using (var rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectPromoted_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static IList<Xe> SelectTopCar(SqlConnection con, int top, string username)
        {
            var list = new XeCollection();
            var obj = new SqlParameter[3];
            obj[1] = new SqlParameter("Top", top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", DBNull.Value);
            }
            using (var rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectTopCar_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static IList<Xe> SelectNewestCar(SqlConnection con, int top, string username)
        {
            var list = new XeCollection();
            var obj = new SqlParameter[3];
            obj[1] = new SqlParameter("Top", top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", DBNull.Value);
            }
            using (var rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXe_Select_SelectNewestCar_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static Pager<Xe> PagerByHang(SqlConnection con, string url, bool rewrite, string sort
            , int size
            , string q, string hang, string model, string username)
        {
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[2] = new SqlParameter("q", q);
            }
            else
            {
                obj[2] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(hang))
            {
                obj[3] = new SqlParameter("hang", hang);
            }
            else
            {
                obj[3] = new SqlParameter("hang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(model))
            {
                obj[4] = new SqlParameter("model", model);
            }
            else
            {
                obj[4] = new SqlParameter("model", DBNull.Value);
            }
            var pg = new Pager<Xe>(con, "sp_tblXe_Pager_ByHangTen_linhnx", "p", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Cache
        public const string CacheKey = "Xe:{0}";
        public const string CacheItemKey = "Xe:Item:{0}";
        public const string CacheListKey = "Xe:List:{0}";

        // TODO: Transform to Redis
        public static IList<Xe> PromotedTop
        {
            get
            {
                var key = string.Format(CacheListKey, "PromotedTop");
                var obj = CacheHelper.Get(key);
                if(obj == null)
                {
                    var list = SelectPromoted(DAL.con(), 20, null, "1");
                    var listKey = new List<string>();
                    list.ForEach(x =>
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                        listKey.Add(string.Format(CacheItemKey, x.Id));
                    });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>) obj;
            }
        }
        public static IList<Xe> PromotedHomeBig
        {
            get
            {
                var key = string.Format(CacheListKey, "KeyPromotedHomeBig");
                var obj = CacheManager.Cache[key];
                if (obj == null)
                {
                    var list = SelectPromoted(DAL.con(), 20, null, "2");
                    var listKey = new List<string>();
                    list.ForEach( x =>
                                      {
                                          CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                                          listKey.Add(string.Format(CacheItemKey, x.Id));
                                      });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>)obj;
            }
        }
        public static IList<Xe> PromotedHomeMedium
        {
            get
            {
                var key = string.Format(CacheListKey, "PromotedHomeMedium");
                var obj = CacheHelper.Get(key);
                if (obj == null)
                {
                    var list = SelectPromoted(DAL.con(), 20, null, "3");
                    var listKey = new List<string>();
                    list.ForEach(x =>
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                        listKey.Add(string.Format(CacheItemKey, x.Id));
                    });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>)obj;
            }
        }
        public static IList<Xe> PromotedHomeSmall
        {
            get
            {
                var key = string.Format(CacheListKey, "PromotedHomeSmall");
                var obj = CacheHelper.Get(key);
                if (obj == null)
                {
                    var list = SelectPromoted(DAL.con(), 20, null, "4");
                    var listKey = new List<string>();
                    list.ForEach(x =>
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                        listKey.Add(string.Format(CacheItemKey, x.Id));
                    });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>)obj;
            }
        }
        public static IList<Xe> HomeTop
        {
            get
            {
                var key = string.Format(CacheListKey, "HomeTop");
                var obj = CacheHelper.Get(key);
                if (obj == null)
                {
                    var list = SelectTopCar(DAL.con(), 20, null);
                    var listKey = new List<string>();
                    list.ForEach(x =>
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                        listKey.Add(string.Format(CacheItemKey, x.Id));
                    });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>)obj;
            }
        }
        public static IList<Xe> HomeNewest
        {
            get
            {
                var key = string.Format(CacheListKey, "HomeNewest");
                var obj = CacheHelper.Get(key);
                if (obj == null)
                {
                    var list = SelectTopCar(DAL.con(), 20, null);
                    var listKey = new List<string>();
                    list.ForEach(x =>
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), x);
                        listKey.Add(string.Format(CacheItemKey, x.Id));
                    });
                    var dep = new CacheDependency(null, listKey.ToArray());
                    CacheHelper.Max(key, list, dep);
                    return list;
                }
                return (List<Xe>)obj;
            }
        }
        #endregion

       
    }
    #endregion
    #region Redis
    public class XeRedis
    {
        const string ItemKey = "urn:xe:{0}";
        const string ListKey = "urn:xe:list:{0}";
        private readonly IRedisClient _redisClient;
        public XeRedis(IRedisClient client)
        {
            _redisClient = client;
        }
        public Xe GetById(long id)
        {
            var key = string.Format(ItemKey, id);
            var item = _redisClient.Get<Xe>(key);
            if (item == null)
            {
                item = XeDal.SelectById(id);
                _redisClient.Set(key, item);
            }
            return item;
        }
        public Xe GetByRowId(Guid rowid)
        {
            var idKey = string.Format(ItemKey, rowid);
            var id = _redisClient.Get<long>(idKey);
            if (id == 0) return null;
            var item = GetById(id);
            return item;
        }
        public void Save(Xe item)
        {
            var key = string.Format(ItemKey, item.Id);
            _redisClient.Set(key, item);
        }
        public IRedisList GetAll()
        {
            var key = string.Format(ListKey, "all");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public List<Xe> GetAllItems(int start, int stop)
        {
            var ids = GetAll().GetRange(start, stop).ToList();
            return ids.Select(id => GetById(Convert.ToInt64(id))).ToList();
        }
        public IRedisList GetTop()
        {
            var key = string.Format(ListKey, "top");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public List<Xe> GetTopItems(int start, int stop)
        {
            var ids = GetTop().GetRange(start, stop).ToList();
            return ids.Select(id => GetById(Convert.ToInt64(id))).ToList();
        }
    }
    #endregion
    #endregion
    
}


