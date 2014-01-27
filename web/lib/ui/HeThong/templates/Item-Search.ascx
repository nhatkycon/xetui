<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Search.ascx.cs" Inherits="lib_ui_HeThong_templates_Item_Search" %>
<%@ Import Namespace="linh.common" %>
<div class="searchRs-item">    
    <a href="<%=Item.Url %>">
        <span class="badge">
            <%=Item.Kieu %>
        </span>
        <%=Item.Ten %>
    </a>
    <%=Lib.Rutgon(Lib.NoHtml(Item.NoiDung), 200)%>
</div>
<hr class="hr comment-hr"/>