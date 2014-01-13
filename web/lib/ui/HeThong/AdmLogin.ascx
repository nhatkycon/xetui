<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdmLogin.ascx.cs" Inherits="lib_ui_HeThong_AdmLogin" %>
<style type="text/css">
    body {
    padding-top: 40px;
    padding-bottom: 40px;
    background-color: #f5f5f5;
    }

    .form-signin {
    max-width: 280px;
    padding: 19px 29px 29px;
    margin: 0 auto 20px;
    background-color: #fff;
    border: 1px solid #e5e5e5;
    -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
            border-radius: 5px;
    -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
        -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            box-shadow: 0 1px 2px rgba(0,0,0,.05);
    }
    .form-signin .form-signin-heading,
    .form-signin .checkbox {
    margin-bottom: 10px;
    }
    .form-signin input[type="text"],
    .form-signin input[type="password"] {
    font-size: 16px;
    height: auto;
    margin-bottom: 15px;
    padding: 7px 9px;
    }

</style>

    <div class="form-signin">
        <h2 class="form-signin-heading">Đăng nhập</h2>
            <asp:TextBox ID="Username" runat="server" CssClass="input-block-level form-control"></asp:TextBox>
            <asp:TextBox ID="Pwd" TextMode="Password" CssClass="input-block-level form-control" runat="server"></asp:TextBox>
        <label class="checkbox">
            Ghi nhớ
            <asp:CheckBox runat="server" ID="ckb"/>
        </label>
            <div id="msg" runat="server" Visible="False" class="alert alert-warning">
            Username và mật khẩu không hợp lệ                    
        </div>
        <asp:LinkButton ID="btnLogin" CssClass="btn btn-large btn-primary" runat="server" OnClick="btnLogin_Click">Đăng nhập</asp:LinkButton>
    </div>