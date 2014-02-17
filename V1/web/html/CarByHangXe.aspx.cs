using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_CarByHangXe : System.Web.UI.Page
{
    public DanhMuc Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var url = string.Empty;
        var ten = Request["Ten"];
        using (var con = DAL.con())
        {
            
            var item = DanhMucDal.SelectByTen(con, ten);
            if(item==null) return;
            Item = item;

            var allModel = DanhMucDal.SelectByLdmMaFromCache("HANGXE");
            var filterModel = (from p in allModel
                               where p.PID == item.ID
                               select p).OrderBy(m => m.ThuTu).ToList();
            filterModel.ForEach(x => x.Hang = Item);
            ListByHangXe.List = filterModel;

            var pager = XeDal.PagerByHang(con, url, false, null, 50, null, item.ID.ToString(), null, Security.Username);
            ListByHangXe.Pager = pager;
            ListByHangXe.Item = Item;
        }
        
    }
}