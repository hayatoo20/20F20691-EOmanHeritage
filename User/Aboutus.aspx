<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Aboutus.aspx.cs" Inherits="EShopping.User.Aboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Page Header Start -->
    <link href="../USER_Template/css/style.css" rel="stylesheet" />
    <div class="container-fluid bg-secondary mb-5">
        <div class="d-flex flex-column align-items-center justify-content-center" style="min-height: 300px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">About Us</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">About Us</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <!-- Contact Start -->
    <div class="container-fluid pt-5">
        <div class="text-center mb-4">
            <h2 class="section-title px-5"><span class="px-2">About Oman Heritage Web Marketplace</span></h2>
        </div>
        <label class="text-muted">The Oman Heritage Web Marketplace is
            an online platform that promotes authentic Omani heritage
            products globally. It connects artisans, preserves tradition,
            and fosters economic and cultural exchange. Additionally, it
            serves as a digital hub for community engagement, celebrating
            Oman's heritage in the modern era..</label>
        <div class="row px-xl-5">
            <div class="col-lg-4 mb-5">
                <div class="contact-form">
                    <div id="success"></div>
                    <form name="sentMessage" id="contactForm" novalidate="novalidate">
                        <div class="control-group">
                            <label for="aboutUs" class="font-weight-bold">Mission</label>
                            <div class="form-control" id="aboutUs">The Oman Heritage Web Marketplace is a digital
                                stronghold of Omani culture, connecting artisans globally
                                and fostering economic opportunities through the promotion
                                of authentic heritage products..</div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-lg-4 mb-5">
                <div class="contact-form">
                    <div id="success"></div>
                    <form name="sentMessage" id="contactForm" novalidate="novalidate">
                        <div class="control-group">
                            <label for="mission" class="font-weight-bold">Vision</label>
                            <div class="form-control" id="mission">Driven by a vision 
                                of cultural preservation in the digital era, Oman Heritage
                                Web Marketplace aspires to become the foremost online destination
                                for discerning patrons seeking genuine Omani craftsmanship. We aim
                                to foster a global community that cherishes and supports traditional
                                artisans, ensuring the perpetuation of Oman's rich cultural heritage
                                for generations to come.</div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-lg-4 mb-5">
                <div class="contact-form">
                    <div id="success"></div>
                    <form name="sentMessage" id="contactForm" novalidate="novalidate">
                        <div class="control-group">
                            <label for="vision" class="font-weight-bold">Our Values</label>
                            <div class="form-control" id="vision">The Oman Heritage Web Marketplace is dedicated to
                                                                  authenticity, empowering local artisans to showcase
                                                                  their skills while preserving Omani cultural identity.
                                                                  It fosters community engagement, celebrating heritage
                                                                  through meaningful connections, and embraces innovation
                                                                  to enhance global accessibility to Omani heritage products.</div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact End -->
</asp:Content>


