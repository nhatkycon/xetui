<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_Nhom_Add" %>
<%@ Register Src="~/lib/ui/nhom/Add.ascx" TagPrefix="uc1" TagName="Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <a href="/lib/mod/Nhom/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
        </div>
        <div class="panel-body">
            <uc1:Add runat="server" ID="Add" />
        </div>
    </div>
</asp:Content>

