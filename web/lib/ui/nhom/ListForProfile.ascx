<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListForProfile.ascx.cs" Inherits="lib_ui_nhom_ListForProfile" %>
<%@ Register Src="~/lib/ui/nhom/templates/Item-Profile.ascx" TagPrefix="uc1" TagName="ItemProfile" %>
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
