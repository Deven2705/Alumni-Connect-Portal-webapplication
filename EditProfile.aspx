<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="AlumniConnect.EditProfile" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding-bottom: 10px; text-align: center; color: #003366;">
        <br />
        <h1>Edit profile</h1>
    </div>
    <br />
    <hr />

    <div class="col-md-12" style="padding-top: 40px; padding-left: 10%; padding-right: 10%; display: block">
        <%--col-md-12--%>
        <div style="padding-bottom: 10px; text-align: center; font-size: 24px;">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <%-- cssclass="alert alert-success alert-dismissible fade show"--%>
        </div>

        <%--Personal Details--%>
        <div class="form-group">


            <%--<div class="content">

                        <div class="container" style="margin: 0 auto; margin-bottom: 1%; margin-left: 37%; text-align: justify; text-align: center;">
                            <div class="col-md-3">
                                <asp:FileUpload ID="fuUserPhoto" runat="server" CssClass="form-control" />

                                <asp:Button ID="btnUpload" runat="server" Text="Upload Photo " /><br />
                            </div>
                        </div>
                    </div>--%>
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Change Profile Photo</h1>
            </div>
            <div class="row">
                <div class="col-md-4 offset-md-4" style="text-align: center;">
                    <div class="form-group">
                        <img runat="server"  id="imgProfilePhoto" src="default.jpeg" height="200" />
                    </div>
                </div>
                <div class="col-md-6 offset-md-3">
                    <div class="form-group" >
                        <asp:FileUpload ID="fuUserPhoto" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-6 offset-md-3" style="text-align: center;">
                    <div class="form-group">
                        <asp:Button ID="btnUpload" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnUpload_Click" runat="server" Text="Upload Photo " />
                    </div>
                </div>
            </div>

            <hr />
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Personal Details</h1>
            </div>
            <div class="row">
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtName">Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="txtNickName">Nick Name</label>
                        <asp:TextBox ID="txtNickName" CssClass="form-control" placeholder="Enter Nick Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtDOB">DOB</label>
                        <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="Enter DOB" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 ">
                    <div class="form-group">
                        <label for="ddlBloodGroup">Blood Group</label>
                        <asp:DropDownList ID="ddlBloodGroup" CssClass="form-control" placeholder="Select Blood Group" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                            <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                            <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                            <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                            <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                            <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                            <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                            <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="rblGender">Gender</label>
                        <asp:RadioButtonList ID="rblGender" runat="server" Style="display: inline-block; border: hidden;" CssClass="form-control">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="txtMobileNo">Mobile Number</label>
                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeholder="Enter MobileNo" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtNativePlace">Native place</label>
                        <asp:TextBox ID="txtNativePlace" CssClass="form-control" placeholder="Enter Native Place" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 ">
                    <div class="form-group">
                        <label for="ddlBDayFlag">Birth-Day Flag</label>
                        <asp:DropDownList ID="ddlBDayFlag" CssClass="form-control" placeholder="Select Birth-Day Flag" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


            </div>
        </div>


        <%-- Educational Details--%>
        <hr />
        <div class="form-group">
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Educational Details</h1>
            </div>

            <div class="row">
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="ddlAdmissionYear">Admission Year</label>
                        <asp:DropDownList ID="ddlAdmissionYear" CssClass="form-control" placeholder="Select Admission Year" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                            <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                            <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                            <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                            <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                            <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                            <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                            <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                            <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                            <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="ddlPassoutYear">Passout Year</label>
                        <asp:DropDownList ID="ddlPassoutYear" CssClass="form-control" placeholder="Select Admission Year" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
                            <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
                            <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                            <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                            <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                            <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                            <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                            <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                            <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                            <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                            <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                            <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                            <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                            <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                            <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="ddlBranch">Branch</label>
                        <asp:DropDownList ID="ddlBranch" CssClass="form-control" placeholder="Select Branch" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Computer" Value="Computer"></asp:ListItem>
                            <asp:ListItem Text="Electronics" Value="Electronics"></asp:ListItem>
                            <asp:ListItem Text="Mechanical" Value="Mechanical"></asp:ListItem>
                            <asp:ListItem Text="Civil" Value="Civil"></asp:ListItem>
                            <asp:ListItem Text="Automobile" Value="Automobile"></asp:ListItem>
                            <asp:ListItem Text="IT" Value="IT"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="txtHigherEducation">Higher Education</label>
                        <asp:TextBox ID="txtHigherEducation" CssClass="form-control" placeholder="Enter Higher Education" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <hr />
        <%-- Profesional Details--%>
        <div class="form-group">
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Profesional Details</h1>
            </div>

            <div class="row">
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtCompanyName">Company Name</label>
                        <asp:TextBox ID="txtCompanyName" CssClass="form-control" placeholder="Enter Company Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="txtDesignation">Designation</label>
                        <asp:TextBox ID="txtDesignation" CssClass="form-control" placeholder="Enter Designation" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-10 offset-md-1">
                    <div class="form-group">
                        <label for="txtExperiance">Experiance</label>
                        <asp:TextBox ID="txtExperiance" CssClass="form-control" placeholder="Enter Experiance" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtSpecialization">Specialization</label>
                        <asp:TextBox ID="txtSpecialization" CssClass="form-control" placeholder="Enter Specialization" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5">

                    <div class="form-group">
                        <label for="txtLinkedIn">LinkedIn</label>
                        <asp:TextBox ID="txtLinkedIn" CssClass="form-control" placeholder="Enter LinkedIn" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>



            

                    <%--<div class="form-group">
                    <label for="ddlBachelorDegree">BachelorDegree</label>
                    <asp:DropDownList ID="ddlBachelorDegree" CssClass="form-control" placeholder="Select BachelorDegree" runat="server" >
                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                        <asp:ListItem Text="Computer" Value="Computer"></asp:ListItem>
                        <asp:ListItem Text="Electronics" Value="Electronics"></asp:ListItem>
                        <asp:ListItem Text="Mechanical" Value="Mechanical"></asp:ListItem>
                        <asp:ListItem Text="Civil" Value="Civil"></asp:ListItem>
                        <asp:ListItem Text="Automobile" Value="Automobile"></asp:ListItem>
                        <asp:ListItem Text="IT" Value="IT"></asp:ListItem>
                    </asp:DropDownList>
                </div>--%>
        </div>



        <hr />
        <%-- location  Details--%>
        <div class="form-group">
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Location  Details</h1>
            </div>

            <div class="row">
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtCity">City</label>
                        <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="Enter City" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="txtState">State</label>
                        <asp:TextBox ID="txtState" CssClass="form-control" placeholder="Enter State" runat="server" Text="Maharshtra"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 offset-md-1">
                    <div class="form-group">
                        <label for="txtCountry">Country</label>
                        <asp:TextBox ID="txtCountry" CssClass="form-control" placeholder="Enter Country" runat="server" Text="India"></asp:TextBox>


                        <%-- <div class="form-group">
                        <label for="ddlCountry">Country</label>
                        <asp:DropDownList ID="ddlCountry" CssClass="form-control" placeholder="Select Country" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="INDIA" Value="India"></asp:ListItem>
                            <asp:ListItem Text="ABROAD" Value="Abroad"></asp:ListItem>
                        </asp:DropDownList>
                    </div>--%>
                    </div>

                </div>

            </div>


        </div>

        <hr />
        <%-- Personal  Interest--%>
        <div class="form-group">
            <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                <h1>Personal  Interest</h1>
            </div>
            <div class="row">
                <div class="col-md-10 offset-md-1">
                    <div class="form-group">
                        <label for="txtAbout">About</label>
                        <asp:TextBox ID="txtAbout" CssClass="form-control" placeholder="Enter About" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-10 offset-md-1">
                    <div class="form-group">
                        <label for="txtHobbies">Hobbies</label>
                        <asp:TextBox ID="txtHobbies" CssClass="form-control" placeholder="Enter Hobbies" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>



            </div>

            <div style="text-align: center;">
                <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnSubmit_Click" ID="btnSubmit" />
            </div>
        </div>
    </div>
</asp:Content>
