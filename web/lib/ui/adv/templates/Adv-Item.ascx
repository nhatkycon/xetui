<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adv-Item.ascx.cs" Inherits="lib_ui_adv_templates_Adv_Item" %>
<div class="adv-item-box">
    <%if (Item.Flash)
      { %>
      <div class="adv-flash-box">
          <%= Item.NoiDung %>          
      </div>
    <% }else{ %>
    <%= Item.NoiDung %>
    <%} %>
</div>