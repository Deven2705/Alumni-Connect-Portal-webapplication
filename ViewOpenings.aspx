<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOpenings.aspx.cs" MasterPageFile="~/Menu.Master" Inherits="AlumniConnect.ViewOpenings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnViewProfile(recordId) {
            debugger;
            location.href = "ViewProfile.aspx?RecordId=" + recordId;
        }

        function fnOpenCloseDescription(recordId) {
            
            var element = document.getElementById(recordId + "_ico_desc");
            if (element.classList.contains("bi-file-plus-fill")) {
                element.classList.replace("bi-file-plus-fill", "bi-file-minus-fill");
                document.getElementById(recordId + "_desc").style.display = "block";
            }
            else {
                element.classList.replace("bi-file-minus-fill", "bi-file-plus-fill");
                document.getElementById(recordId + "_desc").style.display = "none";
            }
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
        <h1>View Opening / Intern</h1>
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
                <% if (lstOpenings != null)
                    { %>
                <div class="list-group">
                    <% for (int i = 0; i < lstOpenings.Count; i++)
                        { %>
                    <a href="#"  class="list-group-item list-group-item-action" style="text-align: left;">
                        <div class="row">
                            <div class="col-md-1">
                                <%--<asp:Image ImageUrl="<%=lst[i].imgUrl %>" runat="server" />--%>
                                <img src="../content/images/profile/<%=lstOpenings[i].imgUrl %>" onclick="fnViewProfile('<%=lstOpenings[i].recordId %>')" height="80" width="80" style="border-radius: 50%; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" />
                            </div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-12" style="font-weight: bold; font-size: 18px;"><span class="lbl-blog-title"><%= lstOpenings[i].createdBy %></span></div>
                                    <div class="col-md-12">
                                        <span class="bi bi-email" style="font-size: 24px;"></span>
                                        Send resume to : <span class="lbl-opening-send-resume"><%= lstOpenings[i].email%></spa>
                                    </div>
                                    <div class="col-md-12">
                                        <span style="font-weight:500;">
                                        <%= lstOpenings[i].title %></span><i id="<%= lstOpenings[i].recordId %>_ico_desc" class="bi bi-file-plus-fill" style="color:dodgerblue;" onclick="fnOpenCloseDescription('<%= lstOpenings[i].recordId %>')"></i>
                                    </div>
                                    <div class="col-md-12" id="<%= lstOpenings[i].recordId %>_desc" style="display:none;">
                                        <span style="padding-left: 20px;">
                                            <%= lstOpenings[i].description %></span>
                                    </div>
                                    <div class="col-md-6 lbl-description">
                                        <span class="bi bi-calendar" style="font-size: 16px;"></span>
                                        <%= lstOpenings[i].createdOn %>
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
