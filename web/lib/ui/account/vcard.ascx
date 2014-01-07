<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vcard.ascx.cs" Inherits="lib_ui_account_vcard" %>
<%@ Import Namespace="linh.common" %>
<% var i = 0; %>
<div class="vcard" itemscope="" itemtype="http://schema.org/Person">
    <div class="vcard-pic">
        <a href="<%=Item.Url %>">
            <img class="photo" itemprop="image" src="/lib/up/users/<%=Item.Anh %>" width="100" height="100" alt="">
        </a>
    </div>
    <div class="vcard-info">
        <div class="vcard-username">
            <a href="<%=Item.Url %>" class="url" itemprop="url">
                <span class="fn nickname" itemprop="name">
                    <span class="uname uname-color06">
                        <%=Item.Ten %>
                    </span>
                </span>
            </a>
            <span class="vcard-status">
                <%=Item.SLOnline %>
            </span>
        </div>
        <div class="vcard-note note">
                <%if (Xes.Any()){ %>
                    <span class="vcard-cars">
                    <%if (XeDangLai.Any())
                      { %>
                    Tôi lái
                        <% foreach (var item in XeDangLai)
                           {%>
                            <a href="<%=item.XeUrl %>">
                                <%=item.Ten %>
                            </a>
                            <% i++; %>
                            <%if(i < XeCu.Count-1)
                              { %>
                                và
                            <% } %>
                        <% } %>    
                    <%} %>

                    <% i = 0; %>
                    <%if(XeCu.Any()){ %>
                    (trước đây— 
                        <% foreach (var item in XeCu)
                           {%>
                            <a href="<%=item.XeUrl %>">
                                <%=item.Ten %>
                            </a>
                            <% i++; %>
                            <%if(i < XeCu.Count-1)
                              { %>
                                và
                            <% } %>
                        <% } %>    
                    )
                    <%} %>
                </span>
                <br>
            <%}else{ %>
            <span class="vcard-cars">
                Chưa có xe nào
            </span>
            <br/>
            <%} %>
            <span class="adr" itemprop="address">
                <span title="<%=Item.Tinh_Ten %>">
                    Ở <%=Item.Tinh_Ten %>
                </span>
            </span>
        </div>
    </div>
</div>
