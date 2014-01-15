using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_cars_view : System.Web.UI.UserControl
{
    public Xe Item { get; set; }
    public List<DanhMuc> HangList { get; set; }
    public List<DanhMuc> ThanhPhoList { get; set; }
    public string Id { get; set; }
    public Pager<BinhLuan> Pager { get; set; }
    public Pager<Blog> PagerBlog { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        BinhLuanList.Pager = Pager;
        BinhLuanList.PRowId = Item.RowId.ToString();
        ListForCar.Pager = PagerBlog;
        ListForCar.Item = Item;
        ViewCarInfo.Item = Item;
        ViewCarInfo1.Item = Item;
        viewCarSlider.Item = Item;
    }
}