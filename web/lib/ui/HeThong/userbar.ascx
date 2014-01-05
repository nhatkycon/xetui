<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userbar.ascx.cs" Inherits="lib_ui_HeThong_userbar" %>
<%@ Import Namespace="docsoft" %>
<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
    <div class="container">
        
  <!-- Brand and toggle get grouped for better mobile display -->
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-0">
      <span class="sr-only">Toggle navigation</span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="javascript:;"></a>
  </div>

  <!-- Collect the nav links, forms, and other content for toggling -->
  <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-0">
    <%--<ul class="nav navbar-nav">
      <li class="active"><a href="#">Link</a></li>
      <li><a href="#">Link</a></li>
      <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <b class="caret"></b></a>
        <ul class="dropdown-menu">
          <li><a href="#">Action</a></li>
          <li><a href="#">Another action</a></li>
          <li><a href="#">Something else here</a></li>
          <li class="divider"></li>
          <li><a href="#">Separated link</a></li>
          <li class="divider"></li>
          <li><a href="#">One more separated link</a></li>
        </ul>
      </li>
    </ul>--%>
    <ul class="nav navbar-nav navbar-right">
        <li class="notification notibox">
              <a href="/" class="dropdown-toggle" data-toggle="dropdown">
                  <i class="glyphicon glyphicon-bell"></i>
                  Thông báo
                  <span class="notificationBubble" data-total="0"></span>
              </a>
            <ul class="dropdown-menu noti-items">
                
            </ul>
          </li>
          <li class="notification msgbox">
              <a href="/pm/">
                  <i class="glyphicon glyphicon-comment"></i>
                  Tin nhắn
                  <span class="notificationBubble" data-total="0"></span>
              </a>
          </li>
         <li>
                <a href="/my-cars/">
                    <i class="glyphicon glyphicon-list"></i>
                    Danh sách xe
                </a>
            </li>
          <li class="dropdown">
            <a href="/" class="dropdown-toggle" data-toggle="dropdown">
                <i class="glyphicon glyphicon-user"></i>
                Cá nhân <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
                <li>
                    <a href="/user/<%=string.IsNullOrEmpty(User.Username) ? User.ID.ToString() : User.Username %>">
                        <img class="img-circle img-thumbnail img-avatar-icon-navbar" src="/lib/up/users/<%=User.Anh %>"/>
                        <span class="img-avatar-icon-ten">
                            <%=Security.Ten %>                            
                        </span>
                    </a>
                </li>
                <li class="divider"></li>
                <li>
                    <a href="/acc/">
                        <i class="glyphicon glyphicon-cog"></i>
                        Cài đặt
                    </a>
                </li>
                <li class="divider"></li>
                <li class="logoutBtn">
                    <a href="javascript:;" class="">
                        <i class="glyphicon glyphicon-log-out"></i>
                        Đăng xuất
                    </a>
                </li>
            </ul>
          </li>
    </ul>      
  </div><!-- /.navbar-collapse -->
    </div>

</nav>