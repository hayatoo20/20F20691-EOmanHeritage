<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EShopping.User.Default" %>
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

    <div class="mt-3 ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>
    
    <!-- Featured Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5 pb-3">
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-check text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">Quality Product</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-shipping-fast text-primary m-0 mr-2"></h1>
                    <h5 class="font-weight-semi-bold m-0">Free Shipping</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fas fa-exchange-alt text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">14-Day Return</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-phone-volume text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">24/7 Support</h5>
                </div>
            </div>
        </div>

       <!-- WhatsApp Link Start -->
<div class="row px-xl-5 pb-3 justify-content-left">
    <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
        <div class="d-flex flex-column align-items-center border mb-4" style="padding: 60px;">
            <a href="https://wa.me/92726875" target="_blank" class="text-center">
                <img src="../UserTemplate/img/WATSAAP.jpg" alt="WhatsApp" style="width: 100px; height: 100px;" class="mb-3">
                <h5 class="font-weight-semi-bold m-0">Chat with us on WhatsApp</h5>
            </a>
        </div>
    </div>
</div>
<!-- WhatsApp Link End -->

    </div>
    <!-- Featured End -->


    <!-- Categories Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5 pb-3">
            <asp:Repeater ID="rCategory" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 pb-1">
                        <div class="cat-item d-flex flex-column border mb-4" style="padding: 30px;">
                            <p class="text-right"><%# Eval("ProductCount") %> Products</p>
                            <a href="Shop.aspx?cid=<%# Eval("CategoryId") %>" class="cat-img position-relative overflow-hidden mb-3">
                                <img class="img-fluid" src="<%# Utils.GetImageUrl( Eval("CategoryImageUrl")) %>" alt="" >
                            </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;<h5 class="font-weight-semi-bold m-0">
                                <%--Men's dresses--%>
                                <%# Eval("CategoryName") %>
                                <%--<a href="Shop.aspx?id=<%# Eval("CategoryId") %>" class="text-dark"> <%# Eval("CategoryName") %> </a>--%>
                            </h5>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
    <!-- Categories End -->


    <!-- Offer Start -->
    <div class="container-fluid offer pt-5">
        <div class="row px-xl-5">
            <div class="col-md-6 pb-4">
                <div class="position-relative bg-secondary text-center text-md-right text-white mb-2 py-5 px-5">
                    <img src="../UserTemplate/img/s2.jpeg" alt="">
                    <div class="position-relative" style="z-index: 1;">
                        <h5 class="text-uppercase text-primary mb-3">Oman Heritage Products</h5>
                        <h1 class="mb-4 font-weight-semi-bold">Made in Oman</h1>
                        <a href="Shop.aspx" class="btn btn-outline-primary py-md-2 px-md-3">Shop Now</a>
                    </div>
                </div>
            </div>
            <div class="col-md-6 pb-4">
                <div class="position-relative bg-secondary text-center text-md-left text-white mb-2 py-5 px-5">
                    <img src="../UserTemplate/img/s2.jpeg" alt="">
                    <div class="position-relative" style="z-index: 1;">
                        <h5 class="text-uppercase text-primary mb-3">Oman Heritage Products</h5>
                        <h1 class="mb-4 font-weight-semi-bold">Made in Oman</h1>
                        <a href="Shop.aspx" class="btn btn-outline-primary py-md-2 px-md-3">Shop Now</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Offer End -->


    <!-- Subscribe Start -->
    <div class="container-fluid bg-secondary my-5">
        <div class="row justify-content-md-center py-5 px-xl-5">
            <div class="col-md-6 col-12 py-5">
                <div class="text-center mb-2 pb-2">
                    <h2 class="section-title px-5 mb-3"><span class="bg-secondary px-2">Stay Updated</span></h2>
                    <p>Welcome to Oman Heritage Marketplace</p>
                </div>
                <div>
                    <div class="input-group">
                        <input type="text" class="form-control border-white p-4" placeholder="Email Goes Here" required>
                        <div class="input-group-append">
                            <%--<button class="btn btn-primary px-4">Subscribe</button>--%>
                            <asp:Button ID="btnSubscribe" runat="server" CssClass="btn btn-primary px-4" Text="Subscribe" 
                                OnClick="btnSubscribe_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Subscribe End -->


    <!-- Vendor Start -->
    <div class="container-fluid py-5">
        <div class="row px-xl-5">
            <div class="col">
                <div class="owl-carousel vendor-carousel">
                    <div class="vendor-item border p-4">
                        <img src="../UserTemplate/img/v1.jpg" alt="">
                    </div>
                    <div class="vendor-item border p-4">
                        <img src="../UserTemplate/img/v2.jpg" alt="">
                    </div>
                    <div class="vendor-item border p-4">
                        <img src="../UserTemplate/img/vvv.jpg" alt="">
                    </div>
                    <div class="vendor-item border p-4">
                        <img src="../UserTemplate/img/v4.jpg" alt="">
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
    <!-- Vendor End -->


</asp:Content>
