<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_MemberPendding.ascx.cs" Inherits="lib_ui_nhom_templates_Admin_MemberPendding" %>
<%@ Register Src="~/lib/ui/account/NhomMember/templates/Item-AdminDuyet.ascx" TagPrefix="uc1" TagName="ItemAdminDuyet" %>

<div class="panel panel-default">
    <div class="panel-heading">
        Thành viên chờ duyệt
        <a href="#group-admin" name="group-admin-memberPendding" class="btn btn-default btn-sm pull-right">
            <i class="glyphicon glyphicon-arrow-up"></i>
        </a>
    </div>
    <div class="panel-body nhomThanhVien-memberPenddingBox">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemAdminDuyet runat="server" ID="ItemAdminDuyet" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>    
</div>