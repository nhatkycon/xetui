<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewForProfile.ascx.cs" Inherits="lib_ui_blog_ViewForProfile" %>
<%@ Import Namespace="docsoft" %>
<%@ Register TagPrefix="account" TagName="profileinfo" Src="~/lib/ui/account/Profile-Info.ascx" %>
<%@ Register TagPrefix="account" TagName="ProfileAbout" Src="~/lib/ui/account/profile-about.ascx" %>
<%@ Register TagPrefix="binhLuan" TagName="List" Src="~/lib/ui/binhLuan/List.ascx" %>
<%@ Register TagPrefix="temp" TagName="BlogViewItem" Src="~/lib/ui/blog/templates/BlogView-Item.ascx" %>
<account:profileinfo ID="profileInfo" runat="server"/>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="h3-subtitle">
                <%if(Item.Username == Security.Username){ %>
                    <a href="<%=Item.Url %>/blogs/add/" class="btn btn-primary pull-right">
                        <i class="glyphicon glyphicon-plus"></i> Thêm
                    </a>
                <%} %>
                <a href="<%=Item.Url %>">
                    <%=Item.Ten %>
                </a>&nbsp; &gt;
                <a href="<%=Item.Url %>/blogs/">
                    Blog
                </a>
            </div>
            <hr class="hr comment-hr"/>
            <temp:BlogViewItem ID="blogViewItem" runat="server"/>
            <a name="comments"></a>
            <binhLuan:List runat="server" ID="BinhLuanList" />
        </div>
        <div class="col-md-4 profile-info">
            <account:ProfileAbout ID="profileAbout" runat="server"/>
        </div>
    </div>
</div>