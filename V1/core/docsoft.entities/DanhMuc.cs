using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;

namespace docsoft.entities
{

    #region DanhMuc
    #region BO
    public class DanhMuc : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid GH_ID { get; set; }
        public Guid PID { get; set; }
        public Guid LDM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Guid LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String KyHieu { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String Ma { get; set; }
        public String GiaTri { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiSua { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String KeyWords { get; set; }
        public String Description { get; set; }
        public Guid RowId { get; set; }
        public Boolean Deleted { get; set; }
        #endregion
        #region Contructor
        public DanhMuc()
        { }
        #endregion
        #region Customs properties
        public String LDM_Ten { get; set; }
        public Int32 Level { get; set; }
        public string PID_Ten { get; set; }
        public List<Tin> Tins { get; set; }
        public DanhMuc Hang { get; set; }
        public string Id { get { return ID.ToString(); } 
        }
        public LoaiDanhMuc LoaiDanhMuc { get; set; }
        #endregion
       

        public const string ListKey = "urn:danhmuc:list";
        public const string Key = "urn:danhmuc:{0}";

        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMucCollection : BaseEntityCollection<DanhMuc>
    { }
    #endregion
    #region Dal
    public class DanhMucDal
    {
        #region Methods

        public static void DeleteById(Guid DM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Delete_DeleteById_linhnx", obj);
            CacheManager.Clear(CacheManager.Loai.Cache, DanhMuc.ListKey);
        }
        public static DanhMuc Insert(DanhMuc item)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("DM_ID", item.ID);
            obj[1] = new SqlParameter("DM_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("DM_PID", item.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", item.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", item.Lang);
            obj[5] = new SqlParameter("DM_LangBased", item.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", item.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", item.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", item.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", item.Ten);
            obj[10] = new SqlParameter("DM_Anh", item.Anh);
            obj[11] = new SqlParameter("DM_Ma", item.Ma);
            obj[12] = new SqlParameter("DM_GiaTri", item.GiaTri);
            obj[13] = new SqlParameter("DM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("DM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[15] = new SqlParameter("DM_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("DM_NguoiSua", item.NguoiSua);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("DM_KeyWords", item.KeyWords);
            obj[19] = new SqlParameter("DM_Description", item.Description);
            obj[20] = new SqlParameter("DM_RowId", item.RowId);
            obj[21] = new SqlParameter("DM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            CacheManager.Clear(CacheManager.Loai.Cache, DanhMuc.ListKey);
            return Item;
        }
        public static DanhMuc Update(DanhMuc item)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("DM_ID", item.ID);
            obj[1] = new SqlParameter("DM_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("DM_PID", item.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", item.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", item.Lang);
            obj[5] = new SqlParameter("DM_LangBased", item.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", item.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", item.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", item.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", item.Ten);
            obj[10] = new SqlParameter("DM_Anh", item.Anh);
            obj[11] = new SqlParameter("DM_Ma", item.Ma);
            obj[12] = new SqlParameter("DM_GiaTri", item.GiaTri);
            obj[13] = new SqlParameter("DM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("DM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[15] = new SqlParameter("DM_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("DM_NguoiSua", item.NguoiSua);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("DM_KeyWords", item.KeyWords);
            obj[19] = new SqlParameter("DM_Description", item.Description);
            obj[20] = new SqlParameter("DM_RowId", item.RowId);
            obj[21] = new SqlParameter("DM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            CacheManager.Clear(CacheManager.Loai.Cache, DanhMuc.ListKey);
            return Item;
        }

        public static DanhMuc SelectById(Guid DM_ID)
        {
            var item = new DanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }
        public static DanhMuc Select(Guid dmId)
        {
            using (var client = new RedisClient(CacheManager.RedisAddress))
            {
                return List.ToList().FirstOrDefault(x => x.ID == dmId);
            }
        }
        public static DanhMucCollection SelectAll()
        {
            var list = new DanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static Pager<DanhMuc> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DanhMuc>("sp_tblDanhMuc_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DanhMuc getFromReader(IDataReader rd)
        {
            var item = new DanhMuc();
            if (rd.FieldExists("DM_ID"))
            {
                item.ID = (Guid)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_GH_ID"))
            {
                item.GH_ID = (Guid)(rd["DM_GH_ID"]);
            }
            if (rd.FieldExists("DM_PID"))
            {
                item.PID = (Guid)(rd["DM_PID"]);
            }
            if (rd.FieldExists("DM_LDM_ID"))
            {
                item.LDM_ID = (Guid)(rd["DM_LDM_ID"]);
            }
            if (rd.FieldExists("DM_Lang"))
            {
                item.Lang = (String)(rd["DM_Lang"]);
            }
            if (rd.FieldExists("DM_LangBased"))
            {
                item.LangBased = (Boolean)(rd["DM_LangBased"]);
            }
            if (rd.FieldExists("DM_LangBased_ID"))
            {
                item.LangBased_ID = (Guid)(rd["DM_LangBased_ID"]);
            }
            if (rd.FieldExists("DM_Alias"))
            {
                item.Alias = (String)(rd["DM_Alias"]);
            }
            if (rd.FieldExists("DM_KyHieu"))
            {
                item.KyHieu = (String)(rd["DM_KyHieu"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Anh"))
            {
                item.Anh = (String)(rd["DM_Anh"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                item.Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("DM_GiaTri"))
            {
                item.GiaTri = (String)(rd["DM_GiaTri"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_NgayTao"))
            {
                item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            }
            if (rd.FieldExists("DM_NguoiTao"))
            {
                item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            }
            if (rd.FieldExists("DM_NguoiSua"))
            {
                item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            }
            if (rd.FieldExists("DM_NgayCapNhat"))
            {
                item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            }
            if (rd.FieldExists("DM_KeyWords"))
            {
                item.KeyWords = (String)(rd["DM_KeyWords"]);
            }
            if (rd.FieldExists("DM_Description"))
            {
                item.Description = (String)(rd["DM_Description"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                item.RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("DM_Deleted"))
            {
                item.Deleted = (Boolean)(rd["DM_Deleted"]);
            }

            if (rd.FieldExists("LDM_Ten"))
            {
                item.LDM_Ten = (String)(rd["LDM_Ten"]);
            }
            if (rd.FieldExists("DM_Level"))
            {
                item.Level = (Int32)(rd["DM_Level"]);
            }
            if (rd.FieldExists("PID_Ten"))
            {
                item.PID_Ten = (String)(rd["PID_Ten"]);
            }
            var loaiDanhMuc = LoaiDanhMucDal.SelectById(item.LDM_ID);
            item.LoaiDanhMuc = loaiDanhMuc;
            //using (var client = new RedisClient(CacheManager.RedisAddress))
            //{
            //    var redis = client.As<DanhMuc>();
            //    redis.StoreRelatedEntities(item.LDM_ID, loaiDanhMuc);
            //}
            return item;
        }
        #endregion

        #region Extend
        public static DanhMuc SelectById(SqlConnection con, Guid DM_ID)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static List<DanhMuc> SelectByLDMID(string LDM_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDMID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static List<DanhMuc> SelectByLDMID(SqlConnection con, string LDM_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDMID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static List<DanhMuc> SelectByLDMMa(string LDM_Ma)
        {
            return SelectByLDMMa(DAL.con(), LDM_Ma);
        }
        public static List<DanhMuc> SelectByLDMMa(SqlConnection con, string LDM_Ma)
        {
            var loaiDanhMuc = LoaiDanhMucDal.List.FirstOrDefault(x => x.Ma == LDM_Ma);
            return loaiDanhMuc == null ? new List<DanhMuc>() : List.Where(x => x.LDM_ID == loaiDanhMuc.Id).ToList();
        }
        public static List<DanhMuc> SelectByLdmMaFromCache(string ldmMa)
        {
            return SelectByLdmMaFromCache(DAL.con(),ldmMa);
        }
        public static List<DanhMuc> SelectByLdmMaFromCache(SqlConnection con, string ldmMa)
        {
            return SelectByLDMMa(con, ldmMa);
        }
        public static DanhMuc SelectByMa(string DM_Ma, SqlConnection con)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectByMa(string DM_Ma)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectByTen(string ten)
        {
            return SelectByTen(DAL.con(), ten);
        }
        public static DanhMuc SelectByTen(SqlConnection con, string ten)
        {
            var item = new DanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Ten", ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByTen_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }
        public static List<DanhMuc> SelectParentByDmId(string DM_ID)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectParentByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static List<DanhMuc> SelectParentByDmId(SqlConnection con, string DM_ID)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectParentByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static List<DanhMuc> SelectTreeByDmMa(SqlConnection con, string Ma)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(Ma))
            {
                obj[0] = new SqlParameter("Ma", Ma);
            }
            else
            {
                obj[0] = new SqlParameter("Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_SelectTreeByDmMa", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        /// <summary>
        /// Dành cho tư vấn
        /// </summary>
        /// <param name="TV_ID"></param>
        /// <returns></returns>
        public static List<DanhMuc> SelectByTvId(string TV_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(TV_ID))
            {
                obj[0] = new SqlParameter("TV_ID", TV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("TV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByTvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static List<DanhMuc> SelectByPid(string PID)
        {
            return SelectByPid(DAL.con(),PID);
        }
        public static List<DanhMuc> SelectByPid(SqlConnection con, string PID)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(PID))
            {
                obj[0] = new SqlParameter("PID", PID);
            }
            else
            {
                obj[0] = new SqlParameter("PID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion

        #region Cache
        public static IList<DanhMuc> List
        {
            get
            {
                var obj = CacheManager.Cache[DanhMuc.ListKey];
                if (obj == null)
                {
                    var list = SelectAll();
                    CacheManager.Cache.Insert(DanhMuc.ListKey, list);
                    return list;
                }
                return (List<DanhMuc>)obj;
            }
        }
        #endregion
    }
    #endregion
    #region DanhMucRedis
    public class DanhMucRedis
    {
        const string ItemKey = "urn:danhmuc:{0}";
        const string ListKey = "urn:danhmuc:list:{0}";
        private readonly IRedisClient _redisClient;
        public DanhMucRedis(IRedisClient client)
        {
            _redisClient = client;
        }
        public DanhMuc GetById(Guid id)
        {
            var key = string.Format(ItemKey, id);
            var item = _redisClient.Get<DanhMuc>(key);
            if (item == null)
            {
                item = DanhMucDal.SelectById(id);
                _redisClient.Set(key, item);
            }
            return item;
        }

        public void Remove(Guid id)
        {
            var item = GetById(id);
            var loaiDanhMucRedis = new LoaiDanhMucRedis(_redisClient);
            var loaiDanhMuc = loaiDanhMucRedis.GetById(item.LDM_ID);
            loaiDanhMuc.DanhMucIds.Remove(item.ID);
            loaiDanhMucRedis.Save(loaiDanhMuc);
            _redisClient.Remove(string.Format(ItemKey, id));
            _redisClient.Lists[string.Format(ListKey, "all")].Remove(id.ToString());
        }
        public IRedisList GetAll()
        {
            var key = string.Format(ListKey, "all");
            var ids = _redisClient.Lists[key];
            return ids;
        }
       
    }
    #endregion
    #endregion
}


