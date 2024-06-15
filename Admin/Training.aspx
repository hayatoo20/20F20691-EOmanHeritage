<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="EShopping.Admin.Training" %>
<%@ Import Namespace="EShopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /*For disappearing alert message*/
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Header Start -->
    <div class="container-fluid bg-secondary mb-5">
        <div class="d-flex flex-column align-items-center justify-content-center" style="min-height: 300px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Training</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Training</p>
            </div>
        </div>
    </div>
     <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

</asp:Content>

  


  



