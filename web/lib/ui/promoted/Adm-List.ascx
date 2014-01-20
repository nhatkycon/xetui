<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adm-List.ascx.cs" Inherits="lib_ui_promoted_Adm_List" %>
<%@ Register src="~/lib/ui/promoted/templates/Adm-Item.ascx" tagPrefix="temp" tagName="AdminItem" %>
<div class="ModuleHeader">
    <div class="panel panel-default">
        <div class="panel-body" role="form">
            <div class="form-inline">
                <div class="form-group pull-left">
                    <a href="/lib/mod/Promoted/Add.aspx" class="btn btn-primary">Thêm</a>      
                    <a href="/lib/mod/Promoted/" class="btn btn-success">
                        <i class="glyphicon glyphicon-refresh"></i>
                    </a>
                </div>
                <div class="form-group pull-right">
                    <a href="javascript:;" class="btn btn-default" data-toggle="collapse" data-target="#filtering">
                        <i class="glyphicon glyphicon-search"></i>
                    </a>
                </div>
            </div>
        </div>               
    </div>
    <div id="filtering" class="panel panel-default collapse">
        <div class="panel-body">
            <div class="form-inline">
                <div class="row">
                    <div class="col-sm-2">
                        <div class="form-group">
                            <select name="Loai" class="form-control Loai">
                                <option value="0">--</option>
                                <option value="1">
                                    Xe Top
                                </option>
                                <option value="2">
                                    Xe Home Big
                                </option>
                                <option value="3">
                                    Xe Home Medium
                                </option>
                                <option value="4">
                                    Xe Home Small
                                </option>
                                <option value="5">
                                    Xe View
                                </option>
                                <option value="10">
                                    Other
                                </option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <div id="TuNgayPicker" class="input-append date input-group DatePickerInput">
                                <input 
                                    data-format="dd/MM/yyyy" 
                                    class="form-control TuNgay" 
                                    name="TuNgay" 
                                    type="text"/>
                                <span class="add-on input-group-addon">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                    </i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <div id="DenNgayPicker" class="input-append date input-group DatePickerInput">
                                <input 
                                    data-format="dd/MM/yyyy" 
                                    class="form-control DenNgay" 
                                    name="DenNgay" 
                                    type="text"/>
                                <span class="add-on input-group-addon">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                    </i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="pull-right">
                            <div class="input-group">
                              <input name="q" type="text" value="<%=Request["q"] %>" class="form-control">
                              <div class="input-group-btn">
                                <a class="btn btn-default searchBtn">
                                    <i class="glyphicon glyphicon-search"></i>
                                </a>                                
                              </div>
                            </div>            
                        </div>                    
                    </div>
                </div>   
            </div>            
        </div>
    </div>
</div> 
<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                #
            </th>
            <th class="hidden-xs">
                Ảnh
            </th>
            <th class="">
                Tên
            </th>
            <th class="">
                Loại
            </th>
            <th class="hidden-xs">
                Hạn
            </th>
            <th class="hidden-xs">
                Clik-View
            </th>
            <th class="hidden-xs">
                Ngày tạo
            </th>
            <th class="hidden-xs">
                Duyệt
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <temp:AdminItem runat="server" ID="AdmItem1" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>   
</table>   
<% if(Pager!= null){ %> 
<ul class="pagination">
    <%=Pager.Paging %>    
</ul>
<%} %>