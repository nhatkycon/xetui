﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.vietbai.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.vietbai.htm.htm", "text/html")]
namespace projectMgr.plugin.backend.tinTuc.vietbai
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _F_ID = Request["F_ID"];
            string _Lang = Request["Lang"];
            string _Alias = Request["Alias"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _LangBased = Request["LangBased"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDungvb_tt = Request["NoiDungvb_tt"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _Status = Request["Status"];
            string _Nguon = Request["Nguon"];
            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    string _NguoiTao = Security.Username;
                    int _acp = 1;
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    Pager<Tin> PagerGet = TinDal.pagerNormalTin("", false, jgrsidx + " " + jgrsord, _q, _PID, _NguoiTao, _acp, "TIN_TUC", _Lang);

                    ListRow = new List<jgridRow>();
                    foreach (Tin item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item._ID.ToString()
                            ,item.Lang
                            ,item.ThuTu.ToString()
                            ,string.Format("<img src=\"../up/tintuc/{0}\" style=\"width:50px;height:50px; \"/>",item.Anh)
                            ,item.Ten
                            ,item.MoTa
                           // ,item.DM_ID.ToString()
                            ,item.DM_Ten
                            ,item.Nguon
                            ,item.Views.ToString()
                            ,item.NguoiTao
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                            ,item.Active.ToString()
                            ,item.Hot.ToString()
                            ,item.HetHan.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getPid":
                    #region danh sách chọn sẵn

                    break;
                    #endregion
                case "add":
                    #region thêm mới
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    Tin itemGetVanBan = TinDal.SelectByIdView(_ID);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        if (itemGetVanBan.Filelist.Count > 0)
                        {
                            if (itemGetVanBan.Filelist[0].ID != 0)
                            {
                                foreach (Files item in itemGetVanBan.Filelist)
                                {
                                    itemGetVanBan.FileListStr += string.Format(@"<span _value=""{0}"" class=""adm-token-item"">{1}{2}<a href=""javascript:;"">x</a></span>"
                                        , item.ID, item.Ten, item.MimeType);
                                }
                            }
                            sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan));
                        }
                        // sb.Append("(" + JavaScriptConvert.SerializeObject(TinDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TinDal.DeleteMultiById(_ID,"TIN_TUC");
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    Tin ItemDuyet = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemDuyet.multiID = _ID;
                        ItemDuyet.Active = Convert.ToBoolean(_Status);
                        TinDal.UpdateMulti(ItemDuyet);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hot":
                    #region Chuyển thành tin hot
                    Tin ItemHot = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHot.multiID = _ID;
                        ItemHot.Hot = Convert.ToBoolean(_Status);
                        TinDal.UpdateHotMulti(ItemHot);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hethan":
                    #region Hết hạn
                    Tin ItemHetHan = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHetHan.multiID = _ID;
                        ItemHetHan.HetHan = Convert.ToBoolean(_Status);
                        if (ItemHetHan.HetHan == true)
                        {
                            ItemHetHan.NgayHetHan = DateTime.Now;
                        }
                        TinDal.UpdateHetHanMulti(ItemHetHan);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "save":
                    #region lưu
                    Tin ItemSave = new Tin();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = TinDal.SelectById(Convert.ToInt32(_ID));
                    }
                    if (!string.IsNullOrEmpty(_Nguon))
                    {
                        ItemSave.Nguon = (_Nguon);
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.DM_ID = new Guid(_PID);
                    // ItemSave.DM_Ten = _PTen;
                    ItemSave.Anh = _Anh;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "0";
                    }
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.MoTa = _Mota;
                    ItemSave.NoiDung = _NoiDungvb_tt;
                    ItemSave.KeyWords = _KeyWords;
                    ItemSave.Description = _Description;
                    ItemSave.Alias = _Alias;
                    ItemSave.Lang = _Lang;
                    ItemSave.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        ItemSave.LangBased_ID = new Guid(_LangBased_ID);
                    }
                    ItemSave.Hot = Convert.ToBoolean(_Hot);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    if (_Public == "1")
                    {
                        ItemSave.NgayDang = DateTime.Now;
                    }
                    ItemSave.NguoiCapNhat = Security.Username;
                    ItemSave.HetHan = Convert.ToBoolean(_HetHan);
                    if (!string.IsNullOrEmpty(_NgayHetHan))
                    {
                        ItemSave.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(_NgayCapNhat))
                    {
                        DateTime dt = new DateTime();


                        ItemSave.NgayCapNhat = Convert.ToDateTime(_NgayCapNhat, new CultureInfo("vi-Vn"));//.AddHours(dt.Hour).AddMinutes(dt.Minute).AddSeconds(dt.Second);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = TinDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = TinDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.vietbai.JScript1.js"));
                    break;
                    #endregion
                case "saveDoc":
                    #region Lưu tài liệu
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        item.VB_ID = Convert.ToInt32(0);
                        Guid g = new Guid(_ID);

                        item.PID = g;
                        item = FilesDal.Update(item);
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        string _directory = Server.MapPath("~/up/d/") + item.ThuMuc;
                        string _files = Server.MapPath("~/up/d/") + item.ThuMuc + "/" + item.Ten + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_files);
                            Directory.Delete(_directory);
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">

