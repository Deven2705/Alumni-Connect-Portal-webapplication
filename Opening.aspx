<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opening.aspx.cs" Inherits="AlumniConnect.Opening" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Opening.aspx.cs" Inherits="AlumniConnect.Opening" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-bottom: 10px; text-align: center; color: #003366;">
        <br />
        <h1>Add a Opening / Intern</h1>
    </div>
    <br />
    <hr />

    <div class="col-md-12" style="padding-top: 40px; padding-left: 10%; padding-right: 10%; display: block">
        <%--col-md-12--%>
        <div style="padding-bottom: 10px; text-align: center; font-size: 24px;">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <%-- 
        <div class="form-group">
                        <label for="ddlBloodGroup">Blood Group</label>
                        <asp:DropDownList ID="ddlBloodGroup" CssClass="form-control" placeholder="Select Blood Group" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="JOb" Value="A+"></asp:ListItem>
                            <asp:ListItem Text="Interns" Value="A-"></asp:ListItem>
                        </asp:DropDownList>
                    </div> --%>

        <div class="row">
            
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <label for="ddlType">Type</label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                        <asp:ListItem Text="Opening" Value="O"></asp:ListItem>
                        <asp:ListItem Text="Intern" Value="I"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <label for="txtTitle">Title</label>

                    <asp:TextBox ID="txtTitle" CssClass="form-control" Style="width: 100%" placeholder="Title" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <label for="txtDescription">Description</label>
                    <asp:TextBox ID="txtDescription" Style="width: 100%" CssClass="form-control" placeholder="Description" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <label for="txtSRT">Send Resume To</label>
                    <asp:TextBox ID="txtSRT" Style="width: 100%" CssClass="form-control" placeholder="Email" runat="server" TextMode="Email"></asp:TextBox>
                </div>
            </div>
            
            
            <div class="col-md-12" style="text-align: center;">
                <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnSubmit_Click" ID="btnSubmit" />
            </div>
        </div>  

    </div>
</asp:Content>
