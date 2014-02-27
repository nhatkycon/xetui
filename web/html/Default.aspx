<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="html_Default" %>

<%@ Register Src="~/lib/ui/account/HomeList.ascx" TagPrefix="uc1" TagName="HomeList" %>
<%@ Register Src="~/lib/ui/blog/HomeList.ascx" TagPrefix="blog" TagName="HomeList" %>
<%@ Register src="~/lib/ui/cars/homeSmallList.ascx" tagPrefix="cars" tagName="homeSmallList" %>
<%@ Register Src="~/lib/ui/hangXe/LeftMenu.ascx" TagPrefix="cars" TagName="LeftMenu" %>
<%@ Register Src="~/lib/ui/promoted/Home.ascx" TagPrefix="promoted" TagName="Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Xetui.vn - Cộng đồng xe và xế</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="cars-home-group">
        <div class="x-col left-menu-list">
            <cars:LeftMenu runat="server" ID="LeftMenu" />
        </div>
        <promoted:Home ID="promotedHome" runat="server"/>
        <hr class="hr comment-hr visible-xs visible-sm"/>
        <div class="x-col x10 x-userList">
            <uc1:HomeList runat="server" ID="UserHomeList" />            
        </div>
        <div class="x-col x10 home-blogs-box">
            <div class="row">
                <hr class="hr comment-hr visible-xs visible-sm"/>
                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-12 col-sm-6 col-xs-12">
                            <blog:HomeList ID="nhatKyXeTop" runat="server" Title="Hành trình"/>
                        </div>
                        <hr class="hr comment-hr visible-lg visible-md visible-xs hidden-sm"/>
                        <div class="col-md-12 col-sm-6 col-xs-12">
                            <blog:HomeList ID="blogTop" runat="server" Title="Blog mới"/>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 homeTopCarList">
                    <hr class="hr comment-hr visible-xs visible-sm"/>
                    <div class="row">
                        <div class="col-md-12 col-sm-6 col-xs-12">
                            <cars:homeSmallList Title="Top xe" runat="server" ID="topCarsList"/>                            
                        </div>
                        <hr class="hr comment-hr visible-lg visible-md visible-xs hidden-sm"/>
                        <div data-loai="1030" data-keywords="" class="adv-home-300 adv-box"></div>
                        <div class="col-md-12 col-sm-6 col-xs-12">
                            <cars:homeSmallList Title="Xe mới" runat="server" ID="newestCarsList"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<uc1:HomeCars runat="server" ID="HomeCars" />--%>
</asp:Content>

