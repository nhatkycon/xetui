<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myCars.ascx.cs" Inherits="lib_ui_cars_myCars" %>
<%@ Register src="~/lib/ui/cars/templates/carcard-item.ascx" tagPrefix="temp" tagName="carCardItem" %>
<div class="padding-20">
    <ul class="nav nav-tabs">
      <li class="active"><a href="#my-cars" data-toggle="tab">Xe của tôi</a></li>
      <li><a href="#liked-cars" data-toggle="tab">Xe tôi thích</a></li>
    </ul>
    <div class="tab-content">
      <div class="tab-pane active" id="my-cars">
          <div class="help-block">
              <a class="btn btn-primary btn-lg" href="/cars/add/">
                  <i class="glyphicon glyphicon-plus"></i>
                  Thêm xe
              </a>
          </div>
          <hr/>
          <div class="carcard-group">
            <asp:Repeater runat="server" ID="currentCars">
                <ItemTemplate>
                    <temp:carCardItem ID="carCardItem" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>       
            <asp:Repeater runat="server" ID="formerCars">
                <ItemTemplate>
                    <temp:carCardItem ID="carCardItem" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater> 
          </div>        
      </div>
      <div class="tab-pane" id="liked-cars">
        <asp:Repeater runat="server" ID="likedCars">
            <ItemTemplate>
                <temp:carCardItem ID="carCardItem" runat="server" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>   
      </div>
    </div>
</div>
