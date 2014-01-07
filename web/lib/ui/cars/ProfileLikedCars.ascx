<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileLikedCars.ascx.cs" Inherits="lib_ui_cars_ProfileLikedCars" %>
<%@ Register Src="~/lib/ui/cars/templates/ProfileLikedCar-Item.ascx" TagPrefix="cars" TagName="ProfileLikedCarItem" %>

<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="h3-subtitle">                
                <a href="<%=Item.Url %>">
                    <%=Item.Ten %>
                </a>
                thích 
                <%if(Pager!=null && Pager.Total > 0){ %>
                    <span class="text-muted"><%=Pager.Total %> xe</span>
                <%} %>
            </div>
            <hr class="hr comment-hr"/>
            <%if(Pager.Total > 0){ %>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <cars:ProfileLikedCarItem runat="server" ID="ProfileLikedCarItem"  Item='<%# Container.DataItem %>'/>
                </ItemTemplate>
            </asp:Repeater>
            <%}
              else
              {%>
              <%=Item.Ten %> chưa thích xe nào
             <% } %>
        </div>
        <div class="col-md-4 profile-info">
        </div>
    </div>
</div>