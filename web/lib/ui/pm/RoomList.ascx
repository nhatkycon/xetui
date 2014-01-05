<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoomList.ascx.cs" Inherits="lib_ui_pm_RoomList" %>
<%@ Register Src="~/lib/ui/pm/templates/RoomItem.ascx" TagPrefix="uc1" TagName="RoomItem" %>

<div class="list-group PmRooms">
  <div class="list-group-item">
      <strong>
            Tin nhắn          
      </strong>
  </div>
  <asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:RoomItem runat="server" ID="RoomItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>  
</div>
 
