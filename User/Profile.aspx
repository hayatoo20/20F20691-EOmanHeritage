<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EShopping.User.Profile" %>
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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">User Profile</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Profile</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>


    <div class="container">
        <div class="main-body">

            <asp:Repeater ID="rProfile" runat="server">
                <ItemTemplate>
                    <div class="row gutters-sm">
                <div class="col-md-4 mb-3">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex flex-column align-items-center text-center">
                                <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="image" class="rounded-circle" width="150">
                                <div class="mt-3">
                                    <h4><%# Eval("Name") %></h4>
                                    <p class="mb-1">@<%# Eval("Username") %></p>
                                    <p class="text-muted font-size-sm"><%# Eval("Email") %></p>
                                    <a href="OrderHistory.aspx" class="btn btn-primary">Orders</a>
                                    <%--<button class="btn btn-outline-primary">Reviews</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-md-8">
                    <div class="card mb-3">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Full Name</h6>
                                </div>
                                <div class="col-sm-9">
                                    <%# Eval("Name") %>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Email</h6>
                                </div>
                                <div class="col-sm-9">
                                    <%# Eval("Email") %>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Mobile</h6>
                                </div>
                                <div class="col-sm-9">
                                    <%# Eval("Mobile") %>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Post Code</h6>
                                </div>
                                <div class="col-sm-9">
                                    <%# Eval("PostCode") %>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Address</h6>
                                </div>
                                <div class="col-sm-9">
                                    <%# Eval("Address") %>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-12">
                                    <a class="btn btn-primary" href='<%# "Registration.aspx?id=" +Eval("UserId") %>'>
                                        <i class="fas fa-edit mr-1"></i>Edit</a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>


</asp:Content>
