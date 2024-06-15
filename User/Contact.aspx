<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EShopping.User.Contact" %>

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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Contact Us</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Contact</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <!-- Contact Start -->
    <div class="container-fluid pt-5">
        <div class="text-center mb-4">
            <h2 class="section-title px-5"><span class="px-2">We Are Here to Support you</span></h2>
        </div>
        <div class="row px-xl-5">
            <div class="col-lg-7 mb-5">
                <div class="contact-form">
                    <div id="success"></div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Your Name" ControlToValidate="txtName"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$"
                            ControlToValidate="txtName" Font-Size="Small">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Your Email" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ErrorMessage="Please Enter Your Subject" ControlToValidate="txtSubject"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ErrorMessage="Please Enter Your Message" ControlToValidate="txtMessage"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control"
                            placeholder="Message"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary py-2 px-4" Text="Send Message" 
                            OnClick="btnSubmit_Click"/>
                    </div>
                    
                </div>
            </div>
            <div class="col-lg-5 mb-5">
                <h5 class="font-weight-semi-bold mb-3">Get In Touch</h5>
                <p>Dear Customers, Do not Hesitate to Contact us to Request Assistance and IInquiries. We Will Respond to you as Soon as Possible..</p>
                <div class="d-flex flex-column mb-3">
                    <h5 class="font-weight-semi-bold mb-3">Store</h5>
                    <p class="mb-2"><i class="fa fa-map-marker-alt text-primary mr-3"></i>543 Street, AL MUSANNA, OMAN</p>
                    <p class="mb-2"><i class="fa fa-envelope text-primary mr-3"></i>20F20691@mec.edu.com</p>
                    <p class="mb-2"><i class="fa fa-phone-alt text-primary mr-3"></i>968+98566296</p>
                </div>
                <div class="d-flex flex-column">
                    <h5 class="font-weight-semi-bold mb-3">&nbsp;</h5>
                    <p class="mb-2">&nbsp;</p>
                    <p class="mb-0">&nbsp;</p>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact End -->

</asp:Content>
