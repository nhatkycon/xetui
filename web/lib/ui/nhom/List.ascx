<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_nhom_List" %>
<%@ Register Src="~/lib/ui/nhom/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>
<div class=" padding-20">
    <div class="nhomList-header">
        <div class="pull-right">
            <div class="btn-group sortGroupBtn">
              <button type="button" data-sort="data-id" class="btn btn-default btn-xs btn-sort">Mới nhất</button>
              <button type="button" data-sort="data-member" class="btn btn-default btn-xs btn-sort">Đông nhất</button>
              <button type="button" data-sort="data-name" class="btn btn-default btn-xs">Tên</button>
              <a href="/group/add/"  class="btn btn-primary btn-xs">
                  Tạo cộng đồng
              </a>
            </div>
        </div>
        <span class="h3-subtitle">Cộng đồng</span>        
    </div>
    <div class="form-group">
        <input class="form-control" placeholder="Tìm kiếm"/>
    </div>      
    <div class="nhomList-box">
        <table class="table table-hover nhomList-box-table">
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

<script src="/lib/js/jqueryLib/jquery.tinysort.min.js"></script>
