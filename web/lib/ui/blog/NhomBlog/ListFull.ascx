<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFull.ascx.cs" Inherits="lib_ui_blog_NhomBlog_ListFull" %>
<%@ Register TagPrefix="uc1" TagName="NhomInfo" Src="~/lib/ui/nhom/Nhom-Info.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NhomHeaderBlog" Src="~/lib/ui/nhom/Nhom-Header-Blog.ascx" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/templates/Item-Full.ascx" TagPrefix="uc1" TagName="ItemFull" %>

<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <uc1:NhomHeaderBlog runat="server" ID="NhomHeaderBlog" />
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:ItemFull runat="server" ID="ItemFull" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-4">
            <uc1:NhomInfo runat="server" ID="NhomInfo" />
        </div>
    </div>    
</div>