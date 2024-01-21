<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEvents.aspx.cs" MasterPageFile="~/Menu.Master" Inherits="AlumniConnect.ViewEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnViewProfile(recordId) {
            //debugger;
            location.href = "ViewProfile.aspx?RecordId=" + recordId;
        }

        //function fnOpenCloseDescription(recordId) {

        //    var element = document.getElementById(recordId + "_ico_desc");
        //    if (element.classList.contains("bi-file-plus-fill")) {
        //        element.classList.replace("bi-file-plus-fill", "bi-file-minus-fill");
        //        document.getElementById(recordId + "_desc").style.display = "block";
        //    }
        //    else {
        //        element.classList.replace("bi-file-minus-fill", "bi-file-plus-fill");
        //        document.getElementById(recordId + "_desc").style.display = "none";
        //    }
        //}

    </script>

    <style>
        .lbl-blog-title {
            color: #333;
            font-weight: bold;
            font-size: 22px;
        }

        .lbl-blog-content {
            font-size: 14px;
            color: #333;
            text-align: left;
        }

        .lbl-opening-send-resume {
            color: dodgerblue;
            text-decoration: underline;
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
        <h1>Upcoming Events</h1>
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
                <% if (lstEvents != null)
                    { %>
                <% for (int i = 0; i < lstEvents.Count; i++)
                    { %>
                <div class="row" style="text-align:center;">
                    <%if (!string.IsNullOrEmpty(Convert.ToString(lstEvents[i].imgUrl)))
                        { %>
                    <div class="col-md-12">
                        <img src="../content/images/event/<%=lstEvents[i].imgUrl %>" height="350" width="300" style=" box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" />
                    </div>
                    <%} %>
                    <div class="col-md-12" style="padding-top:20px; ">
                        <span class="lbl-blog-title"><%=lstEvents[i].title %></span>
                    </div>
                    <div class="col-md-12">
                        <span><%=lstEvents[i].description %></span>
                    </div>
                   
                    <%--<div class="col-md-6">
                            <span><%=lstEvents[i].description %></span>
                        </div>--%>
                </div>
                 <hr />
                <%}
                    } %>
            </div>
        </div>
    </div>
</asp:Content>

