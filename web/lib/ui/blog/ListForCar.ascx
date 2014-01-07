<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListForCar.ascx.cs" Inherits="lib_ui_blog_ListForCar" %>
<%@ Register src="templates/ForCar-Item.ascx" tagname="ForCar" tagprefix="uc1" %>
<hr class="hr comment-hr"/>
<h3 class="h3-subtitle">
    <a href="<%=Item.XeUrl %>/blogs/">
        Nhật ký hành trình
    </a>
    <%if(Pager!=null && Pager.Total > 0){ %>
    <span class="text-muted"><%=Pager.Total %></span> bài
    <%} %>
</h3>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ForCar ID="ForCar1" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>
