using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack.Redis;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_blog_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pooledClientManager = new PooledRedisClientManager("localhost");
        var client = pooledClientManager.GetClient();
        var Ten = Request["Ten"];
        var PID_ID = Request["PID_ID"];
        var Loai = Request["Loai"];
        var Id = Request["Id"];
        var cUrl = Request["cUrl"];
        var rowId = Request["RowId"];
        var noiDung = Request["NoiDung"];
        var approved = Request["approved"];
        var logged = Security.IsAuthenticated();
        var idNull = string.IsNullOrEmpty(Id) || Id == "0";
        var blogRedis = new BlogRedis(client);
        var memberRedis = new MemberRedis(client);
        var nhomRedis = new NhomRedis(client);
        var xeRedis = new XeRedis(client);
        switch (subAct)
        {
            case "save":
                #region save blog
                if (logged && !string.IsNullOrEmpty(PID_ID) && !string.IsNullOrEmpty(Loai))
                {
                    var item = idNull ? new Blog() : BlogDal.SelectById(Convert.ToInt64(Id));
                    var member = new Member();
                    var xe = new Xe();
                    var nhom = new Nhom();
                    var nguoiTao = new Member();
                    item.NoiDung = noiDung;
                    item.Ten = Ten;
                    if (!string.IsNullOrEmpty(Loai))
                    {
                        item.Loai = Convert.ToInt32(Loai);
                    }
                    if (!string.IsNullOrEmpty(PID_ID))
                    {
                        item.PID_ID = new Guid(PID_ID);
                    }
                    if (!string.IsNullOrEmpty(rowId))
                    {
                        item.RowId = new Guid(rowId);
                    }
                    
                    item.MoTa = Lib.Rutgon(Lib.NoHtml(item.NoiDung), 400);
                    var anhs = AnhDal.SelectByPId(DAL.con(), item.RowId.ToString(), 20).OrderByDescending(x => x.AnhBia).ToList();

                    if (anhs.Count > 0)
                    {
                        var sb = new StringBuilder();
                        foreach (var anhItem in anhs)
                        {
                            sb.AppendFormat(@"<a href=""{1}""><img alt=""{0}"" src=""/lib/up/car/{0}?w=75"" /></a>" , anhItem.FileAnh, item.Url);
                            item.AnhList.Add(anhItem.Id);
                        }
                        item.AnhStr = sb.ToString();
                        
                    }
                    switch (item.Loai)
                    {
                        case 1:
                            member = memberRedis.GetByRowId(item.PID_ID);
                            break;
                        case 2:
                            xe = xeRedis.GetByRowId(item.PID_ID);
                            break;
                        case 3:
                        case 4:
                        case 5:
                            //item.Nhom = NhomDal.SelectByRowId(DAL.con(), item.PID_ID, Security.Username);
                            nhom = nhomRedis.GetByRowId(item.PID_ID);
                            break;
                    }
                    if (idNull)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        var insert = BlogDal.Insert(item);
                        item.Id = insert.Id;
                        nguoiTao = memberRedis.GetByUsername(item.NguoiTao);
                        switch (item.Loai)
                        {
                            case 1:
                                break;
                            case 2:
                                CacheHelper.Remove(string.Format(XeDal.CacheItemKey,item.Id));
                                systemMessageDal.Insert(new systemMessage()
                                {
                                    NoiDung = string.Format("<strong>{0}</strong> viết bài mới", nguoiTao.Ten)
                                    ,
                                    HeThong = false
                                    ,
                                    Id = Guid.NewGuid()
                                    ,
                                    PRowId = item.PID_ID
                                    ,
                                    NgayTao = DateTime.Now
                                    ,
                                    Active = true
                                    ,
                                    Loai = 1
                                    ,
                                    Url = string.Format("{0}", item.Url)
                                    ,
                                    Ten = string.Empty
                                    ,
                                    ThanhVienMoi = false
                                    ,
                                    Username = Security.Username
                                    ,
                                    ThuTu = 0
                                });
                                break;
                            case 3:
                            case 4:
                            case 5:
                                if (nhom.NhomMo)
                                {
                                    item.Publish = true;
                                }
                                systemMessageDal.Insert(new systemMessage()
                                {
                                    NoiDung = string.Format("<strong>{0}</strong> viết bài mới", nguoiTao.Ten)
                                    ,
                                    HeThong = false
                                    ,
                                    Id = Guid.NewGuid()
                                    ,
                                    PRowId = item.PID_ID
                                    ,
                                    NgayTao = DateTime.Now
                                    ,
                                    Active = true
                                    ,
                                    Loai = 1
                                    ,
                                    Url = string.Format("{0}", item.Url)
                                    ,
                                    Ten = string.Empty
                                    ,
                                    ThanhVienMoi = false
                                    ,
                                    Username = Security.Username
                                    ,
                                    ThuTu = 0
                                });
                                BlogDal.Update(item);
                                break;
                        }
                        ObjMemberDal.Insert(new ObjMember()
                        {
                            PRowId = item.RowId
                            ,
                            Username = Security.Username
                            ,
                            Owner = true
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = Guid.NewGuid()
                        });
                        var obj = ObjDal.Insert(new Obj()
                        {
                            Id = Guid.NewGuid()
                            ,
                            Kieu = typeof(Blog).FullName
                            ,
                            NgayTao = DateTime.Now
                            ,
                            RowId = item.RowId
                            ,
                            Url = string.Format("{0}", item.Url)
                            ,
                            Username = Security.Username
                        });

                       
                    }
                    else
                    {
                        nguoiTao = memberRedis.GetByUsername(item.NguoiTao);
                        BlogDal.Update(item);
                        
                    }
                    switch (item.Loai)
                    {
                        case 1:
                            if (member != null)
                            {
                                item.Url = string.Format("{0}/blogs/{1}/", member.Url, item.Id);
                                item.UrlEdit = string.Format("{0}/blogs/edit/{1}/", member.Url, item.Id);
                            }
                            break;
                        case 2:
                            if (xe != null)
                            {
                                item.Url = string.Format("{0}blogs/{1}/", xe.XeUrl, item.Id);
                                item.UrlEdit = string.Format("{0}blogs/edit/{1}/", xe.XeUrl, item.Id);
                            }
                            break;
                        case 3:
                            if (nhom != null)
                            {
                                item.Url = string.Format("{0}blogs/{1}/", nhom.Url, item.Id);
                                item.UrlEdit = string.Format("{0}blogs/edit/{1}/", nhom.Url, item.Id);
                            }
                            break;
                        case 4:
                            if (nhom != null)
                            {
                                item.Url = string.Format("{0}forum/{1}/", nhom.Url, item.Id);
                                item.UrlEdit = string.Format("{0}blogs/edit/{1}/", nhom.Url, item.Id);
                            }
                            break;
                        case 5:
                            if (nhom != null)
                            {
                                item.Url = string.Format("{0}qa/{1}/", nhom.Url, item.Id);
                                item.UrlEdit = string.Format("{0}blogs/edit/{1}/", nhom.Url, item.Id);
                            }
                            break;
                    }
                    blogRedis.Save(item);
                    SearchManager.Add(item.Ten, string.Format("{0} {1}", item.Ten, item.NoiDung), string.Empty, item.RowId.ToString(), item.Url, typeof(Blog).Name);
                    rendertext(item.Url);
                }
                rendertext("0");
                break;
                #endregion
            case "remove":
                #region remove blog
                if(!string.IsNullOrEmpty(Id) && logged)
                {
                    var item = BlogDal.SelectById(Convert.ToInt64(Id));
                    if(item.NguoiTao==Security.Username)
                    {
                        SearchManager.Remove(item.RowId);
                        ObjDal.DeleteByRowId(item.RowId);
                        ObjMemberDal.DeleteByPRowId(item.RowId.ToString());
                        ThichDal.DeleteByPId(item.RowId);
                        CacheHelper.Remove(string.Format(BlogDal.CacheItemKey, item.Id));
                        BlogDal.DeleteById(item.Id);
                        blogRedis.Remove(item.Id);
                        rendertext("1");
                    }
                }
                break;
                #endregion
            case "nhomDuyetBlog":
                #region duyet blog of Nhom
                if (!string.IsNullOrEmpty(Id) && logged && !string.IsNullOrEmpty(approved))
                {
                    var Approved = approved == "1";

                    var item = blogRedis.GetById(Convert.ToInt64(Id));
                    if(Approved)
                    {
                        item.Publish = true;
                        BlogDal.Update(item);
                        blogRedis.Save(item);
                    }
                    else
                    {
                        blogRedis.Save(item);
                        BlogDal.DeleteById(item.Id);
                    }
                    
                }
                break;
                #endregion
        }
    }
}