<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListBlogForNhomFull.ascx.cs" Inherits="lib_ui_blog_ListBlogForNhomFull" %>
<%@ Register TagPrefix="uc1" TagName="NhomInfo" Src="~/lib/ui/nhom/Nhom-Info.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ForNhomItemFull" Src="~/lib/ui/blog/templates/ForNhom-Blog-Item-Full.ascx" %>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8">
            <div class="h3-subtitle">
                <a href="/group/">Cộng đồng</a>&nbsp; &gt;
                <a href="<%=Item.Url %>">
                    <%=Item.Ten %>
                </a>&nbsp; &gt;
                <a href="<%=Item.Url %>blogs/">
                    Blog
                </a>                
            </div>  
            <%if(Item.Joined){ %>    
            <div>
                <a href="<%=Item.Url %>/blogs/add/" class="btn btn-primary">
                    <i class="glyphicon glyphicon-plus">
                    </i>
                        Viết blog
                </a>
            </div>
            <%} %>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:ForNhomItemFull ID="ForNhomItemFull1" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-4">
            <uc1:NhomInfo runat="server" ID="NhomInfo" />
        </div>
    </div>    
</div>