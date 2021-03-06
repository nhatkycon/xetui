﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navtop.ascx.cs" Inherits="lib_ui_HeThong_navtop" %>
<%@ Import Namespace="docsoft" %>
<br/>
<nav class="navbar navbar-inverse navbar-custom" role="navigation">
  <!-- Brand and toggle get grouped for better mobile display -->
  <div class="container">
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
      <span class="sr-only">Toggle navigation</span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="/">
        <span class="navbar-brand-logo"></span>
        <span class="navbar-brand-intro">
            <span class="visible-xs">Xe và xế</span>
            <span class="hidden-xs">Cộng đồng xe và xế</span>
        </span>
    </a>        
  </div>
  <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
        <%if(!Security.IsAuthenticated()){ %>
        <div class="navbar-form navbar-left">
            <a href="javascript:;" class="btn btn-primary btn-sm showLoginModalBtn" data-toggle="modal" data-target="#loginModal">Đăng nhập</a> 
            <a href="/Register/" class="btn btn-default btn-sm">Đăng ký</a>      
        </div>        
        <%} %>
        <form class="navbar-form navbar-right" action="/search/" id="search" role="search">
            <div class="form-group">
            <input type="text" name="q" class="form-control search-input" placeholder="Tìm kiếm">
            <button type="submit" class="search-submit">
                <i class="glyphicon glyphicon-search"></i>
            </button>
            </div>
        </form>
    </div>      
  </div>
</nav>