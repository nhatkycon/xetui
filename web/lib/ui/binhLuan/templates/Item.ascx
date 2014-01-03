<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_binhLuan_templates_Item" %>
<%@ Register Src="~/lib/ui/binhLuan/templates/Item-Big.ascx" TagPrefix="uc1" TagName="ItemBig" %>
<%@ Register Src="~/lib/ui/binhLuan/templates/Item-Small.ascx" TagPrefix="uc1" TagName="ItemSmall" %>
<uc1:ItemBig runat="server" ID="ItemBig" Visible="False" />
<uc1:ItemSmall runat="server" ID="ItemSmall" Visible="False" />
