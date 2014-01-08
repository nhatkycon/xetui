<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomeList.ascx.cs" Inherits="lib_ui_account_HomeList" %>
<%@ Register Src="~/lib/ui/account/templates/home-item.ascx" TagPrefix="uc1" TagName="homeitem" %>
<div class="padding-20">
    <div class="home-title">
        Lái xe "vàng son"
    </div>
    <div class="user-home-box">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:homeitem runat="server" ID="homeitem" Item='<%# Container.DataItem %>'/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>


