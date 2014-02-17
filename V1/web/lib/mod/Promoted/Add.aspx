<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_Promoted_Add" %>
<%@ Register src="~/lib/ui/promoted/Add.ascx" tagPrefix="promoted" tagName="Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <a href="/lib/mod/Promoted/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
        </div>
        <div class="panel-body">
            <promoted:Add ID="add" runat="server" />
        </div>
    </div>
</asp:Content>

