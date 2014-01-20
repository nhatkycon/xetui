<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutUs.ascx.cs" Inherits="lib_ui_HeThong_AboutUs" %>
<div class="padding-20">
    <div class="row">
        <div class="col-md-3">
            <div class="list-group">
                <a class="list-group-item" href="#About-us">
                    <span class="list-group-item-text">
                        Giới thiệu
                    </span>
                </a>
                <a class="list-group-item" href="#Supports">
                    <span class="list-group-item-text">
                        Hỗ trợ
                    </span>
                </a>
                <a class="list-group-item" href="#Rules">
                    <span class="list-group-item-text">
                        Quy định
                    </span>
                </a>
                <a class="list-group-item" href="#Ads">
                    <span class="list-group-item-text">
                        Quảng cáo
                    </span>
                </a>
            </div>
        </div>
        <div class="col-md-9">
            <a name="About-us"></a>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="panel-title">
                        Giới thiệu
                    </span>
                </div>
                <div class="panel-body">
                    <%=AboutUs %>
                </div>
            </div>
            <a name="Supports"></a>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="panel-title">
                        Hỗ trợ
                    </span>
                </div>
                <div class="panel-body">
                    <%=Support %>
                </div>
            </div>
            <a name="Rules"></a>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="panel-title">
                        Quy định
                    </span>
                </div>
                <div class="panel-body">
                    <%=Rules %>
                </div>
            </div>
            <a name="Ads"></a>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="panel-title">
                        Quảng cáo
                    </span>
                </div>
                <div class="panel-body">
                    <%=Ads %>
                </div>
            </div>
        </div>
    </div>
</div>
