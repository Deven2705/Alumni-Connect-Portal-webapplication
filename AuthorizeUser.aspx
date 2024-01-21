<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizeUser.aspx.cs" Inherits="AlumniConnect.AuthorizeUser" %>--%>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AlumniConnect.Dashboard" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AuthorizeUser.aspx.cs" Inherits="AlumniConnect.AuthorizeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnViewProfile(recordId) {
            debugger;
            location.href = "ViewProfile.aspx?RecordId=" + recordId;
        }
    </script>
    <style>
        .blink {
    animation-duration: 1200ms;
    animation-name: blink;
    animation-iteration-count: infinite;
    animation-direction: alternate;
    -webkit-animation:blink 1200ms infinite; /* Safari and Chrome */
}
@keyframes blink {
    from {
        color:red;
    }
    to {
        color:blue;
    }
}
@-webkit-keyframes blink {
    from {
        color:red;
    }
    to {
        color:blue;
    }
}

    </style>
    <script>
        function fnAuthUnauthUser(recordId, type) {
            $.ajax({
                type: "POST",
                headers: "",
                contentType: "application/json; charset=utf-8",
                url: "AuthorizeUser.aspx/AuthUnauthUser",
                data: '{"recordId":"' + recordId + '","type":"' + type + '"}',
                //data: '',
                dataType: "json",
                async: false,
                success: function (data) {
                    debugger;
                    if (data != null && data != undefined && data != "") {
                        if (data.d != null && data.d != undefined && data.d != "") {
                            if (data.d.errorFlag === "N") {
                                window.location.href = "AuthorizeUser.aspx?status=suc";
                                //alert("Success");
                            }
                            else if (data.d.errorFlag === "Y") {
                                alert(data.d.errDesc);
                            }
                        }
                        else {
                            alert("Something went wrong");
                        }
                    }
                    else {
                        alert("Something went wrong");
                    }
                },
                error: function (result) {
                    debugger;
                    var a = result;
                    var b = 1;
                    alert("Something went wrong");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-right: 15px; margin-left: 15px;">
        <div class="col-md-12">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="col-md-12" style="padding-top: 20px; padding-bottom: 20px; text-align: center;">
            <div class="list-group">
                <% for (int i = 0; i < lst.Count; i++)
                    { %>
                <a href="#" onclick="fnViewProfile('<%=lst[i].recordId %>')" class="list-group-item list-group-item-action" style="text-align: left;">
                    <div class="row">
                        <div class="col-md-1">
                            <%--<asp:Image ImageUrl="<%=lst[i].imgUrl %>" runat="server" />--%>
                            <img src="<%=lst[i].imgUrl %>" height="80" width="80" style="border-radius: 50%;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" />
                        </div>
                        <div class="col-md-11">
                            <div class="row">
                                <div class="col-md-6" style="font-weight: bold; font-size: 18px;"><%= lst[i].name %></div>
                                <div class="col-md-6">
                                    <span class="bi bi-briefcase-fill" style="font-size: 24px;"></span>
                                    <%= lst[i].companyName %>
                                </div>
                                <div class="col-md-6">
                                    <span class="bi bi-award-fill" style="font-size: 24px;"></span>
                                    <%= lst[i].admissionYear %> - <%= lst[i].passoutYear %>, <%= lst[i].branch %>
                                </div>
                                <div class="col-md-6">
                                    <span class="bi bi-geo-alt-fill" style="font-size: 24px;"></span>
                                    <%= lst[i].location %>
                                </div>
                                <div class="col-md-6">
                                    <button class="btn btn-primary" style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" id="btn_<%= lst[i].recordId %>" onclick="fnAuthUnauthUser('<%= lst[i].recordId %>','A')">Authorize</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>

