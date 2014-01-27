<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="lib_ui_HeThong_Search" %>
<%@ Register src="~/lib/ui/HeThong/templates/Item-Search.ascx" tagPrefix="temp" tagName="ItemSearch" %>
<div class="padding-20">
    <div class="h3-subtitle">
        Tìm kiếm <strong>&quot; <%=Request["q"] %> &quot;</strong> - 
        <span class="text-muted">
            <%=Total %> kết quả
        </span>
    </div>
    <hr class="hr comment-hr"/>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <temp:ItemSearch ID="itemSearch1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>


