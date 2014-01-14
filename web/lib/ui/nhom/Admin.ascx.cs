using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_nhom_Admin : System.Web.UI.UserControl
{
    public Nhom Item { get; set; }
    public List<Blog> Blogs { get; set; }
    public List<NhomThanhVien> NhomThanhVienPendding { get; set; }
    public List<NhomThanhVien> NhomThanhVien { get; set; }
    public NhomThanhVien CurrentMember { get; set; }
    public Obj Obj { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Admin_Info.Item = Item;
        Admin_Info.Obj = Obj;
        Admin_BlogPendding.Item = Item;
        Admin_BlogPendding.List = Blogs;
        Admin_MemberPendding.List = NhomThanhVienPendding;
        Admin_MemberPendding.Visible = NhomThanhVienPendding != null && NhomThanhVienPendding.Count > 0;

        Admin_Members.List = NhomThanhVien;

    }
}