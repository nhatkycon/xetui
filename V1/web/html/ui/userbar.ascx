﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userbar.ascx.cs" Inherits="html_ui_userbar" %>
<nav class="navbar navbar-default" role="navigation">
  <!-- Brand and toggle get grouped for better mobile display -->
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-0">
      <span class="sr-only">Toggle navigation</span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="#"></a>
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
      <li class="">
              <a href="#">
                  <i class="glyphicon glyphicon-bell"></i>
                  Thông báo
              </a>
          </li>
          <li class="">
              <a href="#">
                  <i class="glyphicon glyphicon-compressed"></i>
                  Tin nhắn
              </a>
          </li>
          <li><a href="#">Link</a></li>
          <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <i class="glyphicon glyphicon-user"></i>
                Cá nhân <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
                <li>
                    <a href="#">
                                        
                        <img class="img-circle img-thumbnail img-avatar-icon-navbar" src="/html/img/baby-icon.jpg"/>
                        nxlinh
                    </a>
                </li>
                <li class="divider"></li>
                <li>
                    <a href="#">
                        <i class="glyphicon glyphicon-list"></i>
                        Danh sách xe
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i class="glyphicon glyphicon-cog"></i>
                        Cài đặt
                    </a>
                </li>
                <li class="divider"></li>
                <li>
                    <a href="#">
                        <i class="glyphicon glyphicon-log-out"></i>
                        Đăng xuất
                    </a>
                </li>
            </ul>
          </li>
    </ul>      
  </div><!-- /.navbar-collapse -->
</nav>