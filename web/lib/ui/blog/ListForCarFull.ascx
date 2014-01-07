<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListForCarFull.ascx.cs" Inherits="lib_ui_blog_ListForCarFull" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="templates/ForCar-ItemFull.ascx" tagname="ForCarItemFull" tagprefix="uc1" %>
<%@ Register TagPrefix="car" TagName="viewcarslider" Src="~/lib/ui/cars/view-car-slider.ascx" %>
<%@ Register TagPrefix="car" TagName="ViewCarInfo" Src="~/lib/ui/cars/view-car-info-nano.ascx" %>

<car:viewcarslider ID="viewCarSlider" runat="server"/>
<div class="row car-view-body">
    <div class="col-md-8">
        <div class="padding-20">
            <div class="h3-subtitle">
                <%if(Item.NguoiTao == Security.Username){ %>
                    <a href="<%=Item.XeUrl %>blogs/add/" class="btn btn-primary pull-right">
                        <i class="glyphicon glyphicon-plus"></i> Thêm
                    </a>
                <%} %>
                <a href="<%=Item.XeUrl %>/blogs/">
                    Nhật ký hành trình
                </a>
                <%if(Pager!=null && Pager.Total > 0){ %>
                <span class="text-muted"><%=Pager.Total %> bài</span>
                <%} %>
            </div>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:ForCarItemFull ID="ForCar1" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="col-md-4">
        <car:ViewCarInfo ID="ViewCarInfo" runat="server"/>        
    </div>
</div>