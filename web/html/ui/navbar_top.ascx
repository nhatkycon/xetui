<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navbar_top.ascx.cs" Inherits="html_ui_navbar_top" %>
<nav class="navbar navbar-default navbar-custom" role="navigation">
  <!-- Brand and toggle get grouped for better mobile display -->
  <div class="container">
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
      <span class="sr-only">Toggle navigation</span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="#">Boostp</a>        
  </div>
  <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
        <p class="navbar-text">
            Signed in as Mark Otto        
        </p>
        <div class="navbar-form navbar-left">
            <a href="#" class="btn btn-primary">Yes</a> <a href="#" class="btn btn-default">No</a>      
        </div>
        <form class="navbar-form navbar-right" id="search" role="search">
            <div class="form-group">
            <input type="text" class="form-control search-input" placeholder="Tìm kiếm">
            <button type="submit" class="search-submit">
                <i class="glyphicon glyphicon-search"></i>
            </button>
            </div>
        </form>
    </div>      
  </div>

</nav>