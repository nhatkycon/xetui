<%@ Control Language="C#" AutoEventWireup="true" CodeFile="promotedCars.ascx.cs" Inherits="lib_ui_cars_promotedCars" %>
<%@ Register TagPrefix="cars" TagName="promotedItem" Src="~/lib/ui/cars/templates/promoted-item.ascx" %>
<div class="promotedCars hidden-xs">
    <div class="row">
        <div class="col-sm-2">
            <a href="#" class="car-promoted-item">
                <img class="car-img" src="/html/img/add.png"/>  
                <span class="car-caption">
                    Đăng xe của bạn lên đây
                </span>          
            </a>
        </div>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <cars:promotedItem runat="server" ID="ProfileLikedCarItem"  Item='<%# Container.DataItem %>'/>
            </ItemTemplate>
        </asp:Repeater>
    </div>   
</div>