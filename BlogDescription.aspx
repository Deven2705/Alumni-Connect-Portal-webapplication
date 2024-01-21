
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogDescription.aspx.cs" MasterPageFile="~/Menu.Master" Inherits="AlumniConnect.BlogDescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnViewProfile(recordId) {
            //debugger;
            location.href = "ViewProfile.aspx?RecordId=" + recordId;
        }

        
    </script>

    <style>
        .lbl-blog-title {
            color: #333;
            font-weight: bold;
            font-size: 18px;
        }

        .lbl-blog-content {
            font-size: 14px;
            color: #333;
            text-align: left;
        }

        .lbl-opening-send-resume {
            color: dodgerblue;
            text-decoration:underline;
        }

        .lbl-description {
            font-size: 12px;
            color: lightgray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-bottom: 10px; text-align: center; color: #003366;">
        <br />
        <h1>View Blogs</h1>
    </div>
    <br />
    <hr />

    <div class="col-md-12" style="padding-top: 40px; padding-left: 10%; padding-right: 10%; display: block">
        <%--col-md-12--%>
        <div style="padding-bottom: 10px; text-align: center; font-size: 24px;">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

        <div class="row" style="margin-right: 15px; margin-left: 15px;">
            <%--<div class="col-md-3" style="padding-top: 80px; text-align: center;">
            </div>--%>
            <div class="col-md-12" style="padding-top: 40px; padding-bottom: 20px; text-align: center;">
                <% if (lstBlogs != null)
                    { %>
                <div class="list-group">
                    <% for (int i = 0; i < lstBlogs.Count; i++)
                        { %>
                    <a href="#"  class="list-group-item list-group-item-action" style="text-align: left;">
                        <div class="row">
                            <div class="col-md-1">
                                <%--<asp:Image ImageUrl="<%=lst[i].imgUrl %>" runat="server" />--%>
                                <img src="../content/images/profile/<%=lstBlogs[i].imgUrl %>" onclick="fnViewProfile('<%=lstBlogs[i].createdById %>')" height="80" width="80" style="border-radius: 50%; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" />
                            </div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-12" style="font-weight: bold; font-size: 18px;"><span class="lbl-blog-title"><%= lstBlogs[i].title %></span></div>
                                    <div class="col-md-12" style="font-weight: bold; font-size: 18px;"><span style="font-size:14px;color:lightgray;">by <%= lstBlogs[i].createdBy %></span></div>                                    
                                    <div class="col-md-12 lbl-description">
                                        <span class="bi bi-calendar" style="font-size: 16px;"></span>
                                        <%= lstBlogs[i].createdOn %>
                                    </div>
                                    <div class="col-md-12" id="<%= lstBlogs[i].recordId %>_desc">
                                        <span style="padding-left: 20px;">
                                            <%= lstBlogs[i].description %></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
