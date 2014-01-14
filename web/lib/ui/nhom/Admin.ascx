<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="lib_ui_nhom_Admin" %>
<%@ Register Src="~/lib/ui/nhom/templates/Admin_Info.ascx" TagPrefix="uc1" TagName="Admin_Info" %>
<%@ Register Src="~/lib/ui/nhom/templates/Admin_BlogPendding.ascx" TagPrefix="uc1" TagName="Admin_BlogPendding" %>
<%@ Register Src="~/lib/ui/nhom/templates/Admin_MemberPendding.ascx" TagPrefix="uc1" TagName="Admin_MemberPendding" %>
<%@ Register Src="~/lib/ui/nhom/templates/Admin_Members.ascx" TagPrefix="uc1" TagName="Admin_Members" %>

<div class="padding-20">
    <div class="row">
        <div class="col-md-3">
            <a name="group-admin"></a>
            <div class="list-group">
                <a href="#group-admin-info" class="list-group-item">
                    Thông tin
                </a>
                <%if (NhomThanhVienPendding != null && NhomThanhVienPendding.Count > 0)
                  { %>
                <a href="#group-admin-memberPendding" class="list-group-item">
                    Thành viên chờ duyệt <span class="badge"><%=NhomThanhVienPendding.Count %></span>
                </a>
                <%} %>
                <a href="#group-admin-members" class="list-group-item">
                    Thành viên
                </a>
                <a href="#group-admin-blogPendding" class="list-group-item">
                    Blog chờ duyệt
                </a>
                <a href="#group-admin-topicPendding" class="list-group-item">
                    Topic chờ duyệt
                </a>
            </div>
        </div>
        <div class="col-md-9">
            <uc1:Admin_Info runat="server" ID="Admin_Info" />
            <uc1:Admin_BlogPendding runat="server" ID="Admin_BlogPendding" />
            <uc1:Admin_MemberPendding runat="server" id="Admin_MemberPendding" />
            <uc1:Admin_Members runat="server" ID="Admin_Members" />
        </div>
    </div>
</div>