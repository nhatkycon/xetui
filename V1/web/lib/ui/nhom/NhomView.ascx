<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NhomView.ascx.cs" Inherits="lib_ui_nhom_NhomView" %>
<%@ Register Src="~/lib/ui/nhom/Nhom-Info.ascx" TagPrefix="uc1" TagName="NhomInfo" %>
<%@ Register Src="~/lib/ui/nhom/Nhom-Header.ascx" TagPrefix="uc1" TagName="NhomHeader" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/List.ascx" TagPrefix="uc1" TagName="List" %>

<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <uc1:NhomHeader runat="server" ID="NhomHeader" />
                </div>
                <div class="col-md-6">
                    <h3 class="h3-subtitle">
                        <a href="<%=Item.Url %>blogs/">
                            Blog
                        </a>                        
                    </h3>
                    <uc1:List runat="server" ID="ListBlogForNhom" />
                </div>
                <div class="col-md-6">
                    <h3 class="h3-subtitle">
                        <a href="<%=Item.Url %>forum/">
                            Thảo luận
                        </a>                        
                    </h3>
                    <uc1:List runat="server" ID="ListThreadForNhom" />
                </div>
            </div>          
        </div>
        <div class="col-md-4">
            <uc1:NhomInfo runat="server" ID="NhomInfo" />
        </div>
    </div>    
</div>