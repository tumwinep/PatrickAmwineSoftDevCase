<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SoftDevCase.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMainContent" runat="server">

    <div class="container login-container">
        <div class="row">
            <div class="col-md-6 login-form">
                <h3>Login</h3>
                
                <div class="form-group">
                    <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username *"></asp:TextBox>
               </div>
                
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password *"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Login" class="btnSubmit" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
