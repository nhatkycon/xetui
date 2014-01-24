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
            <a class="navbar-brand" href="/lib/mod/">
                <span class="logo">XETUI.VN</span>
            </a>            
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Thành viên<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Users/Default.aspx?XacNhan=false">
                                Chưa xác nhận
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Users/Default.aspx">
                                Danh sách
                            </a>
                        </li>                        
                        <li>
                            <a href="/lib/mod/Users/Default.aspx?Active=false">
                                Khóa
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Users/Default.aspx">
                                Top trang chủ
                            </a>
                        </li>
                    </ul>
                </li>               
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Xe<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Cars/Default.aspx">
                                Chưa duyệt
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Cars/Default.aspx">
                                Danh sách
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Cars/Default.aspx">
                                Xe Top
                            </a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Nhóm<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Cars/Default.aspx">
                                Chưa duyệt
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Nhom/Default.aspx">
                                Danh sách
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Top
                            </a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Promoted<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Chưa duyệt
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Danh sách
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Top
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Home Big
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Home Medium
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Promoted/Default.aspx">
                                Home Small
                            </a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Ads<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Adv/Default.aspx">
                                Mới
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Adv/Default.aspx">
                                Top hành trình
                            </a>
                        </li>       
                        <li>
                            <a href="/lib/mod/Adv/Add.aspx">
                                Thêm mới
                            </a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Blog<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/lib/mod/Blog/Default.aspx">
                                Mới
                            </a>
                        </li>
                        <li>
                            <a href="/lib/mod/Blog/Default.aspx">
                                Top hành trình
                            </a>
                        </li>       
                        <li>
                            <a href="/lib/mod/Blog/Default.aspx">
                                Top nhật ký
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