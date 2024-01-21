

<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AddBroadcast.aspx.cs" Inherits="AlumniConnect.AddBroadcast" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%-- <h1> This feature is in Under Development</h1>--%>
    
    <div style="padding-bottom: 10px; text-align: center; color: #003366;">
        <br />
        <h1>Add a Broadcast</h1>
    </div>
    <br />
    <hr />

    <div class="col-md-12" style="padding-top: 40px; padding-left: 10%; padding-right: 10%; display: block">
        <%--col-md-12--%>
        <div style="padding-bottom: 10px; text-align: center; font-size: 24px;">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <label for="txtbroadcastMsg">broadcastMsg</label>
                    <asp:TextBox ID="txtbroadcastMsg" CssClass="form-control" Style="width: 100%" placeholder="Title" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 offset-md-3">
                    <div class="form-group">
                        <label for="ddlstatus">status</label>
                        <asp:DropDownList ID="ddlstatus" CssClass="form-control" placeholder="Select Blood Group" runat="server">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            <div class="col-md-6 offset-md-3">
                    <div class="form-group">
                        <label for="txtExpiry">Expiry Date</label>
                        <asp:TextBox ID="txtExpiry" CssClass="form-control" placeholder="dd-MM-yyyy" TextMode="Date" runat="server">
                        </asp:TextBox>
                    </div>
                </div>
            <div class="col-md-2 offset-md-5" style="text-align: center;">
                <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" Style="padding: 10px 40px 9px 40px; background-color: #003366; border-color: #003366;" OnClick="btnSubmit_Click" ID="btnSubmit" />
            </div>
        </div>  

    </div>
    </asp:Content>

