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
    #region Blog
    #region BO
    public class Blog : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
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
        { }
        #endregion
        #region Customs properties

        public Member MemberNguoiTao { get; set; }
        public Member MemberProfile { get; set; }
        public Xe Xe { get; set; }
        public List<Anh> Anhs { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BlogDal.getFromReader(rd);
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
        }
        public static Blog Insert(Blog Inserted)
        {
            Blog Item = new Blog();
            SqlParameter[] obj = new SqlParameter[17];
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

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Blog Update(Blog Updated)
        {
            Blog Item = new Blog();
            SqlParameter[] obj = new SqlParameter[18];
            obj[0] = new SqlParameter("BLOG_ID", Updated.ID);
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

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBlog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Blog SelectById(Int64 BLOG_ID)
        {
            return SelectById(DAL.con(), BLOG_ID);
        }
        public static Blog SelectById(SqlConnection con, Int64 BLOG_ID)
        {
            Blog Item = new Blog();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BLOG_ID", BLOG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBlog_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
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
        public static Pager<Blog> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Blog> pg = new Pager<Blog>("sp_tblBlog_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Blog getFromReader(IDataReader rd)
        {
            Blog Item = new Blog();
            if (rd.FieldExists("BLOG_ID"))
            {
                Item.ID = (Int64)(rd["BLOG_ID"]);
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
            return Item;
        }
        #endregion
        #region Extend
        public static Pager<Blog> PagerByPRowId(string url, bool rewrite, string sort, string pRowId, string username)
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
            var pg = new Pager<Blog>("sp_tblBlog_Pager_PagerByPRowId_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Blog SelectByRowId(Guid RowId)
        {
            return SelectByRowId(RowId.ToString());
        }
        public static Blog SelectByRowId(string RowId)
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
            return item;
        }
        #endregion
    }
    #endregion
    #endregion
    
}


