<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view-car-slider.ascx.cs" Inherits="lib_ui_cars_view_car_slider" %>
<% var i = 0; %>
<div class="car-view-images">
    <div id="carousel-example-generic" class="carousel slide">
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
                <img width="100%" src="/lib/up/car/<%=item.FileAnh %>?w=120"
                    class="adaptiveImage"
                    data-src-xs="/lib/up/car/<%=item.FileAnh %>?w=320"
                    data-src-md="/lib/up/car/<%=item.FileAnh %>?w=960"
                     alt=""/>
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

<script>
    //$('.carousel-inner').swipe({
    //    //Generic swipe handler for all directions
    //    swipeLeft: function (event, direction, distance, duration, fingerCount) {
    //        $(this).parent().carousel('prev');
    //    },
    //    swipeRight: function () {
    //        $(this).parent().carousel('next');
    //    },
    //    //Default is 75px, set to 0 for demo so any distance triggers swipe
    //    threshold: 0
    //});
    
    $('#carousel-example-generic').bind('slide', function (e) {
        console.log($(e.relatedTarget));
        setTimeout(function () {
            var next_h = $(e.relatedTarget).outerHeight();
            $('.carousel').css('height', next_h);
            console.log(next_h);
        }, 10);
    });
</script>