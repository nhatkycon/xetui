<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListForProfileFull.ascx.cs" Inherits="lib_ui_blog_ListForProfileFull" %>
<%@ Import Namespace="docsoft" %>
<%@ Register TagPrefix="account" TagName="profileinfo" Src="~/lib/ui/account/Profile-Info.ascx" %>
<%@ Register TagPrefix="account" TagName="ProfileAbout" Src="~/lib/ui/account/profile-about.ascx" %>
<%@ Register TagPrefix="temp" TagName="ForProfile" Src="~/lib/ui/blog/templates/ForProfile-ItemFull.ascx" %>
<account:profileinfo ID="profileInfo" runat="server"/>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="h3-subtitle">
                <%if(ProfileMember.NguoiTao == Security.Username){ %>
                    <a href="<%=ProfileMember.Url %>blogs/add/" class="btn btn-primary pull-right">
                        <i class="glyphicon glyphicon-plus"></i> Thêm
                    </a>
                <%} %>
                <a href="<%=ProfileMember.Url %>/blogs/">
                    Nhật ký
                </a>
                <%if(Pager!=null && Pager.Total > 0){ %>
                <span class="text-muted"><%=Pager.Total %> bài</span>
                <%} %>
            </div>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <temp:ForProfile ID="forProfile1" runat="server" Item='<%# Container.DataItem %>'/>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-4 profile-info">
            <account:ProfileAbout ID="profileAbout" runat="server" />
        </div>
    </div>
</div>