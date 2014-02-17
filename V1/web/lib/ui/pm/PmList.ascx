<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PmList.ascx.cs" Inherits="lib_ui_pm_PmList" %>
<%@ Register Src="~/lib/ui/pm/templates/PmItem.ascx" TagPrefix="uc1" TagName="PmItem" %>
<%if (List != null && List.Any() && Request["subAct"] != "getPmList-Latest")
  { %>
    <div class="pm-item-more"  data-roomId="<%=RoomId %>" data-id="<%=List.First().Id %>">
        <a href="javascript:;" class="btn btn-link">Cũ hơn</a>  
        <hr class="hr comment-hr"/>              
    </div>
<%}%>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:PmItem runat="server" ID="PmItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>
<%if (List != null && List.Any())
  { %>
    <span class="pm-item-lastest" data-roomId="<%=RoomId %>" data-id="<%=List.Last().Id %>"></span>
<%}else{ %>
    <span class="pm-item-lastest" data-roomId="<%=RoomId %>" data-id="<%=FromId %>"></span>
<%} %>