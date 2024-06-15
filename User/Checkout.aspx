<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="EShopping.User.Payment" %>
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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Checkout</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Checkout</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <!-- Checkout Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5">
            <div class="col-lg-7">
                <h6 class="text-primary mb-5" style="font-size: 15px;">
                    <i class="fas fa-thumbtack pr-2"></i>Payment Mode : &nbsp; a) Card payment.  &nbsp; &nbsp;b) Cash on delivery(Need to check the checkbox).
                </h6>
                <div class="mb-4">
                    <h4 class="font-weight-semi-bold mb-4">Card Payment</h4>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Card Holder Name<span>*</span></label>
                            <%--<input class="form-control" type="text" placeholder="John">--%>
                            <asp:TextBox ID="txtCardHolderName" runat="server" placeholder="Enter CardHolder Name" CssClass="form-control">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCardHolderName" runat="server" ErrorMessage="Card Holder Name is required"
                                ControlToValidate="txtCardHolderName" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                Font-Size="Small" ValidationGroup="cardPayment">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCardHolderName" runat="server" ControlToValidate="txtCardHolderName"
                                ErrorMessage="Name should be in characters" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                Font-Size="Small" ValidationExpression="^[a-zA-Z ]+$" ValidationGroup="cardPayment">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Card Number<span>*</span></label>
                            <asp:TextBox ID="txtCardNumber" runat="server" placeholder="Enter 16 digits card number" TextMode="Number"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ErrorMessage="Card Number is required"
                                ControlToValidate="txtCardNumber" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"
                                ValidationGroup="cardPayment">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                ErrorMessage="Card Number must be of 16 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                Font-Size="Small" ValidationExpression="[0-9]{16}" ValidationGroup="cardPayment">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Expiry Month & Year<span>*</span></label>
                            <asp:TextBox ID="txtExpiryMonthYear" runat="server" TextMode="Month" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvExpiryMonthYear" runat="server" SetFocusOnError="true"
                                ErrorMessage="Month & Year Expiry is required" ControlToValidate="txtExpiryMonthYear"
                                ForeColor="Red" Display="Dynamic" Font-Size="Small" ValidationGroup="cardPayment">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>CVV<span>*</span></label>
                            <asp:TextBox ID="txtCVV" runat="server" placeholder="Enter 3 digit CVV no." TextMode="Number"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCVV" runat="server" ErrorMessage="CVV Number is required"
                                ControlToValidate="txtCVV" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"
                                ValidationGroup="cardPayment">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCVV" runat="server" ControlToValidate="txtCVV"
                                ErrorMessage="CVV Number must be of 3 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                Font-Size="Small" ValidationExpression="[0-9]{3}" ValidationGroup="cardPayment">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-12 form-group">
                            <label>Write Your Address In Details<span>*</span></label>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4"
                                placeholder="Enter Delivery Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Address is required"
                                ControlToValidate="txtAddress" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                Font-Size="Small" ValidationGroup="cardPayment">
                            </asp:RequiredFieldValidator>
                        </div>

                        <%--<div class="col-md-12 form-group">
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="shipto">
                                <label class="custom-control-label" for="shipto" data-toggle="collapse" data-target="#shipping-address">Cash On Delivery</label>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="mb-4">
                    <div class="col-md-12 form-group">
                        <%--<div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="shipto">
                            <label class="custom-control-label" for="shipto" data-toggle="collapse" data-target="#shipping-address">Cash On Delivery</label>
                        </div>--%>
                        <asp:CheckBox ID="cbCOD" runat="server" AutoPostBack="true" OnCheckedChanged="cbCOD_CheckedChanged"
                            Text="&nbsp; Cash On Delivery &nbsp;<i class='fas fa-money-bill-wave'></i>" />
                    </div>
                </div>
                <asp:Panel ID="pnlCOD" runat="server" Visible="false">
                    <div class="mb-4">
                        <h4 class="font-weight-semi-bold mb-4">Cash On Delivery</h4>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>Write Your Address In Details<span>*</span></label>
                                <asp:TextBox ID="txtCodAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"
                                    placeholder="Enter Delivery Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCodAddress" runat="server" ErrorMessage="Address is required"
                                    ControlToValidate="txtCodAddress" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                    Font-Size="Small" ValidationGroup="codPayment">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </div>
            <div class="col-lg-5">
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Order Total</h4>
                    </div>
                    <div class="card-body">
                        <h5 class="font-weight-medium mb-3">Products</h5>
                        <asp:Repeater ID="rOrderSummary" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between">
                                    <p>
                                        <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="" style="width: 40px;">
                                        <%# Eval("ProductName") %> X <%# Eval("Quantity") %></p>
                                    <p>OMR <%# Eval("Price") %></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%--<div class="d-flex justify-content-between">
                            <p>Colorful Stylish Shirt 2</p>
                            <p>$150</p>
                        </div>--%>
                        <hr class="mt-0">
                        <div class="d-flex justify-content-between mb-3 pt-1">
                            <h6 class="font-weight-medium">Subtotal</h6>
                            <h6 class="font-weight-medium">OMR <% Response.Write(Session["price"]); %></h6>
                        </div>
                        <%--<div class="d-flex justify-content-between">
                            <h6 class="font-weight-medium">Shipping</h6>
                            <h6 class="font-weight-medium">OMR 10</h6>
                        </div>--%>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <div class="d-flex justify-content-between mt-2">
                            <h5 class="font-weight-bold">Total</h5>
                            <h5 class="font-weight-bold">OMR <% Response.Write(Session["price"]); %></h5>
                        </div>
                        <%--<button class="btn btn-lg btn-block btn-primary font-weight-bold my-3 py-3">Place Order</button>--%>
                        <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn btn-lg btn-block btn-primary font-weight-bold my-3 py-3"
                            Text="Place Order" ValidationGroup="cardPayment" OnClick="btnPlaceOrder_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- Checkout End -->

</asp:Content>
