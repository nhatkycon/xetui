<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profile-about.ascx.cs" Inherits="lib_ui_account_profile_about" %>
<%@ Register Src="~/lib/ui/nhom/templates/Item-Profile.ascx" TagPrefix="uc1" TagName="ItemProfile" %>

<hr class="hr comment-hr visible-xs visible-sm"/>
<h3 class="profile-info-header">
    Về tôi
</h3>
<h3 class="profile-info-about">
    <%=Item.Mota %>
</h3>
<hr class="hr comment-hr"/>
<h3 class="profile-info-header">
    Cộng đồng
</h3>
<ul>
    <asp:Repeater runat="server" ID="rptNhom">
        <ItemTemplate>
            <uc1:ItemProfile runat="server" ID="ItemProfile" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</ul>
