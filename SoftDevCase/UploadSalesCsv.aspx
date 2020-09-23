<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UploadSalesCsv.aspx.cs" Inherits="SoftDevCase.UploadSalesCsv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMainContent" runat="server">
    <h3>Upload Sales Report</h3>
    <p>Upload file must be of format(.csv)</p>
       <div class="input-group">
        <div class="input-group-prepend">
            <asp:Button ID="btnFileUpload" runat="server" Text="Upload File" class="input-group-text" OnClick="btnFileUpload_Click" />
        </div>
        <div class="custom-file">
            <asp:FileUpload id="fileUpl" runat="server" onchange="callme(this)"/>
            <asp:Label ID="labelFilename" runat="server"></asp:Label>
        </div>
    </div>
   
 <script type="text/javascript">
     function callme() {
         document.getElementById('<%=labelFilename.ClientID%>').value = document.getElementById('<%=fileUpl.ClientID %>').value;

     }

</script>

</asp:Content>




