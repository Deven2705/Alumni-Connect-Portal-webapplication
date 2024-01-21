<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="AlumniConnect.ViewProfile" %>

<%--    <form id="form1" runat="server">--%>
<%--<nav class="navbar navbar-expand-sm ">
            <a class="navbar-brand" href="#">
                <img src="content/images/logo.png" /></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="Dashboard.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ViewProfile.aspx">View Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="EditProfile.aspx">Edit Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Openings</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Events</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Logout.aspx">Logout</a>
                    </li>
                </ul>
            </div>
        </nav>--%>
<%-- Edit Profile Menu   --%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
        
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-bottom: 10px; text-align: center; color: #003366;">
        <h1>Profile Details</h1>
    </div>
    <div class="row" style="margin-right: 0px;">
        <div class="col-md-12" style="padding-top: 40px; padding-left: 10%; padding-right: 10%; display: block">
            <%--col-md-12--%>
            <div style="padding-bottom: 10px; text-align: center; font-size: 24px;">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <%-- cssclass="alert alert-success alert-dismissible fade show"--%>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row" style="padding-left: 15px;">
                <div class="col-md-2">
                    <img src="../content/images/profile/default.png" id="imgProfile" runat="server" height="100" width="100" style="border-radius: 50%;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" />
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="lblName" runat="server" Style="font-size: 28px; color: #333; font-weight: bold;"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <span class="bi bi-person-fill" style="font-size: 24px;"></span>
                            <asp:Label ID="lblDesignation" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <span class="bi bi-briefcase-fill" style="font-size: 24px;"></span>
                            <asp:Label ID="lblCompany" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <span class="bi bi-award-fill" style="font-size: 24px;"></span>
                            <asp:Label ID="lbladmissionYear" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <span class="bi bi-geo-alt-fill" style="font-size: 24px;"></span>
                            <asp:Label ID="lblLocation" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6" style="padding-left: 15px;">
            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">Mobile :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblMobileNo" runat="server" Style="font-size: 28px; color: #333; font-weight: bold;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">Email :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblEmail" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">DOB :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblBDay" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">Hobbies :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblHobbies" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">Branch :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblBranch" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <span style="font-size: 28px; font-weight: bold;">Blood Group :</span>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="lblBloodGroup" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin: 0px; padding: 12px; text-align: center; font-size: 2rem;">
        <%--<div class="col-2 offset-1">
            Experience :-
        </div>
        <div class="col-2 ">
            <asp:Label ID="lblExperience" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
        </div>
    </div>
    <div class="row" style="margin: 0px; padding: 12px; text-align: center; font-size: 2rem;">
        <div class="col-2 offset-1">
            Education :-
        </div>
        <div class="col-2">
            <asp:Label ID="lblEducation" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
        </div>
    </div>
    <div class="row" style="margin: 0px; padding: 12px; text-align: center; font-size: 2rem;">
        <div class="col-2 offset-1">
            About :-
        </div>
        <div class="col-9">
            <asp:Label ID="lblAbout" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
        </div>--%>
        <div class="col-md-12">
            <ul class="nav nav-tabs">
                <li class="nav-item profile-tab">
                    <a class="nav-link active" data-toggle="tab" href="#home">Experience</a>
                </li>
                <li class="nav-item profile-tab">
                    <a class="nav-link" data-toggle="tab" href="#menu1">Education</a>
                </li>
                <li class="nav-item profile-tab">
                    <a class="nav-link" data-toggle="tab" href="#menu2">About</a>
                </li>
            </ul>

            <!-- Tab panes -->
            <div class="tab-content" style="text-align: left;">
                <%--<div class="container" style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);border:none;">--%>
                    <div id="home" class="container tab-pane active">

                        <%-- <h3>HOME</h3>--%>
                        <p>
                            <asp:Label ID="lblExperience" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </p>
                    </div>
                    <div id="menu1" class="container tab-pane fade">

                        <%--<h3>Menu 1</h3>--%>
                        <p>
                            <asp:Label ID="lblEducation" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </p>
                    </div>
                    <div id="menu2" class="container tab-pane fade">

                        <%-- <h3>Menu 2</h3>--%>
                        <p>
                            <asp:Label ID="lblAbout" runat="server" Style="font-size: 28px; color: gray; font-weight: bold;"></asp:Label>
                        </p>
                    <%--</div>--%>
                </div>
            </div>
        </div>
    </div>





    <div class="">
    </div>
    <%-- </form>--%>
</asp:Content>
