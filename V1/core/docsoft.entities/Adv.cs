using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region Adv
    #region BO
    public class Adv : BaseEntity
    {
        #region Properties
        public Guid Id { get; set; }
        public Int32 Loai { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Boolean Duyet { get; set; }
        public String Url { get; set; }
        public Int32 Views { get; set; }
        public Int32 Clicks { get; set; }
        public String Keywords { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayDuyet { get; set; }
        public String NguoiDuyet { get; set; }
        public Int32 ThuTu { get; set; }
        public Guid RowId { get; set; }
        public String AdsKey { get; set; }
        public Boolean Flash { get; set; }
        #endregion
        #region Contructor
        public Adv()
        { }
        #endregion
        #region Customs properties
        public string LoaiTen
        {
            get
            {
                switch (Loai)
                {
                    case 1010: return "Home-Top-1000";
                    case 1020: return "Home-Bot-1000";
                    case 1030: return "Home-300";
                    case 1110: return "Xe-300";
                    case 1210: return "Profile-300";
                    case 1410: return "Community-300";
                }
                return string.Empty;
            }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AdvDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AdvCollection : BaseEntityCollection<Adv>
    { }
    #endregion
    #region Dal
    public class AdvDal
    {
        #region Methods

        public static void DeleteById(Guid A_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAdv_Delete_DeleteById_linhnx", obj);
            CacheHelper.Remove(string.Format(CacheItemKey, A_ID));
        }

        public static Adv Insert(Adv item)
        {
            var Item = new Adv();
            var obj = new SqlParameter[20];
            obj[0] = new SqlParameter("A_ID", item.Id);
            obj[1] = new SqlParameter("A_Loai", item.Loai);
            obj[2] = new SqlParameter("A_Ten", item.Ten);
            obj[3] = new SqlParameter("A_Ma", item.Ma);
            obj[4] = new SqlParameter("A_NoiDung", item.NoiDung);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("A_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[5] = new SqlParameter("A_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("A_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[6] = new SqlParameter("A_NgayKetThuc", DBNull.Value);
            }
            obj[7] = new SqlParameter("A_Duyet", item.Duyet);
            obj[8] = new SqlParameter("A_Url", item.Url);
            obj[9] = new SqlParameter("A_Views", item.Views);
            obj[10] = new SqlParameter("A_Clicks", item.Clicks);
            obj[11] = new SqlParameter("A_Keywords", item.Keywords);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("A_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("A_NguoiTao", item.NguoiTao);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("A_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[14] = new SqlParameter("A_NgayDuyet", DBNull.Value);
            }
            obj[15] = new SqlParameter("A_NguoiDuyet", item.NguoiDuyet);
            obj[16] = new SqlParameter("A_ThuTu", item.ThuTu);
            obj[17] = new SqlParameter("A_RowId", item.RowId);
            obj[18] = new SqlParameter("A_AdsKey", item.AdsKey);
            obj[19] = new SqlParameter("A_Flash", item.Flash);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAdv_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Adv Update(Adv item)
        {
            var Item = new Adv();
            CacheHelper.Remove(string.Format(CacheItemKey, Item.Id));
            var obj = new SqlParameter[20];
            obj[0] = new SqlParameter("A_ID", item.Id);
            obj[1] = new SqlParameter("A_Loai", item.Loai);
            obj[2] = new SqlParameter("A_Ten", item.Ten);
            obj[3] = new SqlParameter("A_Ma", item.Ma);
            obj[4] = new SqlParameter("A_NoiDung", item.NoiDung);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("A_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[5] = new SqlParameter("A_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("A_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[6] = new SqlParameter("A_NgayKetThuc", DBNull.Value);
            }
            obj[7] = new SqlParameter("A_Duyet", item.Duyet);
            obj[8] = new SqlParameter("A_Url", item.Url);
            obj[9] = new SqlParameter("A_Views", item.Views);
            obj[10] = new SqlParameter("A_Clicks", item.Clicks);
            obj[11] = new SqlParameter("A_Keywords", item.Keywords);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("A_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("A_NguoiTao", item.NguoiTao);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("A_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[14] = new SqlParameter("A_NgayDuyet", DBNull.Value);
            }
            obj[15] = new SqlParameter("A_NguoiDuyet", item.NguoiDuyet);
            obj[16] = new SqlParameter("A_ThuTu", item.ThuTu);
            obj[17] = new SqlParameter("A_RowId", item.RowId);
            obj[18] = new SqlParameter("A_AdsKey", item.AdsKey);
            obj[19] = new SqlParameter("A_Flash", item.Flash);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAdv_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Adv SelectById( Guid A_ID)
        {
            return SelectById(DAL.con(), A_ID);
        }
        public static Adv SelectById(SqlConnection con, Guid A_ID)
        {
            var key = string.Format(CacheListKey, A_ID);

            var objCache = CacheHelper.Get(key);
            if(objCache == null)
            {
                var Item = new Adv();
                var obj = new SqlParameter[1];
                obj[0] = new SqlParameter("A_ID", A_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAdv_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                CacheHelper.Max(key, Item);
                return Item;
            }
            return (Adv) objCache;
        }

        public static AdvCollection SelectAll()
        {
            var List = new AdvCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAdv_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Adv> pagerNormal(SqlConnection con, string url, bool rewrite, string sort
            , int size
            , string q, string Duyet, string Loai, string TuNgay, string DenNgay
            )
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
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[2] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[2] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Duyet))
            {
                obj[3] = new SqlParameter("Duyet", Duyet);
            }
            else
            {
                obj[3] = new SqlParameter("Duyet", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Loai))
            {
                obj[4] = new SqlParameter("Loai", Loai);
            }
            else
            {
                obj[4] = new SqlParameter("Loai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[5] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("TuNgay", DBNull.Value);
            }
            
            var pg = new Pager<Adv>("sp_tblAdv_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Adv getFromReader(IDataReader rd)
        {
            var Item = new Adv();
            if (rd.FieldExists("A_ID"))
            {
                Item.Id = (Guid)(rd["A_ID"]);
            }
            if (rd.FieldExists("A_Loai"))
            {
                Item.Loai = (Int32)(rd["A_Loai"]);
            }
            if (rd.FieldExists("A_Ten"))
            {
                Item.Ten = (String)(rd["A_Ten"]);
            }
            if (rd.FieldExists("A_Ma"))
            {
                Item.Ma = (String)(rd["A_Ma"]);
            }
            if (rd.FieldExists("A_NoiDung"))
            {
                Item.NoiDung = (String)(rd["A_NoiDung"]);
            }
            if (rd.FieldExists("A_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["A_NgayBatDau"]);
            }
            if (rd.FieldExists("A_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["A_NgayKetThuc"]);
            }
            if (rd.FieldExists("A_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["A_Duyet"]);
            }
            if (rd.FieldExists("A_Url"))
            {
                Item.Url = (String)(rd["A_Url"]);
            }
            if (rd.FieldExists("A_Views"))
            {
                Item.Views = (Int32)(rd["A_Views"]);
            }
            if (rd.FieldExists("A_Clicks"))
            {
                Item.Clicks = (Int32)(rd["A_Clicks"]);
            }
            if (rd.FieldExists("A_Keywords"))
            {
                Item.Keywords = (String)(rd["A_Keywords"]);
            }
            if (rd.FieldExists("A_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["A_NgayTao"]);
            }
            if (rd.FieldExists("A_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["A_NguoiTao"]);
            }
            if (rd.FieldExists("A_NgayDuyet"))
            {
                Item.NgayDuyet = (DateTime)(rd["A_NgayDuyet"]);
            }
            if (rd.FieldExists("A_NguoiDuyet"))
            {
                Item.NguoiDuyet = (String)(rd["A_NguoiDuyet"]);
            }
            if (rd.FieldExists("A_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["A_ThuTu"]);
            }
            if (rd.FieldExists("A_RowId"))
            {
                Item.RowId = (Guid)(rd["A_RowId"]);
            }
            if (rd.FieldExists("A_AdsKey"))
            {
                Item.AdsKey = (String)(rd["A_AdsKey"]);
            }
            if (rd.FieldExists("A_Flash"))
            {
                Item.Flash = (Boolean)(rd["A_Flash"]);
            }
            CacheHelper.Max(string.Format(CacheItemKey, Item.Id),Item);
            return Item;
        }
        #endregion

        #region Cache
        public const string CacheKey = "Adv:{0}";
        public const string CacheItemKey = "Adv:Item:{0}";
        public const string CacheListKey = "Adv:List:{0}";
        #endregion


        #region Extend
        public static List<Adv> SelectByLoai(SqlConnection con, string Loai, string Duyet)
        {
            var key = string.Format(CacheListKey, string.Format("SelectByLoai-{0}-{1}", Loai, Duyet));
            var objCache = CacheHelper.Get(key);
            if (objCache == null)
            {
                var list = new List<Adv>();
                var obj = new SqlParameter[2];
                if (!string.IsNullOrEmpty(Loai))
                {
                    obj[0] = new SqlParameter("Loai", Loai);
                }
                else
                {
                    obj[0] = new SqlParameter("Loai", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Duyet))
                {
                    obj[1] = new SqlParameter("Duyet", Duyet);
                }
                else
                {
                    obj[1] = new SqlParameter("Duyet", DBNull.Value);
                }

                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAdv_Select_SelectByLoai_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        list.Add(getFromReader(rd));
                    }
                }
                var listKey = new List<string>();
                list.ForEach(x =>
                {
                    listKey.Add(string.Format(CacheItemKey, x.Id));
                });
                var dep = new CacheDependency(null, listKey.ToArray());
                CacheHelper.Max(key, list, dep);
                return list;
            }
            return (List<Adv>)objCache;

        }

        #endregion
    }
    #endregion

    #endregion
}


