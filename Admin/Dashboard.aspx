<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EShopping.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ============================================================== -->
    <!-- Bread crumb and right sidebar toggle -->
    <!-- ============================================================== -->

    <!-- ============================================================== -->
    <!-- End Bread crumb and right sidebar toggle -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- Container fluid  -->
    <!-- ============================================================== -->
    <div class="container-fluid">
        <!-- *************************************************************** -->
        <!-- Start First Cards -->
        <!-- *************************************************************** -->
        <div class="card-group">
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["category"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Categories</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="Category.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-box fa-2x text-primary"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["subCategory"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Sub-Categories</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="SubCategory.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-boxes fa-2x text-danger"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["product"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Products</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="ProductList.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-box-open fa-2x text-success"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["order"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Total Orders</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="OrderStatus.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-shopping-cart fa-2x text-cyan"></i></span>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="card-group">
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["pending"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Pending Items</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="OrderStatus.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-hourglass-start fa-2x text-dark"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["dispatched"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Dispatched Items</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="OrderStatus.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-hourglass-end fa-2x text-black-50"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["outForDelivery"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Items Out for Delivery</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="OrderStatus.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-shipping-fast fa-2x"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["delivered"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Delivered Items</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="OrderStatus.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-people-carry fa-2x text-orange"></i></span>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="card-group">
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h3 class="text-dark mb-1 font-weight-medium">
                                    OMR <% Response.Write(Session["ltSoldAmount"]); %>
                                </h3>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Lifetime Sold Amount</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="SellingReport.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-money-bill-alt fa-2x text-warning"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h3 class="text-dark mb-1 font-weight-medium">
                                   OMR <% Response.Write(Session["lmSoldAmount"]); %>
                                </h3>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Last Month Sold Amount</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="SellingReport.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="far fa-money-bill-alt fa-2x text-primary"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["user"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Users</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="Users.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-users fa-2x text-danger"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card border-right">
                <div class="card-body">
                    <div class="d-flex d-lg-flex d-md-block align-items-center">
                        <div>
                            <div class="d-inline-flex align-items-center">
                                <h2 class="text-dark mb-1 font-weight-medium">
                                    <% Response.Write(Session["contact"]); %>
                                </h2>
                            </div>
                            <h6 class="text-muted font-weight-normal mb-0 w-100 text-truncate">Feedbacks</h6>
                            <div class="pt-4 pb-0">
                                <span>
                                    <a href="Contacts.aspx" class="font-weight-normal mb-0 w-100 text-truncate"><i class="fas fa-eye mr-1"></i>View Details</a>
                                </span>
                            </div>
                        </div>
                        <div class="ml-auto mt-md-3 mt-lg-0">
                            <span><i class="fas fa-comments fa-2x text-success"></i></span>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!-- *************************************************************** -->
        <!-- End First Cards -->
        <!-- *************************************************************** -->
        <!-- *************************************************************** -->

    </div>
    <!-- ============================================================== -->
    <!-- End Container fluid  -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->

</asp:Content>
