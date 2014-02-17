<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="html_Inbox" %>

<%@ Register Src="~/lib/ui/pm/PmList.ascx" TagPrefix="pm" TagName="PmList" %>
<%@ Register Src="~/lib/ui/pm/RoomList.ascx" TagPrefix="pm" TagName="RoomList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="padding-20">
        <div class="row">
            <div class="col-md-4">
                <pm:RoomList runat="server" ID="RoomList" />            
            </div>
            <div class="col-md-8 PmContainer">
                <pm:PmList runat="server" ID="PmList" />            
            </div>
        </div>
    </div>
    
</asp:Content>

