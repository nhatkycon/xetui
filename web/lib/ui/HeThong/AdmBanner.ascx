<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdmBanner.ascx.cs" Inherits="lib_ui_HeThong_AdmBanner" %>
<%@ Import Namespace="docsoft" %>
<div class="navbar-wrapper">
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/">
                <span class="logo">XETUI.VN</span>
            </a>            
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">               
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Quản lý<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Cars/Default.aspx">
                                Xe
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Nhom/Default.aspx">
                                Nhóm
                            </a>
                        </li>
                    </ul>
                </li>
            </ul>            
            <form action="/lib/pages/TimKiem.aspx" class="navbar-form navbar-left">
                <div class="form-group">
                    <input name="q" type="text" value="<%=Request["q"] %>" class="form-control">
                </div>
                <button type="submit" class="btn btn-default globalSearchBtn"><i class="glyphicon glyphicon-search"></i></button>
            </form>
            <ul class="nav navbar-nav navbar-right">
              <li>
                  <%if(Security.IsAuthenticated()){ %>
                  
                  <%}else{ %>
                  <a href="javascript:;" class="loginbtn">
                      Đăng nhập
                  </a>
                  <%} %>
                  
              </li>
            <%if(Security.IsAuthenticated()){ %>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><%=Security.Username %> <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li>
                        <a href="mailto:linh_net@yahoo.com">
                            <i class="glyphicon glyphicon-info-sign"></i> Hỗ trợ
                        </a>
                    </li>
                  <li class="divider"></li>
                    <li>
                        <a href="javascript:;" class="logoutbtn">
                            <i class="glyphicon glyphicon-log-out"></i> Thoát
                        </a>
                    </li>
                </ul>
              </li>
            <%} %>
            </ul>            
        </div>
    </div>
</div>