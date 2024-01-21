
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBraodcast.aspx.cs" MasterPageFile="~/Menu.Master" Inherits="AlumniConnect.ViewBraodcast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnUpdateBoadcast(recordId, status) {
            $.ajax({
                type: "POST",
                headers: "",
                contentType: "application/json; charset=utf-8",
                url: "ViewBraodcast.aspx/UpdateBroadcast",
                data: '{"recordId":"' + recordId + '","status":"' + status + '"}',
                //data: '',
                dataType: "json",
                async:false,
                success: function (data) {
                    debugger;
                    if (data != null && data != undefined && data != "") {
                        if (data.d != null && data.d != undefined && data.d != "") {
                            if (data.d.errFlag === "N") {
                                alert("Success");
                            }
                            else if (data.d.errFlag === "Y") {
                                alert(data.d.errDesc);
                            }
                        }
                        else {
                            alert("Something went wrong1");
                        }
                    }
                    else {
                        alert("Something went wrong3");
                    }
                },
                error: function (result) {
                    debugger;
                    var a = result;
                    var b = 1;
                    alert("Something went wrong21");
                }
            });
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
        <h1>View/Manage Broadcasts</h1>
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
                <% if (lstBroadcasts != null)
                    { %>
                <div class="list-group">
                    <% for (int i = 0; i < lstBroadcasts.Count; i++)
                        { %>
                    <a href="#"  class="list-group-item list-group-item-action" style="text-align: left;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12" style="font-weight: 500; font-size: 16px;"><span class="lbl-blog-title"><%= lstBroadcasts[i].broadcastMsg %></span></div>
                                    
                                    <div class="col-md-12">
                                        <span style="font-size:18px;color:lightgray;">by <%= lstBroadcasts[i].createdBy %></span>
                                    </div>
                                    <div class="col-md-12 lbl-description" style="font-size: 16px;" >
                                        <span class="bi bi-calendar" style="font-size: 16px;"></span>
                                        <%= lstBroadcasts[i].expiryDate %>
                                    </div>
                                    <div class="col-md-12 lbl-description"style="padding-top:10px;">
                                        <%--<asp:Button ID='btn_<% lstBroadcasts[i].recordId %>' runat="server" CssClass="btn btn-primary" OnClick="btnInactivate_Click"/>--%>
                                        <button id='btn_<%= lstBroadcasts[i].recordId %>' class="btn btn-primary" style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" onclick="fnUpdateBoadcast('<%= lstBroadcasts[i].recordId %>','<%= lstBroadcasts[i].status %>')">
                                            <% if (lstBroadcasts[i].status == "Y")
                                                { %>Inactivate<%}
                  else
                  { %>Activate<%} %></button>
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
