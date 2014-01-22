using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_NhomAdmin : LoggedPage
{
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var logged = Security.IsAuthenticated();
        if(!logged)
        {
            Response.Redirect(string.Format("~/login/?return={0}", Server.UrlEncode(Request.RawUrl)));
        }
        using (var con = DAL.con())
        {
            var item = NhomDal.SelectById(con, Convert.ToInt32(id), Security.Username);
            Item = item;
            var currentMember = NhomThanhVienDal.SelectByNhomIdUsername(con, item.ID.ToString(), Security.Username);
            if (currentMember.ModLoai != 5 || !currentMember.Admin)
            {
                Admin.Visible = false;
                AdminUnAuthorize.Visible = true;
                AdminUnAuthorize.Item = item;
                return;
            }

            Admin.Visible = true;
            AdminUnAuthorize.Visible = false;

            Admin.Item = item;
            Admin.Obj = ObjDal.SelectByRowId(con, item.RowId);
            Admin.CurrentMember = currentMember;
            var blogs = BlogDal.SelectTopForNhomByProwId(con, 100, item.RowId, 3, Security.Username, false.ToString());
            blogs.ToList().ForEach(s => s.Nhom = item);

            Admin.Blogs = blogs;

            var nhomThanhVienPendding = NhomThanhVienDal.SelectByNhomId(con, id, false.ToString());
            Admin.NhomThanhVienPendding = nhomThanhVienPendding;

            var nhomThanhViens = NhomThanhVienDal.SelectByNhomId(con, id, true.ToString());
            Admin.NhomThanhVien = nhomThanhViens.Where(p => p.Username != Item.NguoiTao).ToList();


            //var topics = BlogDal.SelectTopForNhomByProwId(con, 20, item.RowId, 4, Security.Username, true.ToString());
            //topics.ToList().ForEach(s => s.Nhom = item);

            //NhomView.Blogs = blogs;
            //NhomView.Topics = topics;

        }
    }
}