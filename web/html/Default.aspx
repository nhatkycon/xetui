<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="html_Default" %>

<%@ Register Src="~/lib/ui/account/HomeList.ascx" TagPrefix="uc1" TagName="HomeList" %>
<%@ Register Src="~/lib/ui/blog/HomeList.ascx" TagPrefix="blog" TagName="HomeList" %>
<%@ Register src="~/lib/ui/cars/homeSmallList.ascx" tagPrefix="cars" tagName="homeSmallList" %>
<%@ Register Src="~/lib/ui/hangXe/LeftMenu.ascx" TagPrefix="cars" TagName="LeftMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="cars-home-group">
        <div class="x-col left-menu-list">
            <cars:LeftMenu runat="server" ID="LeftMenu" />
        </div>
        <div class="x-col x4 cars-home-1st-list">
            <img src="/html/img/car/8.jpg" />
        </div>
        <div class="x-col x2 cars-home-2nd-list">
            <img src="/html/img/car/8.jpg" />
            <img src="/html/img/car/8.jpg" />
        </div>
        <div class="x-col x1 cars-home-3rd-list">
            <img src="/html/img/car/8.jpg" />
            <img src="/html/img/car/8.jpg" />
            <img src="/html/img/car/8.jpg" />
            <img src="/html/img/car/8.jpg" />
        </div>
        <div class="x-col x10">
            <uc1:HomeList runat="server" ID="UserHomeList" />            
        </div>
        <div class="x-col x10 home-blogs-box">
            <div class="row">
                <div class="col-md-8">
                    <blog:HomeList ID="nhatKyXeTop" runat="server" Title="Nhật ký xe mới"/>
                    <hr class="hr comment-hr"/>
                    <blog:HomeList ID="blogTop" runat="server" Title="Blog mới"/>
                </div>
                <div class="col-md-4">
                    <cars:homeSmallList Title="Top xe" runat="server" ID="topCarsList"/>
                    <hr class="hr comment-hr"/>
                    <cars:homeSmallList Title="Xe mới" runat="server" ID="newestCarsList"/>
                </div>
            </div>
        </div>
    </div>
    <%--<uc1:HomeCars runat="server" ID="HomeCars" />--%>
</asp:Content>

