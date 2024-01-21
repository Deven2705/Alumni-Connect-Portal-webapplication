<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AlumniConnect.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alumni Connect : PHCET</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="content/css/bootstrap.min.css" />
    <script src="content/jquery.min.js"></script>
    <script src="content/js/popper.min.js"></script>
    <script src="content/js/bootstrap.min.js"></script>

    <style>
        #rblGender > tbody> tr >td{
            padding-right:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm ">
            <a class="navbar-brand" href="#">
                <img src="content/images/logo.png"></a>
            <%--<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                </ul>
            </div>--%>
        </nav>

        <div class="row" style="margin-right: 0px;padding-bottom:20px;" >
            <div class="col-md-6" style="padding-top: 80px; text-align: center;">
                <h1>Welcome</h1>
                <img src="content/images/logo.png" style="padding-top: 40px; height: 110px; width: 600px; text-align: center">
                <br /><br /><br /><a href="Login.aspx">Already Register ? Click here to login</a>
            </div>
            <div class="col-md-6" style="padding-top: 40px; padding-left: 10%; padding-right: 10%;">
                <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                    <h1>Register</h1>
                </div>

                <div style="padding-bottom: 10px;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <%-- cssclass="alert alert-success alert-dismissible fade show"--%>
                </div>
                <div class="form-group">
                    <label for="txtName">Name</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>
                </div>


                <%--             *Gender*
                   <div class="form-group" >
                    <label for="RadioButton">Gender</label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="display:flex">  
                        <asp:ListItem>Male</asp:ListItem>  
                        <asp:ListItem>Female</asp:ListItem>  
                    </asp:RadioButtonList>
                </div>--%>

                <div class="form-group">
                    <label for="txtEmail">E-mail</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter Email" runat="server" TextMode="Email"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtMobNo">Mobile Number</label>
                    <asp:TextBox ID="txtMobNo" CssClass="form-control" placeholder="Enter Mobile Number" runat="server" TextMode="Number" MaxLength="10"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtDOB">DOB</label>
                    <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="Enter DOB" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="rblGender">Gender</label>
                    <asp:RadioButtonList ID="rblGender" runat="server" Style="display: flex" CssClass="form-control" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>

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

                <div class="form-group">
                    <label for="ddlPassoutYear">Passout Year</label>
                    <asp:DropDownList ID="ddlPassoutYear" CssClass="form-control" placeholder="Select Admission Year" runat="server">
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

                <div class="form-group">
                    <label for="fuUserPhoto">Profile Picture</label>
                    <asp:FileUpload ID="fuUserPhoto" runat="server" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtConfoPassword">Confirm Password</label>
                    <asp:TextBox ID="txtConfoPassword" CssClass="form-control" placeholder="Confirm password" runat="server" TextMode="Password"></asp:TextBox>
                    <%--<asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password must be matched"
                        ControlToValidate="txtConfoPassword" ControlToCompare="txtPassword" Operator="Equal"></asp:CompareValidator>--%>
                </div>

                <div style="text-align: center;">
                    <asp:Button runat="server" Text="Register" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnRegister_Click" ID="btnRegister" />
                </div>

                <%--<br />
                <div class="form-group" style="padding-bottom: 10px; text-align: center;">
                    <h6>Already Registered <a href="Login.aspx">Login</a>.</h6>
                </div>--%>


                <%-- <div style="padding-bottom: 10px;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="txtUsername">Username</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Enter username" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox">
                        Remember me
                    </label>
                </div>
                <div style="text-align:center;">
                    <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" style="padding: 10px 40px 9px 40px;background-color:#003366;border-color:#003366;" OnClick="btnSubmit_Click" ID="btnSubmit" />
                </div> --%>
            </div>
        </div>
    </form>
</body>
</html>
