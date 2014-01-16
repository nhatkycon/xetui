<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="lib_ui_hangXe_LeftMenu" %>
<%@ Register Src="~/lib/ui/hangXe/templates/LeftMenu-Item.ascx" TagPrefix="uc1" TagName="LeftMenuItem" %>

<div class="nav-list">
    <div class="nav-index">
        <a href="/" class="nav-item">
            Top
        </a>
        <a href="/" class="nav-item">
            Chọn lọc
        </a>
        <a href="/" class="nav-item">
            Xe mới
        </a>
        <a href="javascript:;" data-toggle="collapse" data-target="#nav-list-more" class="nav-item nav-list-more-btn ">
           <i class="glyphicon glyphicon-minus-sign"></i> Hãng xe
        </a>
    </div>
    <div  class="nav-list-more-box">
        <div  class="collapse" id="nav-list-more" >
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:LeftMenuItem runat="server" ID="LeftMenuItem" Item='<%# Container.DataItem %>'/>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>