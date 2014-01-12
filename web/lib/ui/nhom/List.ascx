<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_nhom_List" %>
<%@ Register Src="~/lib/ui/nhom/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>
<div class=" padding-20">
    <div class="nhomList-header">
        <div class="pull-right">
            <div class="btn-group">
              <button type="button" data-sort="1" class="btn btn-default btn-xs btn-sort">Mới nhất</button>
              <button type="button" data-sort="2" class="btn btn-default btn-xs btn-sort">Đông nhất</button>
              <button type="button" data-sort="3" class="btn btn-default btn-xs btn-sort">Tên</button>
            </div>
        </div>
        <span class="h3-subtitle">Cộng đồng</span>
        <input class="form-control" placeholder="Tìm kiếm nhóm"/>
    </div>
    <div class="nhomList-box">
        <table class="table table-hover">
            <tbody>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <uc1:Item runat="server"  ID="Item" Item='<%# Container.DataItem %>'/>
                    </ItemTemplate>
                </asp:Repeater>        
            </tbody>
        </table>    
    </div>    
</div>

<script src="/lib/js/jqueryLib/jquery.tablesorter.min.js"></script>
