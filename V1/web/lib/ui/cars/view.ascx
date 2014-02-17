<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view.ascx.cs" Inherits="lib_ui_cars_view" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/binhLuan/List.ascx" TagPrefix="binhLuan" TagName="List" %>
<%@ Register src="~/lib/ui/blog/ListForCar.ascx" tagPrefix="blog" tagName="ListForCar" %>
<%@ Register src="~/lib/ui/cars/view-car-slider.ascx" tagPrefix="car" tagName="ViewCarSlider" %>
<%@ Register src="~/lib/ui/cars/view-car-info.ascx" tagPrefix="car" tagName="ViewCarInfo" %>
<car:viewcarslider ID="viewCarSlider" runat="server"/>
<car:ViewCarInfo Css=" visible-sm visible-xs" ID="ViewCarInfo1" runat="server"/>
<div class="row car-view-body">
    <div class="col-md-6">
        <div class="padding-20">
            <div class="car-view-author-pnl">
                <%=Item.Member.Vcard %>
            </div>
            <h3 class="car-view-intro-title">Về chiếc xe của tôi</h3>
            <div class="car-view-intro">
                <%=Item.GioiThieu %>
            </div>
            <hr/>
            <blog:ListForCar ID="ListForCar" runat="server"/>
        </div>
    </div>
    <div class="col-md-6">
        <car:ViewCarInfo Css=" hidden-sm hidden-xs" ID="ViewCarInfo" runat="server"/>
        <binhLuan:List runat="server" ID="BinhLuanList" />
    </div>
</div>