<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tin"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""vbtinmdl-addBtn"" href=""javascript:vbtinfn.add();"">Viết bài</a>
<a class=""mdl-head-btn mdl-head-add"" id=""danhMucMdl-addBtn"" href=""javascript:"" onclick=""vbtinfn.addLang();"" >Bài viết ngôn ngữ khác</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""vbtinmdl-editBtn"" href=""javascript:vbtinfn.edit();"">Sửa bài viết</a>
<a class=""mdl-head-btn mdl-head-del"" id=""vbtinmdl-delBtn"" href=""javascript:vbtinfn.del();"">Xóa bài viết</a>
<select class=""slt"" onchange=""vbtinfn.search();"" id=""vbTintucdl-changeLangSlt""></select>

<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"" style='display:none'>
    <span class=""mdl-headTask-Loc-Title"" style='display:none'>
        <span class=""ui-icon ui-icon-triangle-1-s""></span>        
        Tin hot <span class=""mdl-headTask-Loc-Title-Display""></span>
    </span>
    <span class=""mdl-headTask-Loc-Box"" style='display:none'>
        <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
            <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
                <span onclick=""javascript:vbtinfn.tinhot('true');"">Chuyển tin hot</span>
                <span onclick=""javascript:vbtinfn.tinhot('false');"">Chuyển tin thường</span>
            </span>
        </span>
    </span>
</a>
<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"" style='display:none'>
    <span class=""mdl-headTask-Loc-Title"">
        <span class=""ui-icon ui-icon-triangle-1-s""></span>        
        Hết hạn <span class=""mdl-headTask-Loc-Title-Display""></span>
    </span>
    <span class=""mdl-headTask-Loc-Box"" >
        <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
            <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
                <span onclick=""javascript:vbtinfn.hethan('true');"">Chuyển hết hạn</span>
                <span onclick=""javascript:vbtinfn.hethan('false');"">Gia hạn</span>
            </span>
        </span>
    </span>
</a>
<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"" style='display:none'>
    <span class=""mdl-headTask-Loc-Title"" style='display:none'>
        <span class=""ui-icon ui-icon-triangle-1-s""></span>        
        Lọc tin <span class=""mdl-headTask-Loc-Title-Display""></span>
    </span>
    <span class=""mdl-headTask-Loc-Box"" style='display:none'>
        <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"" style='display:none'>
            <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"" style='display:none'>
                <span onclick=""javascript:vbtinfn.hethan('true');"">Tin kích hoạt</span>
                <span onclick=""javascript:vbtinfn.hethan('false');"">Tin hot</span>
                <span onclick=""javascript:vbtinfn.hethan('false');"">Hết hạn</span>
            </span>
        </span>
    </span>
</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-vbfilterdanhmuc""/>
</span>
</div>
<table id=""vbtinmdl-List"" class=""mdl-list""></table>
<div id=""vbtinmdl-Pagerql""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.vietbai.JScript1.js")
                        , "{vbtinfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
