<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewForCar.ascx.cs" Inherits="lib_ui_blog_ViewForCar" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/binhLuan/List.ascx" TagPrefix="binhLuan" TagName="List" %>
<%@ Register src="~/lib/ui/blog/ListForCar.ascx" tagPrefix="blog" tagName="ListForCar" %>
<%@ Register src="~/lib/ui/cars/view-car-slider.ascx" tagPrefix="car" tagName="ViewCarSlider" %>
<%@ Register src="~/lib/ui/cars/view-car-info-nano.ascx" tagPrefix="car" tagName="ViewCarInfo" %>
<%@ Register src="~/lib/ui/blog/templates/BlogView-Item.ascx" tagPrefix="temp" tagName="BlogViewItem" %>
<car:viewcarslider ID="viewCarSlider" runat="server"/>
<div class="row car-view-body">
    <div class="col-md-8">
        <div class="padding-20">
            <h2 class="navi-item blog-view-back">
                <a href="<%=Item.XeUrl %>blogs/">Nhật ký hành trình</a>
            </h2>
            <hr class="hr comment-hr"/>
            <temp:BlogViewItem ID="blogViewItem" runat="server"/>
            <a name="comments"></a>
            <binhLuan:List runat="server" ID="BinhLuanList" />            
        </div>
    </div>
    <div class="col-md-4">
        <car:ViewCarInfo ID="ViewCarInfo" runat="server"/>        
    </div>
</div>