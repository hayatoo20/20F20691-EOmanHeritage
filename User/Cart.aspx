<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EShopping.User.Cart" %>

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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Shopping Cart</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Shopping Cart</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <!-- Cart Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5">
            <div class="col-lg-8 table-responsive mb-5">
                <asp:Repeater ID="rCart" runat="server" OnItemDataBound="rCart_ItemDataBound" OnItemCommand="rCart_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered text-center mb-0">
                            <thead class="bg-secondary text-dark">
                                <tr>
                                    <th>Products</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                    <th>Remove</th>
                                </tr>
                            </thead>
                            <tbody class="align-middle">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="align-middle">
                                <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="" style="width: 50px;">
                                <a href='<%# "ShopDetail.aspx?id=" + Eval("ProductId") %>'>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </a>
                            </td>
                            <td class="align-middle">
                                OMR <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                <asp:HiddenField ID="hdnProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                                <asp:HiddenField ID="hdnQuantity" runat="server" Value='<%# Eval("Quantity") %>' />
                                <asp:HiddenField ID="hdnPrdQuantity" runat="server" Value='<%# Eval("PrdQty") %>' />
                            </td>
                            <td class="align-middle">
                                <div class="input-group quantity mx-auto" style="width: 100px;">
                                    <div class="input-group-btn">
                                        <span class="btn btn-sm btn-primary btn-minus">
                                            <i class="fa fa-minus"></i>
                                        </span>
                                    </div>
                                    <%--<input type="text" class="form-control form-control-sm bg-secondary text-center" value="1">--%>
                                    <input type="text" id="txtQuantity" runat="server" class="form-control form-control-sm bg-secondary text-center"
                                        value='<%# Convert.ToInt32( Eval("Quantity")) %>'>
                                    <div class="input-group-btn">
                                        <span class="btn btn-sm btn-primary btn-plus">
                                            <i class="fa fa-plus"></i>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td class="align-middle">OMR <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                            </td>
                            <td class="align-middle">
                                <%--<button class="btn btn-sm btn-primary"><i class="fa fa-times"></i></button>--%>
                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-sm btn-primary" CommandName="remove"
                                    CommandArgument='<%# Eval("ProductId") %>'>
                                        <i class="fa fa-times"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="2" class="align-middle">
                                <a href="Shop.aspx" class="btn btn-primary px-3">
                                    <i class="fa fa-arrow-circle-left mr-2"></i>Continue Shopping
                                </a>
                            </td>
                            <td colspan="3" class="align-middle">
                                <asp:LinkButton ID="lbUpdateCart" runat="server" CssClass="btn btn-primary px-3" CommandName="updateCart">
                                    <i class="fa fa-spinner mr-2"></i>Update cart
                                </asp:LinkButton>
                            </td>
                        </tr>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-lg-4">
                <%--<div class="mb-5">
                    <div class="input-group">
                        <input type="text" class="form-control p-4" placeholder="Coupon Code">
                        <div class="input-group-append">
                            <button class="btn btn-primary">Apply Coupon</button>
                        </div>
                    </div>
                </div>--%>
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Cart Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="d-flex justify-content-between mb-3 pt-1">
                            <h6 class="font-weight-medium">Subtotal</h6>
                            <h6 class="font-weight-medium">
                               OMR <% Response.Write(Session["totalPrice"].ToString()); %>
                            </h6>
                        </div>
                        <%--<div class="d-flex justify-content-between">
                            <h6 class="font-weight-medium">Shipping</h6>
                            <h6 class="font-weight-medium">OMR 10</h6>
                        </div>--%>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <div class="d-flex justify-content-between mt-2">
                            <h5 class="font-weight-bold">Total</h5>
                            <h5 class="font-weight-bold">
                                OMR <% Response.Write(Session["totalPrice"].ToString()); %>
                            </h5>
                        </div>
                        <%--<button class="btn btn-block btn-primary my-3 py-3">Proceed To Checkout</button>--%>
                        <asp:LinkButton ID="lbCheckOut" runat="server" CssClass="btn btn-block btn-primary my-3 py-3" Enabled="false"
                            OnClick="lbCheckOut_Click">Proceed To Checkout<i class="fa fa-arrow-circle-right ml-2"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Cart End -->

</asp:Content>
