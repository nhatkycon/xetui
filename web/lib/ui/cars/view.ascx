<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view.ascx.cs" Inherits="lib_ui_cars_view" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/binhLuan/List.ascx" TagPrefix="binhLuan" TagName="List" %>

<% var i = 0; %>
<div class="car-view-images">
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <% foreach (var item in Item.Anhs)
           {%>
            <li data-target="#carousel-example-generic" data-slide-to="<%=i %>" class="<%=i==0 ? "active" : "" %>"></li>  
            <% i++; %>
        <% } %>           
      </ol>
      <!-- Wrapper for slides -->
      <% i = 0; %>
      <div class="carousel-inner">
        <% foreach (var item in Item.Anhs)
           {%>
            <div class="item <%=i==0 ? "active" : "" %>">
                <img width="100%" src="/lib/up/car/<%=item.FileAnh %>" alt=""/>
            </div>
            <% i++; %>
        <% } %>
      </div>
      <!-- Controls -->
      <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
      </a>
      <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
      </a>
    </div>
</div>
<div class="row car-view-body">
    <div class="col-md-6">
        <div class="padding-20">
            <div class="car-view-author-pnl">
                <%=Item.Member.Vcard %>
            </div>
            <h3 class="car-view-intro-title">Về chiếc xe của tôi</h3>
            <div class="car-view-intro">
                <%=Item.GioiThieu %>
            </div>
            <hr/>
        </div>
    </div>
    <div class="col-md-6">
        <div class="car-view-infobox">
            <div class="car-view-breadcumb">
                <ol class="breadcrumb">
                  <li><a href="/cars/">Xe</a></li>
                  <li><a href="/cars/<%=Item.HANG_Ten %>/"><%=Item.HANG_Ten %></a></li>
                  <li><a href="/cars/<%=Item.HANG_Ten %>/<%=Item.MODEL_Ten %>/"><%=Item.MODEL_Ten %></a></li>
                </ol>
            </div>
            <h1 class="car-view-caption">
                <%=Item.Ten %>                
            </h1>
            <div class="row car-view-stat">
                <div class="col-md-8">
                    <div class="car-view-stat-item">
                        <span class="car-view-stat-item-num car-view-stat-item-num-drive">
                            <%=Item.TotalComment %>
                        </span><br/>
                        Bình luận
                    </div>
                    <div class="car-view-stat-item">
                        <span class="car-view-stat-item-num car-view-stat-item-num-overdrive">
                            <%=Item.TotalLike %>
                        </span><br/>
                        Thích
                    </div>
                    <a href="<%=Item.XeUrl %>Blog/" class="car-view-stat-item">
                        <span class="car-view-stat-item-num car-view-stat-item-num-blog">
                            <%=Item.TotalBlog %>
                        </span><br/>
                        Nhật ký
                    </a>
                </div>
                <div class="col-md-4 car-view-summary">
                    <%=Item.TotalView %> người thăm
                </div>
            </div>
            <div class="car-view-buttons">
                <div class="pull-right">
                    <a href="javascript:;" class="btn btn-link reportBtn">
                        Báo xe đểu
                    </a>    
                </div>
                <%if(!Item.Liked){ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-primary xeLikedBtn">
                    <i class="glyphicon glyphicon-star-empty"></i>
                    Thích
                </a>
                <%}else{ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-default xeUnLikedBtn">
                    <i class="glyphicon glyphicon-star-empty"></i>
                    Đã thích
                </a>
                <%} %>
                &nbsp;
                <a href="javascript:;" data-user="<%=Item.NguoiTao %>" class="btn btn-warning pmBtn">
                    Nhắn tin
                </a>                
            </div>
        </div>
        <binhLuan:List runat="server" ID="BinhLuanList" />
    </div>
</div>