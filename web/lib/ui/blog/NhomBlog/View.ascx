<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_blog_NhomBlog_View" %>
<%@ Register TagPrefix="uc1" TagName="NhomInfo" Src="~/lib/ui/nhom/Nhom-Info.ascx" %>
<%@ Register Src="~/lib/ui/nhom/Nhom-Header-Blog.ascx" TagPrefix="uc1" TagName="NhomHeaderBlog" %>
<%@ Register TagPrefix="binhLuan" TagName="List" Src="~/lib/ui/binhLuan/List.ascx" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/templates/Item-View.ascx" TagPrefix="binhLuan" TagName="ItemView" %>



<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <uc1:NhomHeaderBlog runat="server" ID="NhomHeaderBlog" />
            <hr class="hr comment-hr"/>
            <binhLuan:ItemView runat="server" ID="ItemView" />
            <a name="comments"></a>
            <binhLuan:List runat="server" ID="BinhLuanList" /> 
        </div>
        <div class="col-md-4">
            <uc1:NhomInfo runat="server" ID="NhomInfo" />
        </div>
    </div>    
</div>