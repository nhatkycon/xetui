<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_Members.ascx.cs" Inherits="lib_ui_nhom_templates_Admin_Members" %>
<%@ Register TagPrefix="uc1" TagName="ItemAdmin" Src="~/lib/ui/account/NhomMember/templates/Item-Admin.ascx" %>

<div class="panel panel-default">
    <div class="panel-heading">
        Thành viên
        <a href="#group-admin" name="group-admin-memberPendding" class="btn btn-default btn-sm pull-right">
            <i class="glyphicon glyphicon-arrow-up"></i>
        </a>
    </div>
    <div class="panel-body nhomThanhVien-memberBox">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemAdmin runat="server" id="ItemAdmin1" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>    
</div>