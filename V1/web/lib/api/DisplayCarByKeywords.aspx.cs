using System;
using System.Collections.Generic;
using System.Linq;
using docsoft.entities;
using linh.core.dal;

public partial class lib_api_DisplayCarByKeywords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        int total;
        var list = SearchManager.SearchXe(q, 0, 10, out total);
        var carList = new List<Xe>();
        if (total <= 0) return;
        carList.AddRange(list.Select(obj => XeDal.SelectByRowId(obj.RowId)));

    }
}