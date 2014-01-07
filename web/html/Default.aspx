<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="html_Default" %>

<%@ Register src="ui/left-navigation.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register Src="~/lib/ui/account/HomeCars.ascx" TagPrefix="uc1" TagName="HomeCars" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-6">
            <img class="img-responsive" src="/html/img/car/8.jpg" />
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-6">
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                </div>
                <div class="col-md-3">
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                    <img class="img-responsive" src="/html/img/car/8.jpg" />
                </div>
            </div>        
        </div>
    </div>
    <uc1:left ID="left1" runat="server" />
    <uc1:HomeCars runat="server" ID="HomeCars" />
</asp:Content>

