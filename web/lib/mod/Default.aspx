<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" id="form1">
        <div class="row">
            <div class="col-md-4">
                <h3>
                    Hệ thống
                </h3>
                <asp:LinkButton CssClass="btn btn-default" runat="server" ID="btnReindex" onclick="btnReindex_Click">Reindex</asp:LinkButton>
            </div>
        </div>    
    </form>
</asp:Content>

