<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFull.ascx.cs" Inherits="lib_ui_blog_NhomForum_ListFull" %>
<%@ Register TagPrefix="uc1" TagName="NhomInfo" Src="~/lib/ui/nhom/Nhom-Info.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NhomHeaderForum" Src="~/lib/ui/nhom/Nhom-Header-Forum.ascx" %>
<%@ Register Src="~/lib/ui/blog/NhomForum/templates/Item-Full.ascx" TagPrefix="uc1" TagName="ItemFull" %>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <uc1:NhomHeaderForum runat="server" ID="NhomHeaderForum" />
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