using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using docsoft.entities;
using linh.common;
using linh.core;

public partial class lib_lab_RedisBlog : System.Web.UI.Page
{
    static PooledRedisClientManager pooledClientManager = new PooledRedisClientManager("localhost");
    protected void Page_Load(object sender, EventArgs e)
    {
        //var startTime = DateTime.Now;
        //var list = BlogManager.GetAll(0,5);
        //foreach (var item in list)
        //{
        //    Response.Write(string.Format("{0}:{1}<br/>", item.Id, item.Ten));
        //}
        //var endTime = DateTime.Now;
        //var diff = endTime - startTime;
        //Response.Write(string.Format("{0}ms",diff.TotalMilliseconds));
        //var client = pooledClientManager.GetClient();

        //client.Set("blog:30", new Member2() { Ten = "Hello" });
    }
}

public class BlogManager
{
    static PooledRedisClientManager pooledClientManager = new PooledRedisClientManager("localhost");

    private const string Key = "urn:blog:{0}";
    public static List<Blog> GetAll( int star, int stop)
    {
        var redis = pooledClientManager.GetClient();
        var client = redis.As<Blog>();
        var list = new List<Blog>();
        foreach (var i in GetAllBlogId().GetRange(star, stop))
        {
            list.Add(GetBlog(client,i));
        }
        return list;
    }
    public static IRedisList<Int64> GetAllBlogId()
    {
        var redis = pooledClientManager.GetClient();
        var client = redis.As<Int64>();
        var list = client.Lists["blog.all"];
        if (!list.Any())
        {
            foreach (var item in BlogDal.SelectAll())
            {
                list.Append(item.ID);
            }
        }
        return list;

    }


    public static Blog GetBlog(IRedisTypedClient<Blog> client, Int64 id)
    {
        var key = string.Format(Key, id);
        if (!client.ContainsKey(key))
        {
            var item = BlogDal.SelectById(id);
            try
            {
                client.SetEntry(key,item);
            }
            catch(Exception ex)
            {
                item = new Blog() {ID = id, Ten = ex.Message};
                return item;
            }
        }
        return client.GetById(id);
    }
}
#region BO
public class Xe1 : BaseEntity
{
    #region Properties
    public Int64 ID { get; set; }
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
    public Xe1()
    { }
    #endregion
    #region Customs properties

    public string GioiThieu { get; set; }
    public List<Anh> Anhs { get; set; }

    public string HANG_Ma { get; set; }
    public string HANG_Ten { get; set; }

    public string MODEL_Ma { get; set; }
    public string MODEL_Ten { get; set; }

    public string THANHPHO_Ten { get; set; }

    public string NguoiTao_Ten { get; set; }
    public Member Member1 { get; set; }
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
             , ID);
        }
    }
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return XeDal.getFromReader(rd);
    }
}
#endregion
#region BO
public class Member2:Member
{
    
}
public class Member1 : BaseEntity
{
    #region Properties
    public Int32 ID { get; set; }
    public String Ho { get; set; }
    public String Ten { get; set; }
    public String Mota { get; set; }
    public String Anh { get; set; }
    public Int32 CQ_ID { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime NgayCapNhat { get; set; }
    public String Email { get; set; }
    public String Mobile { get; set; }
    public String DiaChi { get; set; }
    public Boolean Active { get; set; }
    public Boolean Khoa { get; set; }
    public Boolean XacNhan { get; set; }
    public DateTime NgayXacNhan { get; set; }
    public Boolean ChungThuc { get; set; }
    public DateTime NgayChungThuc { get; set; }
    public Boolean Admin { get; set; }
    public Guid RowId { get; set; }
    public String NguoiTao { get; set; }
    public Int32 Loai { get; set; }
    public String RefUsername { get; set; }
    public Boolean ThuKy { get; set; }
    public Int32 SLOnline { get; set; }
    public String Loai_Ten { get; set; }
    public String Phone { get; set; }
    public Guid Tinh { get; set; }
    public string Tinh_Ten { get; set; }
    public String FbId { get; set; }
    public String Vcard { get; set; }
    public DateTime NgaySinh { get; set; }
    public DateTime LastLoggedIn { get; set; }
    public Int32 TotalLiked { get; set; }
    public Int32 TotalComment { get; set; }
    public Int32 TotalBlog { get; set; }
    public Int32 TotalXe { get; set; }
    public bool Liked { get; set; }
    #endregion
    #region Contructor
    public Member1()
    { }
    #endregion
    #region Customs properties
    public CoQuan _CoQuan { get; set; }
    public List<Role> _Roles { get; set; }
    public List<Function> _Functions { get; set; }
    public String GH_Ten { get; set; }
    public Int32 GH_ID { get; set; }
    public bool Thich { get; set; }
    public Int32 SecondOnline { get; set; }
    public String VcardStr
    {
        get
        {
            if (string.IsNullOrEmpty(Vcard)) return string.Empty;
            if (SecondOnline == 0) return string.Empty;
            return string.Format(Vcard, SecondOnline);
        }
    }
    public string Url
    {
        get { return string.Format("/user/{0}", Username); }
    }
    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return MemberDal.getFromReader(rd);
    }
}
#endregion