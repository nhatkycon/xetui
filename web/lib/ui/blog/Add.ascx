<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_blog_Add" %>
<%@ Register TagPrefix="HeThong" TagName="UploaderV1" Src="~/lib/ui/HeThong/UploaderV1.ascx" %>
<div class="padding-20 blog-add-pnl">
    <div class="h3-subtitle">
    <% switch (Item.Loai)
       {%>
    <%case 1: %>
        <a href="<%=Item.Profile.Url %>">
            <%=Item.Profile.Ten %>
        </a>&nbsp; &gt;
        <a href="<%=Item.Profile.Url %>/blogs/">
            Blog
        </a>
    <% break; %>
    
    <%case 2: %>
        <a href="<%=Item.Xe.XeUrl %>">
            Xe
        </a>&nbsp; &gt;
        <a href="<%=Item.Xe.XeUrl %>blogs/">
            Hành trình
        </a>
    <% break; %>
    
    <%case 3: %>
        <a href="/group/">
            Cộng đồng
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>">
            <%=Item.Nhom.Ten %>
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>blogs/">
            Blog
        </a>&nbsp; &gt;
        Viết blog
    <% break; %>
    <%case 4: %>
        <a href="/group/">
            Cộng đồng
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>">
            <%=Item.Nhom.Ten %>
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>forum/">
            Thảo luận
        </a>&nbsp; &gt;
        Viết thảo luận mới
    <% break; %>
    <%case 5: %>
        <a href="/group/">
            Cộng đồng
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>">
            <%=Item.Nhom.Ten %>
        </a>&nbsp; &gt;
        <a href="<%=Item.Nhom.Url %>aq/">
            Hỏi đáp
        </a>&nbsp; &gt;
        Đặt câu hỏi
    <% break; %>
    <% } %>
    </div>
    <hr class="hr comment-hr"/>
    <form class="form-horizontal blog-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.Id %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <input type="hidden" name="PID_ID" class="PID_ID"  value="<%=Item.PID_ID %>"/>
        <input type="hidden" name="Loai" class="Loai"  value="<%=Item.Loai %>"/>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tiêu đề</label>
            <div class="col-sm-10">
                <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tiêu đề blog">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-12">
            <textarea class="form-control NoiDung" name="NoiDung" id="NoiDung" rows="10"><%=Item.NoiDung %></textarea>                
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                <%if(Item.Id!=0){ %>
                    <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                <%} %>
                <br/><br/>
                <p class="alert alert-danger" style="display: none;"></p>
                <p class="alert alert-success" style="display: none;"></p>
            </div>
        </div>
    </form> 
    <HeThong:UploaderV1 runat="server" ID="UploaderV1" />
</div>
<script id="model-item" type="text/x-jquery-tmpl"> 
    <option value="${ID}">${Ten}</option> 
</script>
<%if(!string.IsNullOrEmpty(Id)){ %>
    <script>
        $(function () {
            
        });
    </script>
<%} %>