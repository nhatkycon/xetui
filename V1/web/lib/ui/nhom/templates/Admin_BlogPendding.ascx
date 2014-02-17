<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_BlogPendding.ascx.cs" Inherits="lib_ui_nhom_templates_Admin_BlogPendding" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/templates/Item-Admin.ascx" TagPrefix="uc1" TagName="ItemAdmin" %>

<div class="panel panel-default">
    <div class="panel-heading">
        Blog chờ duyệt
        <a href="#group-admin" name="group-admin-blogPendding" class="btn btn-default btn-sm pull-right">
            <i class="glyphicon glyphicon-arrow-up"></i>
        </a>
    </div>
    <div class="panel-body nhomPenddingBlogs-Box">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemAdmin runat="server" ID="ItemAdmin" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>    
</div>