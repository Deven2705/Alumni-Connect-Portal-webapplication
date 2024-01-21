<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlumniConnect.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alumni Connect : PHCET</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="content/css/bootstrap.min.css">
    <script src="content/jquery.min.js"></script>
    <script src="content/js/popper.min.js"></script>
    <script src="content/js/bootstrap.min.js"></script>

</head>
<body>

    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm ">
            <a class="navbar-brand col-md-8 offset-2" href="Login.aspx" style="width: 100%;    text-align: center;"> 
                    <img src="content/images/newlogo.jpg" />  
            </a>
        </nav>

        <div class="row" style="margin-right: 0px;">
            <%--<div class="col-md-6" style="padding-top: 80px; text-align: center;">
                <h1>Welcome</h1>
                <img src="content/images/logo.png" style="padding-top: 40px; height: 100px; width: 350px;">
            </div>--%>
            <div class="col-md-6 offset-3" style="padding-top: 40px; padding-left: 10%; padding-right: 10%;">
                <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                    <h1>Alumni Connect Portal</h1>
                </div>
                <div style="padding-bottom: 10px; text-align: center; color: #003366;">
                    <h1>Login</h1>
                </div>
                <div style="padding-bottom: 10px;">
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
                        <%--<input class="form-check-input" type="checkbox">--%>
                        <asp:CheckBox ID="chkRemember" runat="server" CssClass="form-check-input" />
                        Remember me
                    </label>
                </div>
                <div style="text-align: center;">
                    <asp:Button runat="server" Text="Login" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnSubmit_Click" ID="btnSubmit" />
                </div>
                <div class="form-group">
                    <a href="Registration.aspx" style="float: right;">Not yet register ?</a>
                </div>
                <%--<br />
                <div class="form-group " style="padding-bottom: 10px; text-align: center;">
                    <h6>Don't Have Account!! <a href="Registration.aspx">Register</a>.</h6>
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
