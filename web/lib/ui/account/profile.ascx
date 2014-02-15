<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profile.ascx.cs" Inherits="lib_ui_account_profile" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/account/Profile-Info.ascx" tagPrefix="account" tagName="ProfileInfo" %>
<%@ Register src="~/lib/ui/account/profile-about.ascx" tagPrefix="account" tagName="ProfileAbout" %>
<%@ Register TagPrefix="temp" TagName="ForProfile" Src="~/lib/ui/blog/templates/ForProfile-ItemFull.ascx" %>
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
                <a href="<%=Item.Url %>/blogs/">
                    Blog
                </a>
                <%if(Pager!=null && Pager.Total > 0){ %>
                <span class="text-muted"><%=Pager.Total %> bài</span>
                <%} %>
            </div>
            <%if(Pager.Total > 0){ %>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <temp:ForProfile ID="forProfile1" runat="server" Item='<%# Container.DataItem %>'/>
                </ItemTemplate>
            </asp:Repeater>
            <%}
              else
              {%>
              <hr class="hr comment-hr"/>  
              Chưa có bài viết nào
             <% } %>
        </div>
        <div class="col-md-4 profile-info">
            <account:ProfileAbout ID="profileAbout" runat="server"/>
        </div>
    </div>
</div>