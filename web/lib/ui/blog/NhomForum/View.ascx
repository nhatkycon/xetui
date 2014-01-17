<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_blog_NhomForum_View" %>
<%@ Register TagPrefix="uc1" TagName="NhomInfo" Src="~/lib/ui/nhom/Nhom-Info.ascx" %>
<%@ Register Src="~/lib/ui/nhom/Nhom-Header-Forum.ascx" TagPrefix="uc1" TagName="NhomHeaderForum" %>
<%@ Register TagPrefix="binhLuan" TagName="ForumReplyList" Src="~/lib/ui/binhLuan/ForumReplyList.ascx" %>
<%@ Register Src="~/lib/ui/blog/NhomForum/templates/Item-View.ascx" TagPrefix="binhLuan" TagName="ItemView" %>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <uc1:NhomHeaderForum runat="server" ID="NhomHeaderForum" />
            <hr class="hr comment-hr"/>
            <binhLuan:ItemView runat="server" ID="ItemView" />
            <a name="comments"></a>
            <binhLuan:ForumReplyList runat="server" ID="BinhLuanList" /> 
        </div>
        <div class="col-md-4">
            <uc1:NhomInfo runat="server" ID="NhomInfo" />
        </div>
    </div>    
</div>