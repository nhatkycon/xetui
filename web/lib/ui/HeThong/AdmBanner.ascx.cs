using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.common;

public partial class lib_ui_HeThong_AdmBanner : System.Web.UI.UserControl
{
    public List<Function> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        List = FunctionDal.SelectByUser(Security.Username, "0").Where(p => p.PID == 362).ToList();

    }
    #region TreeProcess
    List<Function> GetTree(List<Function> inputList)
    {
        var list = new List<Function>();
        foreach (HierarchyNode<Function> item in buildTree(inputList))
        {
            item.Entity.Level = item.Depth;
            list.Add(item.Entity);
            buildChild(item, list);
        }
        return list;
    }
    void buildChild(HierarchyNode<Function> item, List<Function> list)
    {
        foreach (HierarchyNode<Function> _item in item.ChildNodes)
        {
            _item.Entity.Level = _item.Depth;
            list.Add(_item.Entity);
            buildChild(_item, list);
        }
    }
    IEnumerable<HierarchyNode<Function>> buildTree(List<Function> listInput)
    {
        var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.PID);
        return tree.ToList();
    }
    #endregion
}