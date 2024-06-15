<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EShopping.Admin.Profile" %>

<%@ Import Namespace="EShopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 5%;
        }

            .container .img {
                text-align: center;
            }

            .container .details {
                border-left: 3px solid #ded4da;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <asp:Repeater ID="rProfile" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 col-sm-12 img">
                        <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="" class="img-thumbnail" width="300">
                    </div>
                    <div class="col-md-8 col-sm-12 details">
                        <div class="mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Full Name</h6>
                                    </div>
                                    <div class="col-sm-9">
                                        <%# Eval("Name") %>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Username</h6>
                                    </div>
                                    <div class="col-sm-9">
                                        <%# Eval("Username") %>
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
                                <hr />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>
