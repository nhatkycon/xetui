using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using System.Web.Script.Serialization;

public partial class lib_lab_CacheRelated : BasedPage
{
    private const string BlogKey = "blog:ID:{0}";
    private const string MemKey = "mem:ID:{0}";

    protected void Page_Load(object sender, EventArgs e)
    {
        //CacheHelper.RemoveByPattern(MemKey);
        //CacheHelper.RemoveByPattern(BlogKey);
        var js = new JavaScriptSerializer();
        rendertext(js.Serialize(GetMembers()));
    }

    public Blog GetBlog(Int64 id)
    {
            var key = string.Format(BlogKey, id);
            var obj = CacheHelper.Get(key);
            if(obj == null)
            {
                var blog = BlogDal.SelectById(id);
                var mem = GetMember(blog.NguoiTao);
                var keys = new string[1];
                keys[0] = string.Format(MemKey, blog.NguoiTao);
                var dep = new CacheDependency(null, keys);
                CacheHelper.Max(key, blog, dep);
                obj = blog;
            }
            return (Blog)obj;
    }

    public List<Member> GetMembers()
    {
            var key = string.Format(MemKey, "List");
            var obj = CacheHelper.Get(key);
            if (obj == null)
            {
                var mems = MemberDal.SelectAll().Take(10).ToList();
                var listKey = new List<string>();
                mems.ForEach(x =>
                                 {
                                     CacheHelper.Max(string.Format(MemKey, x.ID), x);
                                     listKey.Add(string.Format(MemKey, x.ID));
                                 });
                var dep = new CacheDependency(null, listKey.ToArray());
                Cache.Insert(key, mems, dep);
                obj = mems;
            }
            return (List<Member>)obj;
    }

    public Member GetMember(string username)
    {

        var key = string.Format(MemKey, username);
        var obj = CacheHelper.Get(key);
        if (obj == null)
        {
            var mem = MemberDal.SelectAllByUserName(username);
            CacheHelper.Max(key, mem);
            obj = mem;
        }
        return (Member)obj;
    }
}