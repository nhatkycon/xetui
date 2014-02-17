using System;
using System.Data.SqlClient;
using System.Globalization;
using ServiceStack.Redis;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_lab_RedisBlog : BasedPage
{
    static PooledRedisClientManager pooledClientManager = new PooledRedisClientManager("localhost");
    protected void Page_Load(object sender, EventArgs e)
    {
        var startDate = DateTime.Now;
        var redis = pooledClientManager.GetClient();
        redis.FlushAll();
        redis.FlushDb();
        using(var con = DAL.con())
        {
            InitBlog(con);
            InitMember(con);
            InitXe(con);
            InitBinhLuan(con);
            InitObj(con);
            InitDanhMuc(con);
            InitLoaiDanhMuc(con);
        }
        
        var endDate = DateTime.Now;
        Response.Write(string.Format("{0}<br/>", (endDate - startDate).TotalMilliseconds));
        Response.Write(string.Format("{0}<br/>", redis.DbSize));
    }
    public void InitBlog(SqlConnection con)
    {
        const string itemKey = "urn:blog:{0}";
        const string itemList = "urn:blog:list:{0}";
        var redis = pooledClientManager.GetClient();
        //STEP:1
        //var blog = BlogDal.SelectAll().FirstOrDefault();
        //redis.Set(string.Format(itemKey,blog.Id), blog);

        //STEP:2
        var list = BlogDal.SelectAll();
        var all = redis.Lists[string.Format(itemList, "all")];
        var approved = redis.Lists[string.Format(itemList, "approved")];
        var unApproved = redis.Lists[string.Format(itemList, "unApproved")];
        var topNhatKy = redis.Lists[string.Format(itemList, "blog")];
        var topHanhTrinh = redis.Lists[string.Format(itemList, "hanhTrinh")];
        var topNhomBlog = redis.Lists[string.Format(itemList, "nhomBlog")];
        var topNhomForum = redis.Lists[string.Format(itemList, "nhomForum")];
        foreach (var item in list)
        {
            var key = string.Format(itemKey, item.Id);
            var thich = ThichDal.SelectByPidLoai(item.RowId, 3);
            foreach (var thich1 in thich)
            {
                item.NguoiThich.Add(thich1.Username);
            }
            var anhs = AnhDal.SelectByPId(DAL.con(), item.RowId.ToString(), 100);
            foreach (var anh in anhs)
            {
                item.AnhList.Add(anh.Id);
            }

            var binhLuanList = BinhLuanDal.PagerByPRowId(con, null, false, item.RowId.ToString(), 1000).List;
            foreach (var binhLuan in binhLuanList)
            {
                item.BinhLuanIds.Add(binhLuan.Id);
            }
            
            switch (item.Loai)
            {
                case 1:
                    topHanhTrinh.Push(item.Id.ToString(CultureInfo.InvariantCulture));
                    break;
                case 2:
                    topNhatKy.Push(item.Id.ToString());
                    break;
                case 3:
                    topNhomBlog.Push(item.Id.ToString());
                    break;
                case 4:
                    topNhomForum.Push(item.Id.ToString());
                    break;
            }
            redis.Set(key, item);
            redis.Set(string.Format(itemKey, item.RowId), item.Id);
            all.Push(item.Id.ToString());
            if (item.Publish)
            {
                approved.Push(item.Id.ToString());
            }
            else
            {
                unApproved.Push(item.Id.ToString());
            }
            
        }
    }
    public void InitMember(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        var list = MemberDal.SelectAll();
        const string itemKey = "urn:member:{0}";
        const string itemList = "urn:member:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var xacNhan = redis.Lists[string.Format(itemList, "xacNhan")];
        var chuaXacNhan = redis.Lists[string.Format(itemList, "chuaXacNhan")];

        foreach (var item in list)
        {
            var listBlog = BlogDal.PagerByPRowId(null, false, null, item.RowId.ToString(), item.Username).List;
            foreach (var blog in listBlog)
            {
                item.BlogIds.Add(blog.Id);
            }

            var listXe = XeDal.SelectDuyetByNguoiTao(con, item.Username, 1000, null);
            foreach (var xe in listXe)
            {
                item.XeIds.Add(xe.Id);
            }

            var xeYeuThichList = XeDal.PagerXeYeuThichByUsername(con, string.Empty, false, null, item.Username, null).List;
            foreach (var xe in xeYeuThichList)
            {
                item.XeYeuThichIds.Add(xe.Id);
            }

            var fans = MemberDal.PagerFanByRowId(string.Empty, true, null, item.RowId.ToString(), null).List;
            foreach (var mem in fans)
            {
                item.Fans.Add(mem.Username);
            }

            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            redis.Set(string.Format(itemKey, item.Username), item.Id);
            redis.Set(string.Format(itemKey, item.RowId), item.Id);
            all.Add(item.Id.ToString());
            if(item.XacNhan)
            {
                xacNhan.Add(item.Id.ToString());
            }
            else
            {
                chuaXacNhan.Add(item.Id.ToString());
            }
        }
    }
    public void InitXe(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        var list = XeDal.SelectAll();
        const string itemKey = "urn:xe:{0}";
        const string itemList = "urn:xe:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var chuaDuyet = redis.Lists[string.Format(itemList, "chuaDuyet")];
        var duyet = redis.Lists[string.Format(itemList, "duyet")];
        foreach (var item in list)
        {
            
            var anhs = AnhDal.SelectByPId(DAL.con(), item.RowId.ToString(), 100);
            foreach (var anh in anhs)
            {
                item.AnhIds.Add(anh.Id);
            }

            var binhLuanList = BinhLuanDal.PagerByPRowId(DAL.con(), null, false, item.RowId.ToString(), 1000).List;
            foreach (var binhLuan in binhLuanList)
            {
                item.BinhLuanIds.Add(binhLuan.Id);
            }

            var fans = MemberDal.PagerFanByRowId(string.Empty, true, null, item.RowId.ToString(), null).List;
            foreach (var mem in fans)
            {
                item.Fans.Add(mem.Username);
            }

            var listBlog = BlogDal.PagerByPRowId(null, false, null, item.RowId.ToString(), null).List;
            foreach (var blog in listBlog)
            {
                item.BlogIds.Add(blog.Id);
            }
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            redis.Set(string.Format(itemKey, item.RowId), item.Id);
            all.Add(item.Id.ToString());
            if (item.Duyet)
            {
                duyet.Add(item.Id.ToString());
            }
            else
            {
                chuaDuyet.Add(item.Id.ToString());
            }
        }
    }
    public void InitBinhLuan(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        const string itemKey = "urn:binhluan:{0}";
        const string itemList = "urn:binhluan:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var top = redis.Lists[string.Format(itemList, "top")];
        var list = BinhLuanDal.SelectAll();
        foreach (var item in list)
        {
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            all.Add(item.Id.ToString());
        }
        foreach (var item in all.GetRange(0, 10))
        {
            top.Add(item);
        }

    }
    public void InitNhom(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        const string itemKey = "urn:nhom:{0}";
        const string itemList = "urn:nhom:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var top = redis.Lists[string.Format(itemList, "top")];
        var chuaDuyet = redis.Lists[string.Format(itemList, "chuaDuyet")];
        var list = NhomDal.SelectAll();

        foreach (var item in list)
        {
            var listBlog =
                BlogDal.PagerByPRowIdLoaiFull(con, null, false, item.RowId.ToString(), null, null, 3, null, 1000).
                    List;
            foreach (var blog in listBlog)
            {
                item.BlogIds.Add(blog.Id);
                if (!blog.Publish)
                {
                    item.BlogUnApprovedIds.Add(blog.Id);
                }
            }

            var listForum =
                BlogDal.PagerByPRowIdLoaiFull(con, null, false, item.RowId.ToString(), null, null, 4, null, 1000).
                    List;
            foreach (var blog in listForum)
            {
                item.ForumBlogIds.Add(blog.Id);
                if(!blog.Publish)
                {
                    item.ForumBlogUnApprovedIds.Add(blog.Id);
                }
            }

            var listThanhVien = NhomThanhVienDal.SelectByNhomId(con, item.Id.ToString(), true.ToString());
            foreach (var mem in listThanhVien)
            {
                item.MemberIds.Add(mem.Username);
                if(mem.Admin)
                {
                    item.AdminIds.Add(mem.Username);
                }
            }
            var listThanhVienUnApproved = NhomThanhVienDal.SelectByNhomId(con, item.Id.ToString(),
                                                                          false.ToString());
            foreach (var mem in listThanhVienUnApproved)
            {
                item.UnApproveIds.Add(mem.Username);
            }
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            redis.Set(string.Format(itemKey, item.RowId), item.Id);
            all.Add(item.Id.ToString());
            if(!item.Duyet)
            {
                chuaDuyet.Add(item.Id.ToString());
            }
        }
        foreach (var item in all.GetRange(0, 10))
        {
            top.Add(item);
        }
        
    }
    public void InitObj(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        const string itemKey = "urn:obj:{0}";
        const string itemList = "urn:obj:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var list = ObjDal.SelectAll();
        foreach (var item in list)
        {
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            redis.Set(string.Format(itemKey, item.RowId), item.Id);
            all.Add(item.Id.ToString());
        }
    }
    public void InitDanhMuc(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        const string itemKey = "urn:danhmuc:{0}";
        const string itemList = "urn:danhmuc:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var list = DanhMucDal.SelectAll();
        foreach (var item in list)
        {
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            all.Add(item.Id.ToString());
        }
    }
    public void InitLoaiDanhMuc(SqlConnection con)
    {
        var redis = pooledClientManager.GetClient();
        const string itemKey = "urn:loaidanhmuc:{0}";
        const string itemList = "urn:loaidanhmuc:list:{0}";
        var all = redis.Lists[string.Format(itemList, "all")];
        var list = LoaiDanhMucDal.SelectAll();
        foreach (var item in list)
        {
            var danhMucList = DanhMucDal.SelectByLDMID(con, item.Id.ToString());
            foreach (var danhMuc in danhMucList)
            {
                item.DanhMucIds.Add(danhMuc.ID);
            }
            var key = string.Format(itemKey, item.Id);
            redis.Set(key, item);
            var ma = string.Format(itemKey, item.Ma);
            redis.Set(ma, item.Id);
            all.Add(item.Id.ToString());
        }
        
    }
}