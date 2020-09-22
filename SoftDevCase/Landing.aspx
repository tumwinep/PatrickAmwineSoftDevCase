<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="SoftDevCase.Landing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMainContent" runat="server">

    <div class="container login-container">
        <div class="row">
            <div class="col-md-6 login-form">
                <h3>LANDED</h3>
                
                <div class="form-group">
                    <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username *" required="required"></asp:TextBox>
               </div>
                
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control"  placeholder="Password *" required="required" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Login" class="btnSubmit" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
