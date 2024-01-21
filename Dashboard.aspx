<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AlumniConnect.Dashboard" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AlumniConnect.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function fnViewProfile(recordId) {
            debugger;
            location.href = "ViewProfile.aspx?RecordId=" + recordId;
        }
    </script>
    <script>
        function myFunction() {
            var input, filter, ul, li, a, i, txtValue;
            input = document.getElementById("txtSearch");
            filter = input.value.toUpperCase();
            div = document.getElementById("userList");
            a = div.getElementsByTagName("a");
            for (i = 0; i < a.length; i++) {
                div1 = a[i].getElementsByTagName("div")[0];
                txtValue = div1.textContent || div1.innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    a[i].style.display = "";
                } else {
                    a[i].style.display = "none";
                }
            }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-right: 15px; margin-left: 15px;">
        <%--<div class="col-md-3" style="padding-top: 80px; text-align: center;">
            </div>--%>
        <%if (!string.IsNullOrEmpty(strBroadcast))
            { %>
        <div class="col-md-12" style="padding-top:20px;">
            <marquee class="blink" style="font-weight:bold;"><%= strBroadcast %></marquee>
        </div>
        <%} %>
        <div class="col-md-12" style="padding-top: 20px; padding-bottom: 20px; text-align: right;">
            <input id="txtSearch" type="text" onkeyup="myFunction()" placeholder="Search" style="width:200px;float:right;" class="form-control"/>
            </div>
        <div class="col-md-12" style="padding-top: 20px; padding-bottom: 20px; text-align: center;">
            <div class="list-group" id="userList">
                <%if (lst != null)
                    { %>
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
                            </div>
                        </div>
                    </div>
                </a>
                <%} %>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
