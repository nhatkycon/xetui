<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile-fans.ascx.cs" Inherits="lib_ui_account_Profile_fans" %>
<%@ Register TagPrefix="temp" TagName="FanItem" Src="~/lib/ui/account/templates/Fan-Item.ascx" %>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="h3-subtitle">
                Người hâm mộ của
                <a href="<%=Item.Url %>">
                    <%=Item.Ten %>
                </a>
                <%if(Pager!=null && Pager.Total > 0){ %>
                    <span class="text-muted"><%=Pager.Total %> người</span>
                <%} %>
            </div>
            <hr class="hr comment-hr"/>
            <%if(Pager.Total > 0){ %>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <temp:FanItem ID="FanItem1" runat="server" Item='<%# Container.DataItem %>'/>
                </ItemTemplate>
            </asp:Repeater>
            <%}
              else
              {%>
              Hiện chưa có ai hâm mộ <%=Item.Ten %>
             <% } %>
        </div>
        <div class="col-md-4 profile-info">
        </div>
    </div>
</div>