<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PmBox.ascx.cs" Inherits="lib_ui_pm_PmBox" %>
<%@ Register Src="~/lib/ui/pm/PmList.ascx" TagPrefix="uc1" TagName="PmList" %>
<div class="panel PmBoxPnl">
    <div class="panel-heading">
        
    </div>
    <div class="panel-body">
        <div class="PmList">
            <uc1:PmList runat="server" ID="PmList" />
            <span class="PmList-bottom"></span>
        </div>        
    </div>
    <div class="panel-footer PmPost">
        <textarea name="txt" class="form-control txt" rows="3"></textarea>
        <div class="PmPost-Buttons">
            <div class="pull-right">
                <button data-id="<%=Id %>" data-toUser="<%=ToUser %>" class="btn btn-primary btn-lg btnSendPm">Gửi</button>
            </div>
        </div>
    </div>
</div>



