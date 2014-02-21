using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region Blog
    #region BO
    public class Blog : BaseEntity
    {
        #region Properties
        public Int64 Id { get; set; }
        public Int32 Loai { get; set; }
        public Guid PID_ID { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String NoiDung { get; set; }
        public String MoTa { get; set; }
        public String Tags { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Home { get; set; }
        public Int32 Views { get; set; }
        public Guid RowId { get; set; }
        public Int32 TotalLike { get; set; }
        public Int32 TotalComment { get; set; }
        public Boolean Liked { get; set; }
        #endregion
        #region Contructor
        public Blog()
        {
            NguoiThich=new List<string>();
            AnhList=new List<Guid>();
            BinhLuanIds=new List<long>();
        }
        #endregion
        #region Customs properties

        public Member MemberNguoiTao { get; set; }
        public Member Profile { get; set; }
        public Xe Xe { get; set; }
        public List<Anh> Anhs { get; set; }
        public Nhom Nhom { get; set; }
        public string AnhStr { get; set; }
        public List<string> NguoiThich { get; set; }
        public List<Member> GetNguoiThich()
        {
            return NguoiThich.Select(item => MemberDal.SelectByUsername(item)).ToList();
        }
        public bool IsLiked(string username)
        {
            return NguoiThich.Contains(username);
        }

        public List<long> BinhLuanIds { get; set; } 
        public List<BinhLuan>  GetBinhLuans()
        {
            return BinhLuanDal.PagerByPRowId(DAL.con(), null, false, RowId.ToString(), 20).List;
        }
        public List<Guid> AnhList { get; set; } 
        public string Url
        {
            get
            {
                switch (Loai)
                {
                    case 1: // Profile
                        if (Profile != null)
                        {
                            return string.Format("{0}/blogs/{1}/", Profile.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 2: // Xe
                        if (Xe != null)
                        {
                            return string.Format("{0}blogs/{1}/", Xe.XeUrl, Id);                            
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 3: // Community Blog
                        if (Nhom != null)
                        {
                            return string.Format("{0}blogs/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 4: // Community Topic
                        if (Nhom != null)
                        {
                            return string.Format("{0}forum/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 5: // Community QA
                        if (Nhom != null)
                        {
                            return string.Format("{0}qa/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                }
                return string.Empty;
            }
        }
        public string UrlEdit
        {
            get
            {
                switch (Loai)
                {
                    case 1: // Profile
                        if (Profile != null)
                        {
                            return string.Format("{0}/blogs/edit/{1}/", Profile.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/edit/{0}/", Id);
                        }
                        break;
                    case 2: // Xe
                        if (Xe != null)
                        {
                            return string.Format("{0}blogs/edit/{1}/", Xe.XeUrl, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/edit/{0}/", Id);
                        }
                        break;
                    case 3: // Community Blog
                        if (Nhom != null)
                        {
                            return string.Format("{0}blogs/edit/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 4: // Community Topic
                        if (Nhom != null)
                        {
                            return string.Format("{0}forum/edit/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                    case 5: // Community QA
                        if (Nhom != null)
                        {
                            return string.Format("{0}qa/edit/{1}/", Nhom.Url, Id);
                        }
                        else
                        {
                            return string.Format("/blogs/{0}/", Id);
                        }
                        break;
                }
                return string.Empty;
            }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BlogDal.getFromReader(rd);
        }
        public string LoaiTen
        {
            get
            {
                switch (Loai)
                {
                    case 1: return "Cá nhân";
                    case 2: return "Xe";
                    case 3:
                        return "Nhóm Blog";
                    case 4:
                        return "Nhóm diễn đàn";
                    case 5:
                        return "Nhóm QA";
                }
                return string.Empty;
            }
        }
    }
    #endregion
    #region Collection
    public class BlogCollection : BaseEntityCollection<Blog>
    { }
    #endregion
    #region Dal
    public class BlogDal
    {
        #region Methods

        public static void DeleteById(Int64 BLOG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BLOG_ID", BLOG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Delete_DeleteById_linhnx", obj);
            CacheHelper.Remove(string.Format(CacheItemKey, BLOG_ID));
        }
        public static Blog Insert(Blog Inserted)
        {
            Blog Item = new Blog();
            SqlParameter[] obj = new SqlParameter[18];
            obj[0] = new SqlParameter("BLOG_Loai", Inserted.Loai);
            obj[1] = new SqlParameter("BLOG_PID_ID", Inserted.PID_ID);
            obj[2] = new SqlParameter("BLOG_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("BLOG_Anh", Inserted.Anh);
            obj[4] = new SqlParameter("BLOG_NoiDung", Inserted.NoiDung);
            obj[5] = new SqlParameter("BLOG_MoTa", Inserted.MoTa);
            obj[6] = new SqlParameter("BLOG_Tags", Inserted.Tags);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("BLOG_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("BLOG_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("BLOG_NguoiTao", Inserted.NguoiTao);
            obj[9] = new SqlParameter("BLOG_Publish", Inserted.Publish);
            obj[10] = new SqlParameter("BLOG_Hot", Inserted.Hot);
            obj[11] = new SqlParameter("BLOG_Home", Inserted.Home);
            obj[12] = new SqlParameter("BLOG_Views", Inserted.Views);
            obj[13] = new SqlParameter("BLOG_RowId", Inserted.RowId);
            obj[14] = new SqlParameter("BLOG_TotalLike", Inserted.TotalLike);
            obj[15] = new SqlParameter("BLOG_TotalComment", Inserted.TotalComment);
            obj[16] = new SqlParameter("BLOG_Liked", Inserted.Liked);
            obj[17] = new SqlParameter("BLOG_AnhStr", Inserted.AnhStr);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            CacheHelper.Max(string.Format(CacheItemKey, Item.Id), Item);
            return Item;
        }

        public static Blog Update(Blog Updated)
        {
            Blog Item = new Blog();
            SqlParameter[] obj = new SqlParameter[19];
            obj[0] = new SqlParameter("BLOG_ID", Updated.Id);
            obj[1] = new SqlParameter("BLOG_Loai", Updated.Loai);
            obj[2] = new SqlParameter("BLOG_PID_ID", Updated.PID_ID);
            obj[3] = new SqlParameter("BLOG_Ten", Updated.Ten);
            obj[4] = new SqlParameter("BLOG_Anh", Updated.Anh);
            obj[5] = new SqlParameter("BLOG_NoiDung", Updated.NoiDung);
            obj[6] = new SqlParameter("BLOG_MoTa", Updated.MoTa);
            obj[7] = new SqlParameter("BLOG_Tags", Updated.Tags);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("BLOG_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("BLOG_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("BLOG_NguoiTao", Updated.NguoiTao);
            obj[10] = new SqlParameter("BLOG_Publish", Updated.Publish);
            obj[11] = new SqlParameter("BLOG_Hot", Updated.Hot);
            obj[12] = new SqlParameter("BLOG_Home", Updated.Home);
            obj[13] = new SqlParameter("BLOG_Views", Updated.Views);
            obj[14] = new SqlParameter("BLOG_RowId", Updated.RowId);
            obj[15] = new SqlParameter("BLOG_TotalLike", Updated.TotalLike);
            obj[16] = new SqlParameter("BLOG_TotalComment", Updated.TotalComment);
            obj[17] = new SqlParameter("BLOG_Liked", Updated.Liked);
            obj[18] = new SqlParameter("BLOG_AnhStr", Updated.AnhStr);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            CacheHelper.Remove(string.Format(CacheItemKey, Item.Id));
            CacheHelper.Max(string.Format(CacheItemKey, Item.Id), Item);
            return Item;

        }
        public static Blog SelectById(Int64 BLOG_ID)
        {
            return SelectById(DAL.con(), BLOG_ID);
        }

        public static Blog SelectById(SqlConnection con, Int64 BLOG_ID)
        {
            var key = string.Format(CacheItemKey, BLOG_ID);
            var cacheObj = CacheHelper.Get(key);
            if(cacheObj == null)
            {
                var item = new Blog();
                var obj = new SqlParameter[1];
                obj[0] = new SqlParameter("BLOG_ID", BLOG_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBlog_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                CacheHelper.Max(key,item);
                return item;    
            }
            return (Blog) cacheObj;
        }
        public static Blog SelectById(SqlConnection con, Int64 BLOG_ID, string username)
        {
            var key = string.Format(CacheItemUserKey, BLOG_ID, username);
            var cacheObj = CacheHelper.Get(key);
            if (cacheObj == null)
            {
                var item = new Blog();
                var obj = new SqlParameter[2];
                obj[0] = new SqlParameter("BLOG_ID", BLOG_ID);
                if (!string.IsNullOrEmpty(username))
                {
                    obj[1] = new SqlParameter("username", username);
                }
                else
                {
                    obj[1] = new SqlParameter("username", username);
                }
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBlog_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                var list = new List<string> {string.Format(CacheItemKey, item.Id)};
                var dep = new CacheDependency(null, list.ToArray());
                CacheHelper.Max(key, item, dep);
                return item;
            }
            return (Blog) cacheObj;
        }
        public static BlogCollection SelectAll()
        {
            BlogCollection List = new BlogCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Blog> PagerNormal(SqlConnection con, string url, bool rewrite, string sort
            , int size
            , string q, string Username, string Publish, string TuNgay, string DenNgay
            )
        {
            var obj = new SqlParameter[8];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[2] = new SqlParameter("q", q);
            }
            else
            {
                obj[2] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[4] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[4] = new SqlParameter("Publish", DBNull.Value);
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
            var pg = new Pager<Blog>(con, "sp_tblBlog_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Blog getFromReader(IDataReader rd)
        {
            Blog Item = new Blog();
            if (rd.FieldExists("BLOG_ID"))
            {
                Item.Id = (Int64)(rd["BLOG_ID"]);
            }
            if (rd.FieldExists("BLOG_Loai"))
            {
                Item.Loai = (Int32)(rd["BLOG_Loai"]);
            }
            if (rd.FieldExists("BLOG_PID_ID"))
            {
                Item.PID_ID = (Guid)(rd["BLOG_PID_ID"]);
            }
            if (rd.FieldExists("BLOG_Ten"))
            {
                Item.Ten = (String)(rd["BLOG_Ten"]);
            }
            if (rd.FieldExists("BLOG_Anh"))
            {
                Item.Anh = (String)(rd["BLOG_Anh"]);
            }
            if (rd.FieldExists("BLOG_NoiDung"))
            {
                Item.NoiDung = (String)(rd["BLOG_NoiDung"]);
            }
            if (rd.FieldExists("BLOG_MoTa"))
            {
                Item.MoTa = (String)(rd["BLOG_MoTa"]);
            }
            if (rd.FieldExists("BLOG_Tags"))
            {
                Item.Tags = (String)(rd["BLOG_Tags"]);
            }
            if (rd.FieldExists("BLOG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["BLOG_NgayTao"]);
            }
            if (rd.FieldExists("BLOG_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["BLOG_NguoiTao"]);
            }
            if (rd.FieldExists("BLOG_AnhStr"))
            {
                Item.AnhStr = (String)(rd["BLOG_AnhStr"]);
            }
            if (rd.FieldExists("BLOG_Publish"))
            {
                Item.Publish = (Boolean)(rd["BLOG_Publish"]);
            }
            if (rd.FieldExists("BLOG_Hot"))
            {
                Item.Hot = (Boolean)(rd["BLOG_Hot"]);
            }
            if (rd.FieldExists("BLOG_Home"))
            {
                Item.Home = (Boolean)(rd["BLOG_Home"]);
            }
            if (rd.FieldExists("BLOG_Views"))
            {
                Item.Views = (Int32)(rd["BLOG_Views"]);
            }
            if (rd.FieldExists("BLOG_RowId"))
            {
                Item.RowId = (Guid)(rd["BLOG_RowId"]);
            }
            if (rd.FieldExists("BLOG_TotalLike"))
            {
                Item.TotalLike = (Int32)(rd["BLOG_TotalLike"]);
            }
            if (rd.FieldExists("BLOG_TotalComment"))
            {
                Item.TotalComment = (Int32)(rd["BLOG_TotalComment"]);
            }
            if (rd.FieldExists("BLOG_Liked"))
            {
                Item.Liked = (Boolean)(rd["BLOG_Liked"]);
            }

            switch (Item.Loai)
            {
                case 1:
                    var profile = new Member();
                    if (rd.FieldExists("PROFILE_Vcard"))
                    {
                        profile.Vcard = (String)(rd["PROFILE_Vcard"]);
                    }
                    if (rd.FieldExists("PROFILE_Ten"))
                    {
                        profile.Ten = (String)(rd["PROFILE_Ten"]);
                    }
                    if (rd.FieldExists("PROFILE_Anh"))
                    {
                        profile.Anh = (String)(rd["PROFILE_Anh"]);
                    }
                    if (rd.FieldExists("PROFILE_Username"))
                    {
                        profile.Username = (String)(rd["PROFILE_Username"]);
                    }
                    Item.Profile = profile;
                    break;
                case 2:
                    var xe = new Xe();
                    if (rd.FieldExists("X_Ten"))
                    {
                        xe.Ten = (String)(rd["X_Ten"]);
                    }
                    if (rd.FieldExists("X_Ten"))
                    {
                        xe.Ten = (String)(rd["X_Ten"]);
                    }
                    if (rd.FieldExists("HANG_Ten"))
                    {
                        xe.HANG_Ten = (String)(rd["HANG_Ten"]);
                    }
                    if (rd.FieldExists("MODEL_Ten"))
                    {
                        xe.MODEL_Ten = (String)(rd["MODEL_Ten"]);
                    }
                    if (rd.FieldExists("X_ID"))
                    {
                        xe.Id = (Int64)(rd["X_ID"]);
                    }
                    Item.Xe = xe;
                    break;
                case 3:
                case 4:
                case 5:
                    var nhom = new Nhom();
                    if (rd.FieldExists("G_Ten"))
                    {
                        nhom.Ten = (String)(rd["G_Ten"]);
                    }
                    if (rd.FieldExists("G_ID"))
                    {
                        nhom.Id = (Int32)(rd["G_ID"]);
                    }
                    Item.Nhom = nhom;
                    break;
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
            Item.MemberNguoiTao = mem;
            return Item;
        }
        #endregion
        #region Extend
        public static Pager<Blog> PagerByPRowId(string url, bool rewrite, string sort, string pRowId, string username)
        {
            return PagerByPRowId(DAL.con(), url, rewrite, sort, pRowId, username, 20);
        }
        public static Pager<Blog> PagerByPRowId(SqlConnection con, string url, bool rewrite, string sort, string pRowId, string username, int size)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("pRowId", pRowId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", username);
            }
            var pg = new Pager<Blog>(con, "sp_tblBlog_Pager_PagerByPRowId_linhnx", "q", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Blog SelectByRowId(Guid RowId)
        {
            return SelectByRowId(RowId.ToString());
        }
        public static Blog SelectByRowId(string RowId)
        {
            var key = string.Format(CacheItemKey, RowId);
            var cacheObj = CacheHelper.Get(key);
            if (cacheObj == null)
            {
                var item = new Blog();
                var obj = new SqlParameter[1];
                obj[0] = new SqlParameter("BLOG_RowId", RowId);
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectByRowId_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        item = getFromReader(rd);
                    }
                }
                var list = new List<string> { string.Format(CacheItemKey, item.Id) };
                var dep = new CacheDependency(null, list.ToArray());
                CacheHelper.Max(key, item, dep);
                return item;

            }
            return (Blog) cacheObj;
        }
        public static Pager<Blog> PagerByPRowIdFull(SqlConnection con, string url, bool rewrite, string sort, string pRowId, string username)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("pRowId", pRowId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", username);
            }
            var pg = new Pager<Blog>(con, "sp_tblBlog_Pager_PagerByPRowIdFull_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Blog> PagerByPRowIdLoaiFull(SqlConnection con, string url, bool rewrite, string sort, string pRowId, string username, int loai)
        {
            return PagerByPRowIdLoaiFull(con, url, rewrite, sort, pRowId, username, loai, null);
        }
        public static Pager<Blog> PagerByPRowIdLoaiFull(SqlConnection con, string url, bool rewrite, string sort, string pRowId, string username, int loai, string publish)
        {
            return PagerByPRowIdLoaiFull(con, url, rewrite, sort, pRowId, username, loai, null, 20);
        }
        public static Pager<Blog> PagerByPRowIdLoaiFull(SqlConnection con, string url, bool rewrite, string sort, string pRowId, string username, int loai, string publish, int size)
        {
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("pRowId", pRowId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", username);
            }
            if (!string.IsNullOrEmpty(publish))
            {
                obj[3] = new SqlParameter("publish", publish);
            }
            else
            {
                obj[3] = new SqlParameter("publish", publish);
            }
            obj[4] = new SqlParameter("loai", loai);
            var pg = new Pager<Blog>(con, "sp_tblBlog_Pager_PagerByPRowIdLoaiFull_linhnx", "q", size, 10, rewrite, url, obj);
            return pg;
        }

        public static BlogCollection SelectTopBlogByLoai(SqlConnection con, int top, int loai, string username)
        {
            var list = new BlogCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", top);
            obj[1] = new SqlParameter("Loai", loai);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", username);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogByLoai_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }


        

        public static BlogCollection SelectTopForNhomByProwId(SqlConnection con, int top, Guid PRowId, int loai, string username, string Publish)
        {
            var list = new BlogCollection();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Top", top);
            obj[1] = new SqlParameter("Loai", loai);
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", username);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[3] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[3] = new SqlParameter("Publish", Publish);
            }
            obj[4] = new SqlParameter("PRowId", PRowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopForNhomByProwId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static List<Blog> SelectTopBlogProfile(SqlConnection con, int top, string username, string publish)
        {
            var key = string.Format(CacheListKey, "SelectTopBlogProfile-"  + top);
            var objCache = CacheHelper.Get(key);
            if (objCache == null)
            {
                var list = new BlogCollection();
                var obj = new SqlParameter[3];
                obj[0] = new SqlParameter("Top", top);
                if (!string.IsNullOrEmpty(username))
                {
                    obj[1] = new SqlParameter("username", username);
                }
                else
                {
                    obj[1] = new SqlParameter("username", username);
                }
                if (!string.IsNullOrEmpty(publish))
                {
                    obj[2] = new SqlParameter("publish", publish);
                }
                else
                {
                    obj[2] = new SqlParameter("publish", publish);
                }
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogProfile_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        list.Add(getFromReader(rd));
                    }
                }
                var listKey = new List<string>();
                list.ForEach(x =>
                {
                    if (CacheHelper.Get(string.Format(CacheItemKey, x.Id)) == null)
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), SelectById(con, x.Id));
                    }
                    listKey.Add(string.Format(CacheItemKey, x.Id));
                });
                var dep = new CacheDependency(null, listKey.ToArray());
                CacheHelper.Max(key, list, dep);
                return list;
            }
            return (List<Blog>)objCache;
        }
        public static List<Blog> SelectTopBlogXe(SqlConnection con, int top, string username, string publish)
        {
            var key = string.Format(CacheListKey, "SelectTopBlogXe-" + top);
            var objCache = CacheHelper.Get(key);
            if (objCache == null)
            {
                var list = new BlogCollection();
                var obj = new SqlParameter[3];
                obj[0] = new SqlParameter("Top", top);
                if (!string.IsNullOrEmpty(username))
                {
                    obj[1] = new SqlParameter("username", username);
                }
                else
                {
                    obj[1] = new SqlParameter("username", username);
                }
                if (!string.IsNullOrEmpty(publish))
                {
                    obj[2] = new SqlParameter("publish", publish);
                }
                else
                {
                    obj[2] = new SqlParameter("publish", publish);
                }
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogXe_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        list.Add(getFromReader(rd));
                    }
                }
                var listKey = new List<string>();
                list.ForEach(x =>
                {
                    if (CacheHelper.Get(string.Format(CacheItemKey, x.Id)) == null)
                    {
                        CacheHelper.Max(string.Format(CacheItemKey, x.Id), SelectById(con, x.Id));                        
                    }
                    listKey.Add(string.Format(CacheItemKey, x.Id));
                });
                var dep = new CacheDependency(null, listKey.ToArray());
                CacheHelper.Max(key, list, dep);
                return list;
            }
            return (List<Blog>)objCache;
        }
        public static BlogCollection SelectTopBlogNhom(SqlConnection con, int top, string username, string publish)
        {
            var list = new BlogCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", username);
            }
            if (!string.IsNullOrEmpty(publish))
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            else
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogNhom_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static BlogCollection SelectTopBlogTopicNhom(SqlConnection con, int top, string username, string publish)
        {
            var list = new BlogCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", username);
            }
            if (!string.IsNullOrEmpty(publish))
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            else
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogTopicNhom_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static BlogCollection SelectTopBlogQaNhom(SqlConnection con, int top, string username, string publish)
        {
            var list = new BlogCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", top);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", username);
            }
            if (!string.IsNullOrEmpty(publish))
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            else
            {
                obj[2] = new SqlParameter("publish", publish);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Select_SelectTopBlogQaNhom_linhnx", obj))
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
        public const string CacheKey = "Blog:{0}";
        public const string CacheItemUserKey = "Blog:Item:{0}:User:{1}";
        public const string CacheItemKey = "Blog:Item:{0}";
        public const string CacheListKey = "Blog:List:{0}";
        #endregion
    }
    #endregion
    #region BlogRedis
    public class BlogRedis
    {
        const string ItemKey = "urn:blog:{0}";
        const string ListKey = "urn:blog:list:{0}";
        private readonly IRedisClient _redisClient;
        public BlogRedis(IRedisClient client)
        {
            _redisClient = client;
        }
        public  Blog GetById(long id)
        {
            var key = string.Format(ItemKey, id);
            var item = _redisClient.Get<Blog>(key);
            if(item==null)
            {
                item = BlogDal.SelectById(id);
                _redisClient.Set(key, item);
            }
            return item;
        }

        public void Remove(long id)
        {
            var blog = GetById(id);
            var memberRedis = new MemberRedis(_redisClient);
            var member = memberRedis.GetByUsername(blog.NguoiTao);
            member.TotalBlog -= 1;
            member.BlogIds.Remove(id);
            memberRedis.Save(member);

            _redisClient.Remove(string.Format(ItemKey, id));
            _redisClient.Lists[string.Format(ListKey, "all")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "approved")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "unApproved")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "blog")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "hanhTrinh")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "nhomBlog")].Remove(id.ToString());
            _redisClient.Lists[string.Format(ListKey, "nhomForum")].Remove(id.ToString());
        }
        public IRedisList GetAll()
        {
            var key = string.Format(ListKey, "all");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetApproved()
        {
            var key = string.Format(ListKey, "approved");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetUnApproved()
        {
            var key = string.Format(ListKey, "unApproved");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetNhatKy()
        {
            var key = string.Format(ListKey, "blog");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetHanhTrinh()
        {
            var key = string.Format(ListKey, "hanhTrinh");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetNhomBlog()
        {
            var key = string.Format(ListKey, "nhomBlog");
            var ids = _redisClient.Lists[key];
            return ids;
        }
        public IRedisList GetNhomForum()
        {
            var key = string.Format(ListKey, "nhomForum");
            var ids = _redisClient.Lists[key];
            return ids;
        } 
    }
    #endregion
    #endregion
    
}


