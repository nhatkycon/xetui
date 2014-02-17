<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profile-about.ascx.cs" Inherits="lib_ui_account_profile_about" %>
<%@ Register Src="~/lib/ui/nhom/ListForProfile.ascx" TagPrefix="nhom" TagName="ListForProfile" %>
<%@ Register src="~/lib/ui/cars/carsInAccountPage.ascx" tagPrefix="cars" tagName="carsInAccountPage" %>
<hr class="hr comment-hr visible-xs visible-sm"/>
<h3 class="profile-info-header">
    Về tôi
</h3>
<h3 class="profile-info-about">
    <%=Item.Mota %>
</h3>
<cars:carsinaccountpage ID="xeMoiList" Ten="Xe của tôi" runat="server" />
<cars:carsinaccountpage ID="xeCuList" Ten="Xe từng chạy" runat="server" />
<nhom:listforprofile ID="ListForProfile" runat="server" />