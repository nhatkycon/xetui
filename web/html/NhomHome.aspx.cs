using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_NhomHome : System.Web.UI.Page
{
    public Nhom Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        using(var con =DAL.con())
        {
            var item = NhomDal.SelectById(con, Convert.ToInt32(id) , Security.Username);
            NhomView.Item = item;

            var blogs = BlogDal.SelectTopForNhomByProwId(con, 20, item.RowId,  3, Security.Username, true.ToString());
            blogs.ToList().ForEach(s => s.Nhom = item);

            var topics = BlogDal.SelectTopForNhomByProwId(con, 20, item.RowId, 4, Security.Username, true.ToString());
            topics.ToList().ForEach(s => s.Nhom = item);

            NhomView.Blogs = blogs;
            NhomView.Topics = topics;

        }
    }
}